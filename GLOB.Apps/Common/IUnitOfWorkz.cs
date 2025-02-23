using GLOB.Domain.Projectz;

namespace GLOB.Apps.Common;
public interface IUnitOfWorkz : IDisposable
{
  Task Save();
  IRepoGenericz<TestInfra> TestInfras { get; }
}