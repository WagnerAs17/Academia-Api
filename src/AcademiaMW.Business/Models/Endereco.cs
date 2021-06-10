namespace AcademiaMW.Business.Models
{
    public class Endereco
    {
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Endereco
        (
            string logradouro, 
            string numero, 
            string bairro, 
            string cep, 
            string cidade, 
            string estado
        )
        {
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
