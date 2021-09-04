using System.Collections.Generic;

namespace XmlFormatter.Model
{
    interface IFilesLoader
    {
        List<string> Load(List<string> paths);
    }
}
