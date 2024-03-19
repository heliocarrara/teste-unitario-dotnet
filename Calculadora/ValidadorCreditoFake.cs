namespace Principal
{
    public class ValidadorCreditoFake : IValidadorCredito
    {
        public bool ValidarCredito(string cpf, decimal valor)
        {
            //não acessa nada externo
            return true;
        }
    }
}
