using Moq;
using NUnit.Framework;
using Principal;
using System;

namespace ContaTest.Mock
{
    [TestFixture]
    public class ContaTeste
    {
        [Test]
        [Ignore("Método criando class fake para interface")]
        public void testSolicitarEmprestimoClasseFake()
        {
            var conta = new Conta("0001", 100);
            conta.SetValidadorCredito(new ValidadorCreditoFake());

            bool resultado = conta.SolicitarEmprestimo(5000);

            Assert.IsTrue(resultado);
        }

        [Test]
        public void testSolicitarEmprestimo()
        {
            var conta = new Conta("0001", 100);

            var mock = new Mock<IValidadorCredito>();

            mock.Setup(x => x.ValidarCredito("0001", 5000)).Returns(true);

            conta.SetValidadorCredito(mock.Object);
            int resultadoEsperado = 5100;

            conta.SolicitarEmprestimo(5000);

            Assert.IsTrue(conta.GetSaldo() == resultadoEsperado);
        }

        [Test]
        public void testSolicitarEmprestimoComException()
        {
            var conta = new Conta("0015", 3600);

            var mock = new Mock<IValidadorCredito>();

            mock.Setup(x => x.ValidarCredito(It.IsAny<string>(), It.IsAny<decimal>())).Throws<InvalidOperationException>();

            conta.SetValidadorCredito(mock.Object);
            int resultadoEsperado = 3600;

            conta.SolicitarEmprestimo(600);

            Assert.IsTrue(conta.GetSaldo() == resultadoEsperado);
        }

        [Test]
        public void testSolicitarEmprestimoParametroGenerico()
        {
            var conta = new Conta("0002", 1560);

            var mock = new Mock<IValidadorCredito>();

            mock.Setup(x => x.ValidarCredito(It.IsAny<string>(), It.Is<decimal>(y => y <= 5000))).Returns(true);

            conta.SetValidadorCredito(mock.Object);
            int resultadoEsperado = 3000;

            conta.SolicitarEmprestimo(1440);

            Assert.IsTrue(conta.GetSaldo() == resultadoEsperado);
        }

        [Test]
        public void testSolicitarEmprestimoAcimaLimite()
        {
            var conta = new Conta("0002", 150);

            var mock = new Mock<IValidadorCredito>();

            conta.SetValidadorCredito(mock.Object);

            conta.SolicitarEmprestimo(500);

            mock.Verify(x => x.ValidarCredito(It.IsAny<string>(), It.IsAny<decimal>()), Times.Once());
        }
    }
}
