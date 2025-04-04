using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GLOB.Domain.Hierarchy;
using GLOB.Domain.Base;

namespace GLOB.Infra.Helper;
public class CommonConfigz<T> : IEntityTypeConfiguration<T>
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
      },
      new T
      {
        Id = 2,
        Name = className + " 2 Name",
        Desc = className + " 2 Desc",
      },
      new T
      {
        Id = 3,
        Name = className + " 3 Name",
        Desc = className + " 3 Desc",
      }
    );
  }
}