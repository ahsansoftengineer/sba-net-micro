// using GLOB.Domain.Hierarchy;
// using Microsoft.AspNetCore.Mvc;
// using SBA.Projectz.Controllers.Base;

// namespace SBA.Hierarchy.Controllers;
// [Route("[controller]")]
// [ApiController]
// public class SUController : Project_RDS_Controller<SUController, SU, SUDtoRead>
// {
//   public SUController(IServiceProvider srvcProvider) : base(srvcProvider)
//   {
//     _repo = _uowProjectz.SUs;
//   }

//   [HttpPost]
//   public async Task<IActionResult> Create([FromBody] SUDtoCreate data)
//   {
//     try
//     {
//       var result = _mapper.Map<SU>(data);
//       await _repo.Insert(result);
//       await _uowInfra.Save();
//       return Ok(result);
//     }
//     catch (Exception ex)
//     {
//       return _Res.CatchException(ex, nameof(Create));
//     }
//   }

//   [HttpPut("{Id:int}")]
//   public async Task<IActionResult> Update(int Id, [FromBody] SUDtoCreate data)
//   {
//     if (Id < 1) return InvalidId();
//     try
//     {
//       var item = await _repo.Get(q => q.Id == Id);

//       if (item == null) return InvalidId();
//       var result = _mapper.Map(data, item);
//       _repo.Update(item);
//       await _uowInfra.Save();
//       return Ok(result);
//     }
//     catch (Exception ex)
//     {
//       return CatchException(ex, nameof(Update));
//     }
//   }
// }