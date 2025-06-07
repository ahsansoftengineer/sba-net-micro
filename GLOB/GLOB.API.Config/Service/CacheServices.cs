// namespace GLOB.API.Config.Srvc;

// public class RedisCacheServices : RedisCacheService
// {
//   public RedisCacheServices(IServiceProvider sp) : base(sp)
//   {

//   }
//   public async Task SetHierarchy<T>(string key, T value, int? seconds = 60)
//   {
//     await Set<T>("" + key, value, seconds);

//   }
//   public async Task GetHierarchy<T>(string key, T value, int? seconds = 60)
//   {
//     return await Get<T>("" + key, value, seconds);

//   }
  
// }