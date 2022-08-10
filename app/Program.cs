if (args.Count() < 1)
{
    throw new ArgumentException("specify a base path on the command line please.");
}

var basePath = args[0];
var dataFileName = Path.Combine(basePath, "src/assets/data/rss.json");
var imgPath = Path.Combine(basePath, "public/images");
Console.WriteLine($"dataPath={dataFileName} / imgPath={imgPath}");

var rss = new Rss(new HttpClient());
var remoteItems = await rss.Get(new Uri("https://www.etsy.com/shop/auntieboocrafts/rss"));
var localItems = (await rss.Get(dataFileName)).ToList();

foreach (var remoteItem in remoteItems)
{
    if (!localItems.Exists(x => x.ImageUrl == remoteItem.ImageUrl))
    {
        Console.WriteLine("adding new item: ");
        Console.WriteLine(remoteItem.Title);
        localItems.Add(remoteItem);
    }

    await rss.SaveImage(remoteItem, imgPath);
}

await rss.SaveAll(localItems.OrderByDescending(x => x.PubDate), dataFileName);
