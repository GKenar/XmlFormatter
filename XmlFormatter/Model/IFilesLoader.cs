using System.Collections.Generic;

namespace XmlFormatter.Model
{
    interface IFilesLoader
    {
        List<byte[]> Load(List<string> paths);
    }
}
