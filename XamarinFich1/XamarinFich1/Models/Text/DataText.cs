using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinFich1.Helpers;

namespace XamarinFich1.Models.Text
{
    public enum TextType { Title, Subtitle, PlainText, Code };
    public class DataText:ObservableObject
    {
        public TextType Type { get; set; }
        public string Text { get; set; }
        
    }
}
