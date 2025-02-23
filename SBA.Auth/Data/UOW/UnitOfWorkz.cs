using GLOB.Infra.Repo;
using GLOB.Domain.Projectz;

namespace SBA.Projectz.Data;
public partial class UOW
{
  public IRepoGenericz<TestProj> TestProjs => _testProj ??= new RepoGenericz<TestProj>(_context);
}