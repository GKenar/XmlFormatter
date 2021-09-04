using System;
using System.Collections.Generic;
using System.Text;

namespace XmlFormatter.Html
{
    public class HtmlTag
    {
        private readonly string _tag;
        private readonly List<object> _content;
        private string _attribute;

        public HtmlTag(string tag)
        {
            _tag = tag;
            _content = new List<object>();
        }

        public HtmlTag(string tag, params object[] content) : this(tag)
        {
            foreach (var c in content)
                _content.Add(c);
        }

        public void SetAttribute(string attribute)
        {
            _attribute = attribute;
        }

        public void Add(string text)
        {
            _content.Add(text);
        }

        public void Add(HtmlTag tag)
        {
            _content.Add(tag);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"<{_tag}{(_attribute != null ? " " + _attribute : string.Empty)}>");
            foreach (var c in _content)
            {
                sb.Append(c);
            }
            sb.Append($"</{_tag}>\n");

            return sb.ToString();
        }
    }
}
