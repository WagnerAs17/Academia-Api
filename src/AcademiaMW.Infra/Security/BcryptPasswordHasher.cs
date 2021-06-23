using AcademiaMW.Business.Security;
using BC = BCrypt.Net.BCrypt;

namespace AcademiaMW.Infra.Security
{
    public class BcryptPasswordHasher : IBCryptPasswordHasher
    {

        public string GetHashPassword(string password)
        {
            return BC.HashPassword(password);
        }

        public bool VerifyHash(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }
    }
}
