using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KRibbon.Model
{
    public class MyRibbonButton
    {
        string label;
        string keytip;
        string img;
        string name;

        public MyRibbonButton() { }

        public string Label { get { return label; } set { label = value; } }
        public string KeyTip { get { return keytip; } set { keytip = value; } }
        public string Img { get { return img; } set { img = value; } }
        public string Name { get { return name; } set { name = value; } }
    }
}
