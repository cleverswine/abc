// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var dataPath = "/home/knoone/Code/abcgen/data";

var rss = new Rss(new HttpClient());
var items = await rss.Get(new Uri("https://www.etsy.com/shop/auntieboocrafts/rss"));
await rss.SaveAll(items, dataPath);
foreach (var item in items)
{
    await rss.SaveImage(item, dataPath);
}