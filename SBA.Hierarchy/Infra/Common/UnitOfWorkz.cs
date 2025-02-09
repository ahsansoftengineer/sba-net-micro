using GLOB.Apps.Common;
using GLOB.Domain.Entity;
using GLOB.Infra.Common;

namespace SBA.Hierarchy.Infra;
public partial class UOW
{
  public IRepoGenericz<TestProj> TestProjs => _testProj ??= new RepoGenericz<TestProj>(_context);
  public IRepoGenericz<Org> Orgs => _Orgs ??= new RepoGenericz<Org>(_context);
  public IRepoGenericz<Systemz> Systemzs => _Systemz ??= new RepoGenericz<Systemz>(_context);
  public IRepoGenericz<BG> BGs => _BG ??= new RepoGenericz<BG>(_context);
  public IRepoGenericz<LE> LEs => _LE ??= new RepoGenericz<LE>(_context);
  public IRepoGenericz<OU> OUs => _OU ??= new RepoGenericz<OU>(_context);
  public IRepoGenericz<SU> SUs => _SU ??= new RepoGenericz<SU>(_context);
}