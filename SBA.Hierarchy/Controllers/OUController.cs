// using GLOB.Common.API;
// using GLOB.Domain.Base;
// using GLOB.Domain.Hierarchy;
// using Microsoft.AspNetCore.Mvc;
// using SBA.Projectz.Controllers.Base;

// namespace SBA.Hierarchy.Controllers;
// [Route("[controller]")]
// [ApiController]
// public class OUController : Project_RDS_Controller<OUController, OU, OUDtoRead>
// {
//   public IWebHostEnvironment WebHostEnvironment { get; }
//   public OUController(
//     IServiceProvider srvcProvider,
//     IWebHostEnvironment webHostEnvironment
//     ) : base(srvcProvider)
//   {
//     _repo = _uowProjectz.OUs;
//     WebHostEnvironment = webHostEnvironsment;
//   }
//   [HttpGet("[action]")]
//   public async Task<IActionResult> GetsPaginate([FromQuery] DtoRequestPage<OUDtoSearch> req)
//   {
//     try
//     {
//       var list = await _repo.GetsPaginate(req);
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
//     var result = _mapper.Map<OUDtoCreate, OUDtoCreateToEntity>(model);
//     FileUploderz fu = new FileUploderz(WebHostEnvironment, ModelState);
//     // Way 1
//     string topImg = await fu.UploadFile(model.TopImg, "TopImage");
//     //var topImg = await FileUploderz.UploadFile(model.TopImg, "TopImage"); //
//     if (topImg != "") result.TopImg = topImg;

//     // Way 3 Reflection
//     await fu.UploadFileReflection(model.LogoImg, "LogoImg", result);
//     await fu.UploadFileReflection(model.WarningImg, "WarningImg", result);
//     await fu.UploadFileReflection(model.FooterImg, "FooterImg", result);

//     try
//     {
//       var finalResult = _mapper.Map<OUDtoCreateToEntity, OU>(result);
//       await _repo.Insert(finalResult);
//       await _uowInfra.Save();
//       return Ok(finalResult);
//     }
//     catch (Exception ex)
//     {
//       return _Res.CatchException(ex, nameof(Create));
//     }
//   }
//   [HttpPost]
//   public async Task<IActionResult> Create([FromBody] OUDtoCreate data)
//   {
//     try
//     {
//       bool hasParent = _uowProjectz.BGs.AnyId(data.LEId);
//       if(!hasParent) return InvalidId("Invalid Business Group");

//       var result = _mapper.Map<OU>(data);

//       await _repo.Insert(result);
//       await _uowProjectz.Save();

//       return Ok(result);
//     }
//     catch (Exception ex)
//     {
//       return _Res.CatchException(ex, nameof(Create));
//     }
//   }

//   [HttpPut("{Id:int}")]
//   public async Task<IActionResult> Update(int Id, [FromBody] OUDtoCreate data)
//   {
//     try
//     {
//       var item = await _repo.Get(q => q.Id == Id);
//       if (item == null) return InvalidId();

//       bool hasParent = _uowProjectz.BGs.AnyId(data.LEId);
//       if(!hasParent) return InvalidId("Invalid State");

//       var result = _mapper.Map(data, item);

//       _repo.Update(item);
//       await _uowProjectz.Save();

//       return Ok(result);
//     }
//     catch (Exception ex)
//     {
//       return CatchException(ex, nameof(Update));
//     }
//   }
// }