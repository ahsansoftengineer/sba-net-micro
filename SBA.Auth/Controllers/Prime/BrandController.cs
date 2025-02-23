// using AutoMapper;
// using GLOB.API.Controllers.Base;
// using GLOB.Domain.Hierarchy;
// using Microsoft.AspNetCore.Mvc;
// using SBA.Projectz.Data;

// namespace SBA.Hierarchy.Controllers.Prime;
// [Route("api/Hierarchy/[controller]")]
// [ApiController]
// public class BrandController : CommonController<BrandController, Brand>
// {
//   public BrandController(
//     ILogger<BrandController> logger,
//     IMapper mapper,
//     IUOW uow) : base(logger, mapper, uow)
//   {
//     Repo = uow.Brands;

//   }
// }