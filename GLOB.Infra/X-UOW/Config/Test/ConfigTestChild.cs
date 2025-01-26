using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectName.Infra.Config.Hierarchy
{
  public class TestEntityConfig : IEntityTypeConfiguration<TestEntity>
  {
    public void Configure(EntityTypeBuilder<TestEntity> builder)
    {
      string name = typeof(TestEntity).Name; // type.Name
      builder.HasData(
        new TestEntity
        {
          Id = 1,
          Title = name + " 1",
          BGId = 1,
          Description = name + " 1 Description",
        },
         new TestEntity
         {
           Id = 2,
           Title = name + " 2",
           BGId = 2,
           Description = name + " 2 Description",
         }
      );
    }
  }
}