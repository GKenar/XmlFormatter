using System;
using System.Collections.Generic;
using System.IO;

namespace XmlFormatter.Model
{
    class FilesLoader : IFilesLoader
    {
        public List<byte[]> Load(List<string> paths)
        {
            var filesContent = new List<byte[]>();

            foreach (var path in paths)
            {
                try
                {
                    filesContent.Add(File.ReadAllBytes(path));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return filesContent;
        } 
    }
}
