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

### API EntityBase for Sub Projects Guide
- Api Controller EntityBase Example
- - Create, Read, Update, Delete
- - Status, Pagination, Pagination Options
- Files & Folders Reference to Create EntityBase
- [EntityBase Example](https://github.com/ahsansoftengineer/sb-admin-dot-net-micro/commit/bf9eea9f6af3c476bd87fab3848e2d6ba3979224)
- [Github Branch](2_API_Example_CRUD_SPO_EntityForAllProjects_Child)

### API EntityCustom for Sub Projects Guide
- Api Controller EntityCustom Example
- - Create, Read, Update, Delete
- - Status, Pagination, Pagination Options
- Customization for Child Entity 
- Files & Folders Reference to Create Child Entity
- [EntityChild Example](https://github.com/ahsansoftengineer/sb-admin-dot-net-micro/commit/c283579a08c0fdeeb9a33331540d3cc5b228d709)



### Copy Paste the Pattern From Hierarchy Project
- Files and Folder 
- Copy _Controllers (For Generic Controller Customization)
- - Contains (BasezContr)
- Copy _DI (To Configure Dependency Injection)
- Copy _Mapping (To Configure Auto Mapper)
- Copy _Data (For Infra Customization)
- - Contains (Context, Seed & UOW_Projectz)

### How to Create a Controller
- It Depends on What you want to Achieve
- If you want to create Simple Entity with following Operations
- - Create, Read, Update, Delete, Status, GetsPaginate, GetsPaginateOptions



#### Simple Controller
#### Mid Simple Entity Controller


### How to Create a Controller Action

