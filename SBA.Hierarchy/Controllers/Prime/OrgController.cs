// using AutoMapper;
// using GLOB.API.Controllers.Base;
// using GLOB.Domain.Entity;
// using Microsoft.AspNetCore.Mvc;
// using SBA.Hierarchy.App;

// namespace SBA.Hierarchy.Controllers.Test;
// [Route("api/Hierarchy/[controller]")]
// [ApiController]
// public class OrgController : CommonController<OrgController, Org>
// {
//   public OrgController(
//     ILogger<OrgController> logger,
//     IMapper mapper,
//     IUOW uow) : base(logger, mapper, uow)
//   {
//     Repo = uow.Orgs;

//   }
// }