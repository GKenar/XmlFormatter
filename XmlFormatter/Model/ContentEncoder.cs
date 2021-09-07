namespace XmlFormatter.Model
{
    static class ContentEncoder
    {
        public static string ToBase64(byte[] bytesArray)
        {
            if (bytesArray == null)
                return null;

            return System.Convert.ToBase64String(bytesArray);
        }
    }
}
