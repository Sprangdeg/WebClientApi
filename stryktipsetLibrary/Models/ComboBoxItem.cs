using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stryktipsetLibrary.Models
{
    public class ComboBoxItem
    {
        public ComboBoxItem(KeyValuePair<Guid, string> keyVal, string text)
        {
            KeyVal = keyVal;
            Text = text;
        }
        public KeyValuePair<Guid, string> KeyVal { get; }
        public string Text { get; }

        public override string ToString()
        {
            return Text;
        }
    }
}
