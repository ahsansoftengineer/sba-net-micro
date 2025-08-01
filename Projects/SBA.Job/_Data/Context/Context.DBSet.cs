using GLOB.Hierarchy.Global;


namespace SBA.Projectz.Data;

public partial class DBCtxProjectz
{
  // .-*
  public DbSet<GlobalLookupBase> GlobalLookupBases { get; set; }
  public DbSet<GlobalLookup> GlobalLookups { get; set; }
  public DbSet<NewTable> NewTables { get; set; }
}

public class NewTable : EntityBase
{

}
