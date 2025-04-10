using GLOB.Infra.Repo;
using GLOB.Domain.Projectz;
using GLOB.Infra.UOW_Projectz;

namespace SBA.Projectz.Data;
public interface IUOW_Projectz : IUOW_Infra
{
  IRepoGenericz<ProjectzEntityTest> TestProjs { get; }

}