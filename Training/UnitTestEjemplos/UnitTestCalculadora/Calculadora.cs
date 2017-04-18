using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestCalculadora
{
    public class Calculadora    
    {
        /// <summary>
        /// Suma los int recibidos por parámetros.
        /// </summary>
        /// <param name="num1">Un int</param>
        /// <param name="num2">Un int</param>
        /// <returns>Un int con la suma de los parámetros.</returns>
        public int Sumar(int num1, int num2)
        {
            return num1 + num2;
        }

        /// <summary>
        /// Resta los int recibidos por parámetros.
        /// </summary>
        /// <param name="num1">Un int</param>
        /// <param name="num2">Un int</param>
        /// <returns>Un int con la diferencia entre los parámetros.</returns>
        public int Restar(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}
