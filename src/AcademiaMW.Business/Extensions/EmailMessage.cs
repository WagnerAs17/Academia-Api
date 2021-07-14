namespace AcademiaMW.Business.Extensions
{
    public static class EmailMessage
    {
        public static (string titulo, string mensagem) ObterMensagemEmailEnvioCodigo(this string codigo)
        {
            var titulo = "Olimpo - seu novo código";

            var mensagem = "Código de confirmação para nova senha: " + codigo;

            return (titulo, mensagem);
        }
    }
}
