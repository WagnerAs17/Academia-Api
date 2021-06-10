using System.Linq;

namespace AcademiaMW.Business.Extensions
{
    public static class StringNumero
    {
        public static string ApenasNumeros(this string str)
        {
            return new string(str.Where(char.IsDigit).ToArray());
        }
    }
}
