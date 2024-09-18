using Cotrucking.Infrastructure.Interfaces.Security;

namespace Cotrucking.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IPageFunctionalityRepository PageFunctinalities { get; }
        Task CompleteAsync();
    }
}
