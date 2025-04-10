using GLOB.Domain.Base;
using GLOB.Domain.Projectz;
using GLOB.Infra.Repo;

namespace GLOB.Infra.UOW_Projectz;
public interface IUOW_Infra : IDisposable
{
  Task Save();
  IRepoGenericz<API_Infra_EntityTest> TestInfras { get; }
  IRepoGenericz<ProjectzLookupzBase> ProjectzLookupzBases { get; }
  IRepoGenericz<ProjectzLookup> ProjectzLookups { get; }
}