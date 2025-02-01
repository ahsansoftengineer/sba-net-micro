// using AutoMapper;
// using GLOB.API.Controllers.Base;
// using GLOB.Apps.Common;
// using GLOB.Domain.Entity;
// using Microsoft.AspNetCore.Mvc;

// namespace GLOB.API.Controllers.Test;
// [Route("api/Test/[controller]")]
// [ApiController]
// public class TestParentController : CommonController<TestParentController, TestParent>
// {
//   public TestParentController(
//     ILogger<TestParentController> logger,
//     IMapper mapper,
//     IUnitOfWorkz unitOfWork) : base(logger, mapper, unitOfWork)
//   {
//     Repo = unitOfWork.TestParents;

//   }
// }