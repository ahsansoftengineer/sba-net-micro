### How to Create a Microservice
```bash
dotnet new webapi -o SBA.Auth
dotnet sln add SBA.ProjectName/SBA.ProjectName.csproj
# dotnet add ./GLOB.API/ reference ./GLOB.Infra/ # Comming from GLOB.API Project
dotnet add ./SBA.Auth/ reference ./GLOB.API/
```
### Arch
- All the Underscore Folder has meaning (_) Indicating Part of Archetecture
- Reserve Keywords / Special Meaning Keywords (Alpha, Base, Beta, Common), (Primary, Secondary), (Projectz)
- 
- 

### Copy Paste the Pattern From Hierarchy Project
- Copy _Controllers (For Generic Controller Customization)
- - Contains (BasezContr)
- Copy _DI (To Configure Dependency Injection)
- Copy _Mapping (To Configure Auto Mapper)
- Copy _Data (For Infra Customization)
- - Contains (Context, Seed & UOW)

### How to Create a Controller
- It Depends on What you want to Achieve
- If you want to create Simple Entity with following Operations
- - Create, Read, Update, Delete, Status, GetsPaginate, GetsPaginateOptions



#### Simple Controller
#### Mid Simple Entity Controller


### How to Create a Controller Action

