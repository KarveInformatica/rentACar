using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UnitTestTexto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MiTexto text = new MiTexto("Jordi");
            MessageBox.Show(text.MiTextoPrueba("Jennifer"));
        }
    }
}
