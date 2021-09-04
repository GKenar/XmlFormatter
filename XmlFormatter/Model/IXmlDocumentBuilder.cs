using System.Collections.Generic;
using XmlFormatter.Common;

namespace XmlFormatter.Model
{
    interface IXmlDocumentBuilder
    {
        string Build(List<string> textFields, List<MyTableRow> tableRows, List<string> filesContent, List<string> filesPaths);
    }
}
