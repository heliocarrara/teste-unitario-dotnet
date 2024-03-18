using NUnit.Framework;
using Principal;
using System;

namespace ContaTeste.NUnit
{
    [TestFixture]
    public class ContaTeste
    {
        Conta conta;

        [SetUp]
        //[OneTimeSetUp]
        public void SetUp()
        {
            conta = new Conta("123456", 200);
        }

        //[TearDown]
        [OneTimeTearDown]
        public void TearDown()
        {
            // código executado após cada teste
            conta = null;
        }

        [Test]
        [Category("Regras de Negócio")]
        [TestCase(120, true)]
        [TestCase(-120, false)]
        [TestCase(180, true)]
        [TestCase(-1220, false)]
        [TestCase(1220, false)]
        public void testSacar(int valor, bool resultadoEsperado)
        {
            bool resultado = conta.Sacar(valor);

            Assert.IsTrue(resultado == resultadoEsperado);
        }

        [Test]
        [Category("Regras de Negócio")]
        public void testContaSacarSemSaldo()
        {
            bool resultado = conta.Sacar(500);

            Assert.IsFalse(resultado);
        }

        [Test]
        [Category("Valores Inválidos")]
        [TestCase(-16)]
        [TestCase(-100)]
        [TestCase(-1000)]
        [TestCase(-6900)]
        public void testSacarValorNegativo(int valor)
        {
            bool resultado = conta.Sacar(valor);

            Assert.IsFalse(resultado);
        }

        [Test]
        [Category("Valores Inválidos")]
        public void testSacarValorZero()
        {
            bool resultado = conta.Sacar(0);

            Assert.IsFalse(resultado);
        }

        [Test]
        [Timeout(4000)]
        [Category("Testes Didáticos")]
        //[Ignore("Pêndencia de criação de regra 002")]
        public void testMetodoLento()
        {
            bool resultado = conta.Sacar(0);

            Assert.IsFalse(resultado);
        }

        [Test]
        [Category("Testes Didáticos")]
        //[Ignore("Pêndencia de criação de regra 002")]
        public void testAssert()
        {
            Assert.Ignore("Testes de exemplo da classe Assert...");
            var teste = "";

            //Assert.IsEmpty(teste);
            //Assert.IsNull(teste);

            int a = 10, b = 9;

            //Assert.Greater(a, b);
            //Assert.AreSame(a, b);
            //Assert.Negative(a);
            //Assert.Less(b, a);

            var primeiraConta = new Conta("0123456789", 100);
            //var segundaConta = new Conta("0123456789", 100);
            var segundaConta = primeiraConta;

            //Assert.AreSame(primeiraConta, segundaConta);
            //Assert.IsNull(primeiraConta);
            Assert.IsNotNull(primeiraConta);
        }
    }
}
