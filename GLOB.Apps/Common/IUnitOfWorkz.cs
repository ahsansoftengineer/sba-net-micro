using GLOB.Domain.Base;
using GLOB.Domain.Entity;

namespace GLOB.Apps.Common;
public interface IUnitOfWorkz : IDisposable
{
  Task Save();
  IRepoGenericz<TestInfra> TestInfras { get; }
}