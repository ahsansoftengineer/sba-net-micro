// using AutoMapper;
// using GLOB.API.Controllers.Base;
// using GLOB.Apps.Common;
// using GLOB.Domain.Hierarchy;
// using Microsoft.AspNetCore.Mvc;

// namespace GLOB.API.Controllers.Test;
// [Route("api/[controller]")]
// [ApiController]
// public class TestStatusController : CommonStatusController<TestStatusController, TestStatus>
// {
//   public TestStatusController(
//     ILogger<TestStatusController> logger,
//     IMapper mapper,
//     IUnitOfWorkz unitOfWork) : base(logger, mapper, unitOfWork)
//   {
//     Repo = unitOfWork.TestStatus;
//   }
// }