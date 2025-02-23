using GLOB.Apps.Common;
using GLOB.Domain.Projectz;

namespace SBA.Projectz.Data;
public interface IUOW : IUnitOfWorkz
{
  IRepoGenericz<TestProj> TestProjs { get; }
}