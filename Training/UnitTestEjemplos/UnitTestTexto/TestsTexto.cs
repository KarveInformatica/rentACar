using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestTexto
{
    class TestsTexto
    {
        [Test]
        public void TestTexto()
        {
            MiTexto texto = new MiTexto("Jordi");
            string resultadoTest = texto.MiTextoPrueba("Jennifer");
            //Assert.IsNotNull(resultadoTest);
            Assert.AreEqual("qe tal Jennifer, Jordi te dice ola ke ase", resultadoTest);
        }
    }
}
