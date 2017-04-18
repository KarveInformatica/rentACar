using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static UnitTestDelegate.Form1;

namespace UnitTestDelegate
{
    class Operaciones
    {
        private double _num1;
        private double _num2;

        public Operaciones() { }

        public Operaciones(int num1, int num2)
        {
            this._num1 = num1;
            this._num2 = num2;
        }

        public int num1 { get; set; }
        public int num2 { get; set; }

        public double RealizarOperacion(double num1, double num2, Operacion operacion)
        {
            return operacion(num1, num2);
        }

        public double Sumar(double num1, double num2)
        {
            return num1 + num2;
        }

        public double Restar(double num1, double num2)
        {
            return num1 - num2;
        }
    }
}
