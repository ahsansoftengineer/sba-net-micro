using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using GLOB.Domain.Entity;
using GLOB.Domain.Base;

namespace GLOB.Infra.Helper;
public class CommonConfigz<T> : IEntityTypeConfiguration<T>
  where T : BaseEntity, new()
{
  public void Configure(EntityTypeBuilder<T> builder)
  {
    string className = typeof(T).Name;
    builder.HasData(
      new T
      {
        Id = 1,
        Title = className + " 1 Title",
        Desc = className + " 1 Desc",
      },
      new T
      {
        Id = 2,
        Title = className + " 2 Title",
        Desc = className + " 2 Desc",
      },
      new T
      {
        Id = 3,
        Title = className + " 3 Title",
        Desc = className + " 3 Desc",
      }
    );
  }
}