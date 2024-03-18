using Principal;
using System;

namespace Teste
{
    class CalculadoraTeste
    {
        public static void TestarClasseCalculadora()
        {
            testSomar();
            testSomarNumerosNegativos();
        }

        private static void testSomarNumerosNegativos()
        {
            var calculadora = new Calculadora();

            int resultadoEsperado = -50;

            int resultado = calculadora.Somar(-25, -25);

            if (resultado == resultadoEsperado)
            {
                Console.WriteLine("testSomarNumerosNegativos: OK");
            }
            else
            {
                Console.WriteLine("testSomarNumerosNegativos: Falhou");
            }
        }

        private static void testSomar()
        {
            var calculadora = new Calculadora();

            int resultadoEsperado = 350;

            int resultado = calculadora.Somar(100, 250);

            if(resultado == resultadoEsperado)
            {
                Console.WriteLine("testSomar: OK");
            }
            else
            {
                Console.WriteLine("testSomar: Falhou");
            }
        }
    }
}
