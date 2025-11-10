using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishing_tool.Messages
{
    public class TextMessage : IMessage
    {
        public TextMessage(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}
