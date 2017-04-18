using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UnitTestDelegate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int num1 = 8;
            int num2 = 6;
            Operaciones op = new Operaciones();

            Operacion opSuma = new Operacion(op.Sumar);
            double resultSuma = op.RealizarOperacion(num1, num2, opSuma);

            Operacion opResta = new Operacion(op.Restar);
            double resultResta = op.RealizarOperacion(num1, num2, opResta);

            MessageBox.Show("Suma: " + resultSuma + ", Resta: " + resultResta);
        }

        //public double RealizarOperacion(double num1, double num2, Operacion operacion) { return operacion(num1, num2); }
        //public double Sumar (double num1, double num2) { return num1 + num2; }
        //public double Restar(double num1, double num2) { return num1 - num2; }

        public delegate double Operacion(double num1, double num2);
    }
}
