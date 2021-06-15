namespace AcademiaMW.Business.Security
{
    public interface IArgonPasswordHash
    {
        string GetHashPassword(string password);
        bool VerifyHash(string password, string hash);
    }
}
