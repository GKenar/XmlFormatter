using System.Collections.Generic;
using System.IO;
using System.Linq;
using XmlFormatter.Common;
using XmlFormatter.Html;

namespace XmlFormatter.Model
{
    class XmlDocumentBuilder : IXmlDocumentBuilder
    {
        public string Build(List<string> textFields, List<MyTableRow> tableRows, List<string> filesContent, List<string> filesPaths)
        {
            var doc = new HtmlTag("html");
            var body = new HtmlTag("body");
            var content = new HtmlTag("content");

            var meta = new HtmlTag("meta");
            meta.SetAttribute("charset=\"UTF-8\"");
            doc.Add(new HtmlTag("head", meta));

            var container = new HtmlTag("container");
            container.SetAttribute("id=\"electronic-document\"");

            foreach (var item in textFields.Select((value, index) => new { value, index }))
            {
                var p1 = new HtmlTag("p");
                p1.Add($"Текстовое поле №{item.index + 1}");
                var p2 = new HtmlTag("p");
                p2.Add(item.value);

                content.Add(p1);
                content.Add(p2);
            }

            var table = new HtmlTag("table", new HtmlTag("tr", 
                new HtmlTag("td", "Первая колонка"),
                new HtmlTag("td", "Вторая колонка"),
                new HtmlTag("td", "Третья колонка")
            ));

            foreach (var tableRow in tableRows)
            {
                var tr = new HtmlTag("tr");
                tr.Add(new HtmlTag("td", tableRow.FirstColumn));
                tr.Add(new HtmlTag("td", tableRow.SecondColumn));
                tr.Add(new HtmlTag("td", tableRow.ThirdColumn));

                table.Add(tr);
            }

            content.Add(table);

            // Files
            var applications = new HtmlTag("applications");

            for(var i = 0; i < filesContent.Count; i++)
            {
                var p1 = new HtmlTag("p");
                var application = new HtmlTag("application");
                var aTag = new HtmlTag("a");
                var fileName = Path.GetFileName(filesPaths[i]);

                aTag.SetAttribute($"download=\"{fileName}\" href=\"data:application/msword;base64,{filesContent[i]}\"");
                aTag.Add(fileName);

                application.Add(aTag);
                p1.Add(application);
                applications.Add(p1);
            }

            container.Add(content);
            container.Add(applications);
            body.Add(container);
            doc.Add(body);
            doc.Add(@"<style> 
            :root {
                background-color: #e6e6e6;
            }
            table, th, td { 
                border: 1px solid black; 
            } 
            #electronic-document {
                display: block !important;
                position: relative;
                width: 600px;
                margin: 24px auto;
                padding: 52px 52px 52px 104px;
                background-color: #fff;
                font-family: Arial, sans-serif;
            }
            </style>");

            return doc.ToString();
        }
    }
}
