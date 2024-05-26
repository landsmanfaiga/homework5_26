using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace homework5_21.Web.Services
{
    public class ColoringBook
    {
        public string Title { get; set; }
        public decimal Price {  get; set; }
        public string Url { get; set; }
        public string Image {  get; set; }
      
    }

    public class Scraper
    {
        public List<ColoringBook> Scrape()
        {
            var html = GetPennyHtml();
            var document = new HtmlParser().ParseDocument(html);

            var products = document.QuerySelectorAll(".type-product");
            List<ColoringBook > result = new List<ColoringBook>();
            foreach (var p in products)
            {
                result.Add(new ColoringBook
                {
                    Title = p.QuerySelector(".woocommerce-loop-product__title").TextContent,
                    Url = p.QuerySelector(".woocommerce-LoopProduct-link").Attributes["href"].Value,
                    Image = p.QuerySelector(".woo-entry-image-main").Attributes["src"].Value,
                    Price = Decimal.Parse(p.QuerySelector("bdi").TextContent.Replace("$", ""))
                });
            }
            return result;
        }

        private string GetPennyHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                UseCookies = true
            };
            var client = new HttpClient(handler);

            return client.GetStringAsync("https://www.pennydellpuzzles.com/coloring/").Result;
        }

       
        
    }
}
