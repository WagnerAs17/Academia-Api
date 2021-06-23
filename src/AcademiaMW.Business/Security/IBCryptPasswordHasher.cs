namespace AcademiaMW.Business.Security
{
    public interface IBCryptPasswordHasher
    {
        string GetHashPassword(string password);
        bool VerifyHash(string password, string hash);
    }
}
