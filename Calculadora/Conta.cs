using System;
using System.Threading;

namespace Principal
{
    public class Conta
    {
        private string cpf;
        private decimal saldo;

        public Conta(string cpf, decimal saldo)
        {
            this.cpf = cpf;
            this.saldo = saldo;
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
    }
}
