using System;
using System.Threading;

namespace Principal
{
    public class Conta
    {
        private string cpf;
        private decimal saldo;
        private IValidadorCredito validadorCredito;

        public Conta(string cpf, decimal saldo)
        {
            this.cpf = cpf;
            this.saldo = saldo;
        }

        public void SetValidadorCredito(IValidadorCredito validador)
        {
            this.validadorCredito = validador;
        }

        public decimal GetSaldo()
        {
            return this.saldo;
        }

        public void Depositar(decimal valor)
        {
            this.saldo += valor;
        }

        public bool Sacar(decimal valor)
        {
            if(valor <= 0)
            {
                return false;
            }

            if(valor > this.saldo)
            {
                return false;
            }

            this.saldo -= valor;
            return true;
        }

        public bool SolicitarEmprestimo(decimal valor)
        {
            bool resultado = false;

            if(valor >= this.saldo * 10)
            {
                return resultado;
            }

            try
            {
                 resultado = validadorCredito.ValidarCredito(this.cpf, valor);
            }
            catch (InvalidOperationException)
            {
                return resultado;
            }

            if (resultado)
            {
                this.saldo += valor;
            }

            return resultado;
        }
    }
}
