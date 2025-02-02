// using AutoMapper;
// using GLOB.API.Controllers.Base;
// using GLOB.Apps.Common;
// using GLOB.Domain.DTOs;
// using GLOB.Domain.Entity;
// using Microsoft.AspNetCore.Mvc;

// namespace SBA.Hierarchy.Controllers.Test;
// [Route("api/Hierarchy/Test/[controller]")]
// [ApiController]
// public class TestChildController : BaseController<
//   TestChildController, TestChild, TestChildDtoSearch, TestChildDto, TestChildDtoCreate>
// {
//   public TestChildController(
//     ILogger<TestChildController> logger,
//     IMapper mapper,
//     IUnitOfWorkz unitOfWork) : base(logger, mapper, unitOfWork)
//   {
//     Repo = unitOfWork.TestChilds;

//   }
// }