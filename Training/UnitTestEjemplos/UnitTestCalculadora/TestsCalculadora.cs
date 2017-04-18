using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestCalculadora
{
    public class TestsCalculadora
    {
        int num1 = 8;
        int num2 = 2;

        [Test]
        public void TestSumar()
        {
            var calculadora = new Calculadora();
            var resultadoSuma = calculadora.Sumar(num1, num2);
            Assert.AreEqual(10, resultadoSuma);
            Assert.AreNotEqual(4, resultadoSuma);
        }

        [Test]
        public void TestRestar()
        {
            var calculadora = new Calculadora();
            var resultadoResta = calculadora.Restar(num1, num2);
            Assert.AreEqual(6, resultadoResta);
        }
    }
}
