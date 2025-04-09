### Docs EntityShort
- Short Entity Recomended for (Enums, Constants)
- Every Database Will have EntityShort & EntityShortParent (Microservice Recommended)
- All Projects Can have Centeral EntityShort & EntityShortParent

### EntityShortParent
- To Categorize the ShortEntity of Different Types of Entity (Gender [Male, Female]), (Status [Active, Disable]), etc..
### EntityShort
- 
1. The Short Entity Should not Depend on Other Entity
2. Other Entities can Depend on Short Entity (Employee, Etc)
3. If The Entity Has the Fixed Size wont Change in the Years (Use Short Entity)
4. Cache the Short Entity By Parent On the Following Routes

### Example
```text
EntityShort/Gender/
EntityShort/Status/
EntityShort/StatusPayment/
EntityShort/StatusOrder/
```