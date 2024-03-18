using Principal;
using System;

namespace Teste
{
    class ContaTeste
    {
        public static void TestarClasseConta()
        {
            testContaSacar();
            testContaSacarSemSaldo();
        }

        private static void testContaSacarSemSaldo()
        {
            //Arrange
            Conta conta = new Conta("0123456789", 100);
            bool resultadoEsperado = false;

            //Act
            bool resultado = conta.Sacar(500);

            //Assert
            if (resultado == resultadoEsperado)
            {
                Console.WriteLine("testContaSacarSemSaldo: OK");
            }
            else
            {
                Console.WriteLine("testContaSacarSemSaldo: Falhou");
            }
        }

        private static void testContaSacar()
        {
            Conta conta = new Conta("0123456789", 100);
            bool resultadoEsperado = true;

            bool resultado = conta.Sacar(50);

            if (resultado == resultadoEsperado)
            {
                Console.WriteLine("testContaSacar: OK");
            }
            else
            {
                Console.WriteLine("testContaSacar: Falhou");
            }
        }
    }
}
