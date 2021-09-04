using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
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

            // Files
            var applications = new HtmlTag("applications");

            for(var i = 0; i < filesContent.Count; i++)
            {
                var p1 = new HtmlTag("p");
                var application = new HtmlTag("application");
                var aTag = new HtmlTag("a");
                aTag.SetAttribute($"download=\"{filesPaths[i]}\" href=\"data: ; base64, {filesContent[i]}\"");
                aTag.Add(filesPaths[i]);

                application.Add(aTag);
                p1.Add(application);
                applications.Add(p1);
            }

            content.Add(table);
            body.Add(content);
            body.Add(applications);
            doc.Add(body);
            doc.Add(@"<style> table, th, td { border: 1px solid black; } </style>");

            return doc.ToString();
        }
    }
}
