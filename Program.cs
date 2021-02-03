using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace webscraber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Web scraber");
            Console.WriteLine("Gets links with target blank and without rel=\"noopener noreferrer\"");
            
            Console.ForegroundColor = ConsoleColor.Green;
            
            string baseUrl = ReadLine.Read("Enter base url (hit enter for default):", "https://dk.sunclassairlines.dk");
            string navClass = ReadLine.Read("Enter css class of nav element (hit enter for default):", "navbar navbar-default");
        
            if(!baseUrl.StartsWith("http"))
            {
                baseUrl = $"https://{baseUrl}";
            }

            List<string> urls = new List<string>();
            urls.Add(baseUrl);

            // get pages
            var web = new HtmlWeb();
            HtmlDocument frontpage = web.Load(baseUrl);
            var div = frontpage.DocumentNode.SelectSingleNode($"//nav[@class=\"{navClass}\"]");
            if (div != null)
            {
                urls.AddRange(div.Descendants("a").Select(node => node.GetAttributeValue("href", string.Empty)).ToList());
            }

            // Normalize urls
            urls = urls.Select(x => x.StartsWith("/") ? baseUrl + x.TrimEnd('/') : x.TrimEnd('/')).Distinct().ToList();

            foreach (var url in urls)
            {
                HtmlDocument doc = web.Load(url);
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    // do something with link here
                    if (link.Attributes["target"]?.Value == "_blank" && link.Attributes["rel"] == null)
                    {
                        Console.WriteLine(url + " : " + link.OuterHtml);
                    }
                }
            }

            Console.ResetColor();
        }
    }
}
