using AcademiaMW.Core.Domain;

namespace AcademiaMW.Core.Data
{
    public interface IRepository<T> where T : IAggregateRoot
    {
    }
}
