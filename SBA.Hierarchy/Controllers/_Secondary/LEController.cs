// using GLOB.Domain.Base;
// using GLOB.Domain.Hierarchy;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using SBA.Projectz.Controllers.Base;

// namespace SBA.Hierarchy.Controllers.Test;
// [Route("[controller]")]
// [ApiController]
// public class LEController : Project_RDS_Controller<LEController, LE>
// {
//   public LEController(IServiceProvider srvcProvider) : base(srvcProvider)
//   {
//     _repo = _uowProjectz.LEs;
//   }

//   [HttpGet("[action]")]
//   public async Task<IActionResult> GetsPaginate([FromQuery] DtoPageReq<LEDtoSearch?> req)
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

//   [HttpPost]
//   public async Task<IActionResult> Create([FromBody] LEDtoCreate data)
//   {
//     if (!ModelState.IsValid) return _Res.BadRequestModel(ModelState);
//     try
//     {
//       bool hasParent = _uowProjectz.BGs.AnyId(data.BGId);
//       if(!hasParent) return Res_BadRequestzId("BGId",data.BGId);

//       var result = _mapper.Map<LE>(data);

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
//   public async Task<IActionResult> Update(int Id, [FromBody] LEDtoCreate data)
//   {
//     if (Id < 1) return _Res.NotFoundId(Id);
//     try
//     {
//       var item = await _repo.Get(q => q.Id == Id);
//       if (item == null) return _Res.NotFoundId(Id);
      
//       bool hasParent = _uowProjectz.BGs.AnyId(data.BGId);
//       if(!hasParent) return Res_BadRequestzId("BGId",data.BGId);

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