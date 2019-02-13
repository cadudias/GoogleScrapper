using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleScrapper
{
    class Program
    {
        const string url = "https://www.google.com.br/search?safe=active&source=hp&ei=HWJjXLrhBunO5OUP36aNkAM&q=";

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult(); 
        }

        async static Task MainAsync(string[] args)
        {
            //var pergunta = "Qual é a capital do brasil?";
            //var pergunta = "Quem descobriu o brasil?";
            // nesse caso nao retiorna nada, poderia procurar no wikipedia, se for omlink dele, clicar e fazer o scrapper da pagina do wikipedia
            var pergunta = "Quantas luas tem em saturno?";

            var httpClient = new HttpClient();

            var html = await httpClient.GetStringAsync(url + pergunta);

            Console.WriteLine(html);

            Console.ReadLine();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var node = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='FSP1Dd']");
            
            if (node == null)
            {
                node = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='KpMaL']");
            }

            var text = node.InnerHtml;

            Console.WriteLine(text);

            Console.ReadLine();
        }
    }
}
