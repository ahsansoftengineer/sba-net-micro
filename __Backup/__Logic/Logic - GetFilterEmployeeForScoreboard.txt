 public async Task<Response> GetFilterEmployeeForScoreboard(EmployeeFilterByConditionModel employeeFilterByConditionModel)
 {
     try
     {
         var processedCondition = await GenerateCondition(employeeFilterByConditionModel?.Condition);
         processedCondition = EnsureProperBracketsWithOR(processedCondition);
         string pattern = @"\b(OR|AND|\s*)\s*!?\(EmployeeId\.Contains\(\""\d+\""\)\)";
         
         processedCondition = Regex.Replace(processedCondition, pattern, "").Trim();
         
         var employeeQuery = _context.Employees.AsNoTracking()
                             .Include(x => x.EmployeePositionLogs).ThenInclude(y => y.Position.Entity.EntityType)
                             .Include(x => x.EmployeeHistoryLifecycles).ThenInclude(y => y.EmployeeHistoryLifecycleDetails)
                             .Include(x => x.EmployeeSkills).ThenInclude(x => x.SkillIset)
                             .Include(x => x.EmployeeFacilityMappings).ThenInclude(x => x.Facility)
                             .Include(x => x.EmployeeLanguages).ThenInclude(x => x.Language)
                             .Include(x => x.EmployeeRoleProfiles).ThenInclude(x => x.RoleProfile)
                             .Include(x => x.Grade.GradeRoleProfiles).ThenInclude(x => x.RoleProfile)
                             .Include(y => y.Position.PositionRoleProfileMappings).ThenInclude(z => z.RoleProfile)
                             .Include(x => x.Entity).ThenInclude(x => x.EntityType)
                             .Include(x => x.EmploymentStage)
                             .Where(x => x.EmployeePositionLogs.Any(log => log.IsActive && (log.Position != null && employeeFilterByConditionModel.Entities.Contains(log.Position.EntityId))));

         var employeeQueryResult = await employeeQuery.Where(cleanedInput).ToListAsync();
         
         var result = employeeQueryResult.Select(x => new
             {
                 Employee = x,
                 ActivePosition = x.EmployeePositionLogs?.FirstOrDefault(log => log.IsActive)?.Position
             })
             //.Where(x => x.ActivePosition != null && employeeFilterByConditionModel.Entities.Contains(x.ActivePosition.Entity.EntityId))
             .Select(x => new EmployeeBasicInfoViewModel
             {
                 EmployeeId = x.Employee.EmployeeId,
                 FirstName = x.Employee.FirstName,
                 LastName = x.Employee.LastName,
                 MiddleName = x.Employee.MiddleName,
                 FullName = x.Employee.FullName,
                 DOB = x.Employee.Dob,
                 GenderId = x.Employee.GenderId,
                 MaritalStatusId = x.Employee.MaritalStatusId,
                 ReligionId = x.Employee.ReligionId,
                 EthnicityId = x.Employee.EthnicityId,
                 NationalityId = x.Employee.NationalityId,
                 NIC = x.Employee.Nic,
                 LandlineNumber = x.Employee.HomeNumber,
                 Email = x.Employee.Email,
                 Address = x.Employee?.Address,
                 EntityId = x.ActivePosition?.Entity?.EntityId,
                 EntityName = x.ActivePosition?.Entity?.Name,
                 GradeCode = x.Employee?.Grade?.GradeCode,
                 PositionName = x.ActivePosition?.PositionCode,
                 EmployeeCode = x.Employee.Code,
             })
             .ToList();

         return SuccessResponse(resultObject: result);
     }
     catch (Exception ex)
     {
         return FaultResponse(ex.Message);
     }
 }
