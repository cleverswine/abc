if (args.Count() < 1)
{
    throw new ArgumentException("specify a base path on the command line please.");
}

var basePath = args[0];
var itemsToDisplay = 12;
var dataFileName = Path.Combine(basePath, "src/assets/data/rss.json");
var imgPath = Path.Combine(basePath, "public/images");
Console.WriteLine($"dataPath={dataFileName} | imgPath={imgPath}");

var rss = new Rss(new HttpClient());
var remoteItems = await rss.Get(new Uri("https://www.etsy.com/shop/auntieboocrafts/rss"));
var localItems = (await rss.Get(dataFileName)).ToList();

foreach (var remoteItem in remoteItems)
{
    var localItem = localItems.FirstOrDefault(x => x.ImageUrl == remoteItem.ImageUrl);
    if (localItem == null)
    {
        Console.WriteLine("adding new item: ");
        Console.WriteLine(remoteItem.Title);
        localItems.Add(remoteItem);
    }
    else
    {
        localItem.Title = remoteItem.Title;
    }

    await rss.SaveImage(remoteItem, imgPath);
}

var toDisplay = localItems
    .OrderBy(x => x.Weight)
    .ThenByDescending(x => x.PubDate)
    .Take(itemsToDisplay);
await rss.SaveAll(toDisplay, dataFileName);

Directory.EnumerateFiles(imgPath).ToList().ForEach(fn =>
{
    if (!toDisplay.Any(i => i.ImageName == fn.Split("/").Last()))
    {
        Console.WriteLine($"removing unused image {fn}");
        File.Delete(fn);
    }
});
