using Cotrucking.Domain.Interfaces.Security;

namespace Cotrucking.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IPageFunctionalityRepository PageFunctinalities { get; }
        Task CompleteAsync();
    }
}
