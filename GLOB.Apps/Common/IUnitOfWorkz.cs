using GLOB.Domain.Entity;

namespace GLOB.Apps.Common;
public interface IUnitOfWorkz : IDisposable
{
  Task Save();
  IRepoGenericz<TestEntityInfra> TestEntityInfras { get; } // Alternate of OrgRepo
  // IRepoGenericz<TestParent> TestParents { get; }
  // IRepoGenericz<TestChild> TestChilds { get; }
  // IRepoGenericz<TestStatus> TestStatus { get; }
}