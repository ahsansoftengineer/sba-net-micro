### RUNNING PROJECTS
```bash
# dotnet run --project ./SBA.Api/
                                                # http, https
dotnet watch run --launch-profile https --project ./SBA.APIGateway/    # 5800 5801
dotnet watch run --launch-profile https --project ./SBA.Auth/          # 5802 5803
dotnet watch run --launch-profile https --project ./SBA.Hierarchy/     # 5806 5807
dotnet watch run --launch-profile https --project ./SBA.Jobz/          # 5804 5805
dotnet watch run --launch-profile https --project ./SBA.Userz/         # 5808 5809
dotnet watch run --launch-profile https --project ./SBA.Orderz/        # 5810 5011
```


#### USER SECRETS
```bash 
dotnet user-secrets init --project ./SBA.Api/
dotnet user-secrets set --project ./SBA.Api/ "JwtSettings:Secret" "super-secret-key-from-user-secrets"
dotnet user-secrets list --project ./SBA.Api/
```

### GIT
```bash
start . # OPENING FOLDER EXPLORER USING CLI

dotnet new gitignore
git init
git push --set-upstream origin BranchNameHere
git remote set-url stream https://gitlab.com/starbazaar/admin-panel.git
git remote add stream https://gitlab.com/starbazaar/webapp.git
git remote -v
origin  https://gitlab.com/m.ahsan.saifi/webapp.git (fetch)
origin  https://gitlab.com/m.ahsan.saifi/webapp.git (push)
stream  https://gitlab.com/starbazaar/webapp.git (fetch)
stream  https://gitlab.com/starbazaar/webapp.git (push)
dotnet new editorconfig
```
