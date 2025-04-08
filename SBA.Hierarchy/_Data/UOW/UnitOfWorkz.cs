using GLOB.Infra.Repo;
using GLOB.Domain.Hierarchy;
using GLOB.Domain.Projectz;

namespace SBA.Projectz.Data;
public partial class UOW
{
  public IRepoGenericz<TestProj> TestProjs => _testProj ??= new RepoGenericz<TestProj>(_context);
  
  // .-*
  public IRepoGenericz<Org> Orgs => _Orgs ??= new RepoGenericz<Org>(_context);
  public IRepoGenericz<BG> BGs => _BG ??= new RepoGenericz<BG>(_context);
  public IRepoGenericz<State> States => _State ??= new RepoGenericz<State>(_context);
  public IRepoGenericz<Bank> Banks => _Bank ??= new RepoGenericz<Bank>(_context);
  public IRepoGenericz<Brand> Brands => _Brand ??= new RepoGenericz<Brand>(_context);
  public IRepoGenericz<Industry> Industrys => _Industry ??= new RepoGenericz<Industry>(_context);
  public IRepoGenericz<Profession> Professions => _Profession ??= new RepoGenericz<Profession>(_context);

  // *-.
  public IRepoGenericz<LE> LEs => _LE ??= new RepoGenericz<LE>(_context);
  public IRepoGenericz<OU> OUs => _OU ??= new RepoGenericz<OU>(_context);
  public IRepoGenericz<SU> SUs => _SU ??= new RepoGenericz<SU>(_context);
  public IRepoGenericz<Systemz> Systemzs => _Systemz ??= new RepoGenericz<Systemz>(_context);
  public IRepoGenericz<City> Citys => _City ??= new RepoGenericz<City>(_context);
}