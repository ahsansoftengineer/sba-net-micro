using GLOB.Infra.Repo;
using GLOB.Domain.Hierarchy;
using GLOB.Domain.Projectz;
using GLOB.Infra.UOW;

namespace SBA.Projectz.Data;
public interface IUOW : IUnitOfWorkInfra
{
  IRepoGenericz<ProjectzEntityTest> TestProjs { get; }
  // .-*
  IRepoGenericz<Org> Orgs { get; }
  IRepoGenericz<BG> BGs { get; }
  IRepoGenericz<State> States { get; }
  IRepoGenericz<Bank> Banks { get; }
  IRepoGenericz<Brand> Brands { get; }
  IRepoGenericz<Industry> Industrys { get; }
  IRepoGenericz<Profession> Professions { get; }


  // *-.
  IRepoGenericz<Systemz> Systemzs { get; }
  IRepoGenericz<LE> LEs { get; }
  IRepoGenericz<OU> OUs { get; }
  IRepoGenericz<SU> SUs { get; }
  IRepoGenericz<City> Citys { get; }
}