using GLOB.Apps.Common;
using GLOB.Domain.Entity;
using GLOB.Infra.Common;

namespace SBA.Hierarchy.Infra;
public partial class UOW 
{
  public IRepoGenericz<TestProj> TestProjs => _testProj ??= new RepoGenericz<TestProj>(_context);
}