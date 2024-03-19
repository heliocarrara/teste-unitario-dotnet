namespace Principal
{
    class ValidadorCredito : IValidadorCredito
    {
        private readonly string cpf;
        public ValidadorCredito(string cpf)
        {
            this.cpf = cpf;
        }

        public bool ValidarCredito(string cpf, decimal valor)
        {
            bool StatusSerasa = VerificarSituacaoSerasa(cpf);
            bool StatusSPC = VerificarSituacaoSPC(cpf);

            return (StatusSerasa && StatusSPC);
        }

        private bool VerificarSituacaoSPC(string cpf)
        {
            //Imagine um webservice aqui...
            return true;
        }

        private bool VerificarSituacaoSerasa(string cpf)
        {
            //Imagine um webservice aqui...
            return true;
        }
    }
}
