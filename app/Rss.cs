using System.Text.Json;
using System.Xml;

public class RssItem
{
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public string ImageName { get; set; }
    public string SourceLink { get; set; }
    public DateTime PubDate { get; set; }
}

public class Rss
{
    private readonly HttpClient _httpClient;

    public Rss(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<RssItem>> Get(string path)
    {
        if (!File.Exists(path)) return new List<RssItem>();
        return JsonSerializer.Deserialize<IEnumerable<RssItem>>(await File.ReadAllBytesAsync(path));
    }

    public async Task<IEnumerable<RssItem>> Get(Uri url)
    {
        var s = await _httpClient.GetStringAsync(url);
        var xml = new XmlDocument();
        xml.LoadXml(s);

        var result = new List<RssItem>();
        var items = xml.SelectNodes("rss/channel/item");
        foreach (XmlNode rssNode in items)
        {
            var title = rssNode.SelectSingleNode("title")?.InnerText ?? "";
            var link = rssNode.SelectSingleNode("link")?.InnerText ?? "";
            var description = rssNode.SelectSingleNode("description")?.InnerText ?? "";
            var pubDate = rssNode.SelectSingleNode("pubDate")?.InnerText ?? DateTime.Now.ToString();

            var imgStartString = "img src=\"";
            var imgEndString = "\" ";
            var imgStart = description.IndexOf(imgStartString) + imgStartString.Length;
            var imgEnd = description.IndexOf(imgEndString, imgStart);
            var img = description.Substring(imgStart, imgEnd - imgStart);

            result.Add(new RssItem
            {
                Title = title.Split(",").First(),
                ImageUrl = img,
                ImageName = img.Split('/').Last(),
                SourceLink = link,
                PubDate = DateTime.Parse(pubDate)
            });
        }
        return result;
    }

    public async Task SaveImage(RssItem item, string path)
    {
        if (File.Exists($"{path}/{item.ImageName}")) return;
        Console.WriteLine($"getting and saving image {item.ImageUrl}");
        var img = await _httpClient.GetByteArrayAsync(item.ImageUrl);
        File.WriteAllBytes($"{path}/{item.ImageName}", img);
    }

    public async Task SaveAll(IEnumerable<RssItem> items, string fileName)
    {
        if (File.Exists(fileName))
        {
            if (File.Exists(fileName + ".bk")) File.Delete(fileName + ".bk");
            File.Copy(fileName, fileName + ".bk");
        }
        await File.WriteAllTextAsync($"{fileName}", JsonSerializer.Serialize(items));
    }
}