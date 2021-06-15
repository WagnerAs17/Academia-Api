using System.Threading.Tasks;

namespace AcademiaMW.Business.Service.Interfaces
{
    public interface IEmailService
    {
        Task EnviarEmail(string subject, string message, string email);
    }
}
