// using AutoMapper;
// using GLOB.Common.API;
// using GLOB.Domain.Base;
// using GLOB.Domain.Hierarchy;
// using Microsoft.AspNetCore.Mvc;
// using SBA.Projectz.Data;
// using SBA.Projectz.Controllers.Base;

// namespace SBA.Hierarchy.Controllers;
// [Route("api/Hierarchy/[controller]")]
// [ApiController]
// public class OUController : BasezController<OUController, OU, OUDto>
// {
//   public IWebHostEnvironment WebHostEnvironment { get; }

//   public OUController(
//   ILogger<OUController> logger,
//   IMapper mapper,
//   IUOW uow,
//   IWebHostEnvironment webHostEnvironment) : base(logger, mapper, uow)
//   {
//     Repo = uow.OUs;
//     WebHostEnvironment = webHostEnvironment;
//   }
//   [HttpGet("GetsPaginate")]
//   public async Task<IActionResult> GetsPaginate([FromQuery] PaginateRequestFilter<OUDtoSearch> req)
//   {
//     try
//     {
//       var list = await Repo.GetsPaginate(req);
//       return Ok(list);
//     }
//     catch (Exception ex)
//     {
//       return CatchException(ex, nameof(Gets));
//     }
//   }

//   [HttpPost()]
//   public async Task<IActionResult> Create([FromForm] OUDtoCreate model)
//   {
//     var result = Mapper.Map<OUDtoCreate, OUDtoCreateToEntity>(model);
//     FileUploderz fu = new FileUploderz(WebHostEnvironment, ModelState);
//     // Way 1
//     string topImg = await fu.UploadFile(model.TopImg, "TopImage");
//     //var topImg = await FileUploderz.UploadFile(model.TopImg, "TopImage"); //
//     if (topImg != "") result.TopImg = topImg;

//     // Way 3 Reflection
//     await fu.UploadFileReflection(model.LogoImg, "LogoImg", result);
//     await fu.UploadFileReflection(model.WarningImg, "WarningImg", result);
//     await fu.UploadFileReflection(model.FooterImg, "FooterImg", result);

//     if (!ModelState.IsValid) return BadRequestz();
//     try
//     {
//       var finalResult = Mapper.Map<OUDtoCreateToEntity, OU>(result);
//       await Repo.Insert(finalResult);
//       await _unitOfWork.Save();
//       return Ok(finalResult);
//     }
//     catch (Exception ex)
//     {
//       return CatchException(ex, nameof(Create));
//     }
//   }
//   [HttpPost]
//   public async Task<IActionResult> Create([FromBody] OUDtoCreate data)
//   {
//     if (!ModelState.IsValid) return BadRequestz();
//     try
//     {
//       bool hasParent = uOW.BGs.AnyId(data.LEId);
//       if(!hasParent) return InvalidId("Invalid Business Group");

//       var result = Mapper.Map<OU>(data);

//       await Repo.Insert(result);
//       await uOW.Save();

//       return Ok(result);
//     }
//     catch (Exception ex)
//     {
//       return CatchException(ex, nameof(Create));
//     }
//   }

//   [HttpPut("{id:int}")]
//   public async Task<IActionResult> Update(int id, [FromBody] OUDtoCreate data)
//   {
//     if (!ModelState.IsValid || id < 1) return InvalidId();
//     try
//     {
//       var item = await Repo.Get(q => q.Id == id);
//       if (item == null) return InvalidId();

//       bool hasParent = uOW.BGs.AnyId(data.LEId);
//       if(!hasParent) return InvalidId("Invalid State");

//       var result = Mapper.Map(data, item);

//       Repo.Update(item);
//       await uOW.Save();

//       return Ok(result);
//     }
//     catch (Exception ex)
//     {
//       return CatchException(ex, nameof(Update));
//     }
//   }
// }