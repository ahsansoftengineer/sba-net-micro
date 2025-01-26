using GLOB.Domain.Entity;

namespace GLOB.Apps.Common;
public interface IUnitOfWorkz : IDisposable
{
Task Save();
// Testz
IRepoGenericz<TestEntity> TestEntitys { get; } // Alternate of OrgRepo
IRepoGenericz<TestParent> TestParents { get; }
IRepoGenericz<TestChild> TestChilds { get; }

}