// using AutoMapper;
// using GLOB.API.Controllers.Base;
// using GLOB.Domain.Hierarchy;
// using Microsoft.AspNetCore.Mvc;
// using SBA.Hierarchy.Data;

// namespace SBA.Hierarchy.Controllers.Prime;
// [Route("api/Hierarchy/[controller]")]
// [ApiController]
// public class BankController : CommonController<BankController, Bank>
// {
//   public BankController(
//     ILogger<BankController> logger,
//     IMapper mapper,
//     IUOW uow) : base(logger, mapper, uow)
//   {
//     Repo = uow.Banks;

//   }
// }