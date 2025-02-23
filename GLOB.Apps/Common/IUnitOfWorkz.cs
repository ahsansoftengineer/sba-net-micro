using GLOB.Domain.Base;
using GLOB.Domain.Hierarchy;

namespace GLOB.Apps.Common;
public interface IUnitOfWorkz : IDisposable
{
  Task Save();
  IRepoGenericz<TestInfra> TestInfras { get; }
}