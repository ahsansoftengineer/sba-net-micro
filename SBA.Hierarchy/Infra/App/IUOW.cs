using GLOB.Apps.Common;
using GLOB.Domain.Entity;

namespace SBA.Hierarchy.App;
public interface IUOW : IUnitOfWorkz
{
  IRepoGenericz<TestProj> TestProjs { get; }
  IRepoGenericz<Org> Orgs { get; }
  IRepoGenericz<Systemz> Systemzs { get; }
  IRepoGenericz<BG> BGs { get; }
  IRepoGenericz<LE> LEs { get; }
  IRepoGenericz<OU> OUs { get; }
  IRepoGenericz<SU> SUs { get; }
}