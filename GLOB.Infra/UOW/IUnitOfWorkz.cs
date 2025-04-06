using GLOB.Domain.Projectz;
using GLOB.Infra.Repo;

namespace GLOB.Infra.UOW;
public interface IUnitOfWorkInfra : IDisposable
{
  Task Save();
  IRepoGenericz<TestInfra> TestInfras { get; }
}