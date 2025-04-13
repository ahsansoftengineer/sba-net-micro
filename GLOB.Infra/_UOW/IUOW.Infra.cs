using GLOB.Domain.Base;
using GLOB.Infra.Repo;

namespace GLOB.Infra.UOW_Projectz;
public interface IUOW_Infra : IDisposable
{
  Task Save();
  IRepoGenericz<ProjectzLookupBase> ProjectzLookupBases { get; }
  IRepoGenericz<ProjectzLookup> ProjectzLookups { get; }
}