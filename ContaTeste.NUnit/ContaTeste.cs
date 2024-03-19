using NUnit.Framework;
using Principal;

namespace ContaTeste.NUnit
{
    [TestFixture]
    [Ignore("Projeto sem mock")]
    public class ContaTeste
    {
        Conta conta;

        [SetUp]
        public void SetUp()
        {
            conta = new Conta("123456", 200);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
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
        public void testMetodoLento()
        {
            bool resultado = conta.Sacar(0);

            Assert.IsFalse(resultado);
        }
    }
}
