using GLOB.Domain.Projectz;
using GLOB.Infra.Repo;

namespace GLOB.Infra.UOW;
public interface IUnitOfWorkInfra : IDisposable
{
  Task Save();
  IRepoGenericz<API_Infra_EntityTest> TestInfras { get; }
}