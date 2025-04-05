// using AutoMapper;
// using GLOB.Domain.Hierarchy;
// using Microsoft.AspNetCore.Mvc;
// using SBA.Projectz.Data;
// using SBA.Projectz.Controllers.Base;

// namespace SBA.Hierarchy.Controllers;
// [Route("api/Hierarchy/[controller]")]
// [ApiController]
// public class SUController : BasezController<SUController, SU, SUDto>
// {
//   public SUController(
//     ILogger<SUController> logger,
//     IMapper mapper,
//     IUOW uow) : base(logger, mapper, uow)
//   {
//     _repo = uow.SUs;

//   }

//   [HttpPost]
//   public async Task<IActionResult> Create([FromBody] SUDtoCreate data)
//   {
//     if (!ModelState.IsValid) return BadRequestz();
//     try
//     {
//       var result = _mapper.Map<SU>(data);
//       await _repo.Insert(result);
//       await _unitOfWork.Save();
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
//       await _unitOfWork.Save();
//       return Ok(result);
//     }
//     catch (Exception ex)
//     {
//       return CatchException(ex, nameof(Update));
//     }
//   }
// }