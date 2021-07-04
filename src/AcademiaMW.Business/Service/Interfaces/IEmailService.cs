using AcademiaMW.Core.Domain;
using System.Threading.Tasks;

namespace AcademiaMW.Business.Service.Interfaces
{
    public interface IEmailService : IService
    {
        Task EnviarEmail(Email email);
    }
}
