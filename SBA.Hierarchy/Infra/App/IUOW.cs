using GLOB.Apps.Common;
using GLOB.Domain.Entity;

namespace SBA.Hierarchy.App;
public interface IUOW : IUnitOfWorkz
{
  IRepoGenericz<TestProj> TestProjs { get; }
}