// using AutoMapper;
// using GLOB.API.Controllers.Base;
// using GLOB.Domain.Entity;
// using Microsoft.AspNetCore.Mvc;
// using SBA.Hierarchy.Infra;

// namespace SBA.Hierarchy.Controllers.Test;
// [Route("api/Hierarchy/Test/[controller]")]
// [ApiController]
// public class TestInfraController : CommonController<TestInfraController, TestInfra>
// {
//   public TestInfraController(
//     ILogger<TestInfraController> logger,
//     IMapper mapper,
//     UOW uow) : base(logger, mapper, uow)
//   {
//     Repo = uow.TestInfras;

//   }
// }