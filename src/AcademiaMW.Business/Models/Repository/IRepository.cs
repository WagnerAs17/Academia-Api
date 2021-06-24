using AcademiaMW.Core.Domain;

namespace AcademiaMW.Business.Models.Repository
{
    public interface IRepository<T> where T : IAggregateRoot
    {
    }
}
