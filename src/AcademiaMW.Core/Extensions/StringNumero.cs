using System.Linq;

namespace AcademiaMW.Core.Extensions
{
    public static class StringNumero
    {
        public static string ApenasNumeros(this string str)
        {
            return new string(str.Where(char.IsDigit).ToArray());
        }
    }
}
