using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GLOB.Domain.Enums;
using GLOB.Domain.Base;

namespace GLOB.Infra.Repo;
public class CommonStatusConfigz<T> : IEntityTypeConfiguration<T>
  where T : EntityBase, new()
{
  public void Configure(EntityTypeBuilder<T> builder)
  {
    string className = typeof(T).Name;
    builder.HasData(
      new T
      {
        Id = 1,
        Name = className + " 1 Name",
        Desc = className + " 1 Desc",
        Status = Status.None,
      },
      new T
      {
        Id = 2,
        Name = className + " 2 Name",
        Desc = className + " 2 Desc",
        Status = Status.Active,
      },
      new T
      {
        Id = 3,
        Name = className + " 3 Name",
        Desc = className + " 3 Desc",
        Status = Status.DeActive,
      },
      new T
      {
        Id = 4,
        Name = className + " 4 Name",
        Desc = className + " 4 Desc",
        Status = Status.Delete,
      }
    );
  }
}