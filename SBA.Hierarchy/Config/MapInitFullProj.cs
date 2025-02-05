using GLOB.API;
using GLOB.Domain.Entity;

namespace SBA.Hierarchy.Config;
public class MapInitFullProj : MapInitFull
{
  public MapInitFullProj() : base()
  {
    CreateMapCommon<TestProj>();
  }
}