// using GLOB.Domain.Hierarchy;
// using Microsoft.AspNetCore.Mvc;
// using SBA.Projectz.Controllers.Base;

// namespace SBA.Hierarchy.Controllers;
// [Route("api/Hierarchy/[controller]")]
// [ApiController]
// public class SUController : Project_RDS_Controller<SUController, SU, SUDtoRead>
// {
//   public SUController(IServiceProvider srvcProvider) : base(srvcProvider)
//   {
//     _repo = _uow.SUs;
//   }

//   [HttpPost]
//   public async Task<IActionResult> Create([FromBody] SUDtoCreate data)
//   {
//     if (!ModelState.IsValid) return BadRequestz();
//     try
//     {
//       var result = _mapper.Map<SU>(data);
//       await _repo.Insert(result);
//       await _uowInfra.Save();
//       return Ok(result);
//     }
//     catch (Exception ex)
//     {
//       return CatchException(ex, nameof(Create));
//     }
//   }

//   [HttpPut("{id:int}")]
//   public async Task<IActionResult> Update(int id, [FromBody] SUDtoCreate data)
//   {
//     if (!ModelState.IsValid || id < 1) return InvalidId();
//     try
//     {
//       var item = await _repo.Get(q => q.Id == id);

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