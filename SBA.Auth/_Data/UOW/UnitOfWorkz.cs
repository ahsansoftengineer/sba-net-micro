using GLOB.Infra.Repo;
using GLOB.Domain.Projectz;

namespace SBA.Projectz.Data;
public partial class UOW_Projectz
{
  public IRepoGenericz<ProjectzEntityTest> TestProjs => _testProj ??= new RepoGenericz<ProjectzEntityTest>(_context);
}