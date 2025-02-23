using GLOB.Apps.Common;
using GLOB.Domain.Projectz;
using GLOB.Infra.Repo;

namespace SBA.Projectz.Data;
public partial class UOW
{
  public IRepoGenericz<TestProj> TestProjs => _testProj ??= new RepoGenericz<TestProj>(_context);
}