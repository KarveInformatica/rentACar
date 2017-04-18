using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static UnitTestDelegate.Form1;

namespace UnitTestDelegate
{
    class TestsDelegates
    {
        int num1 = 8;
        int num2 = 6;
        Operaciones op = new Operaciones();

        [Test]
        public void TestOperacionSuma()
        {
            double resultSuma = op.RealizarOperacion(num1, num2, new Operacion(op.Sumar));
            Assert.AreEqual(14, resultSuma);            
        }

        [Test]
        public void TestOperacionResta()
        {
            double resultResta = op.RealizarOperacion(num1, num2, new Operacion(op.Restar));
            Assert.AreEqual(2, resultResta);
        }
    }
}
