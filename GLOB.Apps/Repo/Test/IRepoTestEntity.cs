using GLOB.Apps.Common;
using GLOB.Domain.Entity;

namespace GLOB.App.Repo;
public interface IRepoTestEntityInfra: IRepoGenericz<TestInfra>
{
  void Update(TestInfra entity);
}