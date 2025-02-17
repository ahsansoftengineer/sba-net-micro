### DOCKER SQL
```bash
docker pull mcr.microsoft.com/mssql/server:2022-latest
docker image ls
docker run -e 'HOMEBREW_NO_ENV_FILTERING=1' -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=P@55w0rd!123' -p 1430:1433 -d mcr.microsoft.com/mssql/server:2022-latest
docker container ls
docker ps
```

### UBUNTU DOTNET INSTALLATION
```bash
# Add Microsoft package repository
wget https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

# Update package list and install .NET SDK
sudo apt-get update
sudo apt-get install -y dotnet-sdk-8.0

# Verify .NET installation
dotnet --list-sdks
dotnet --list-runtimes
```
### Tools (EF)
```bash
# Add SDK and Tools path to the environment (for Bash)
echo 'export DOTNET_ROOT=/usr/share/dotnet' >> ~/.bashrc
echo 'export PATH=$PATH:$DOTNET_ROOT' >> ~/.bashrc
echo 'export PATH=$PATH:$HOME/.dotnet/tools' >> ~/.bashrc
source ~/.bashrc

# Add SDK and Tools path to the environment (for Zsh)
echo 'export DOTNET_ROOT=/usr/share/dotnet' >> ~/.zshrc
echo 'export PATH=$PATH:$DOTNET_ROOT' >> ~/.zshrc
echo 'export PATH=$PATH:$HOME/.dotnet/tools' >> ~/.zshrc
source ~/.zshrc

# Verify environment configuration
echo $DOTNET_ROOT
echo $PATH

# Reinstall dotnet-ef tool
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef

# Verify dotnet-ef tool installation
dotnet ef

```

### UBUNTU UNINSTALL DOTNET 
```bash
# List installed SDKs and runtimes
dotnet --list-sdks
dotnet --list-runtimes

# Remove .NET SDKs and runtimes
sudo apt-get remove --purge dotnet-sdk-8.0
sudo apt-get remove --purge dotnet-runtime-8.0
sudo apt-get remove --purge aspnetcore-runtime-8.0

# Remove global tools
dotnet tool uninstall --global dotnet-ef

# Remove remaining files and directories
sudo rm -rf /usr/share/dotnet
sudo rm -rf ~/.dotnet
sudo rm -rf ~/.nuget

# Update package list and clean up
sudo apt-get update
sudo apt-get autoremove
sudo apt-get clean

```


### EF TOOLS
```bash
dotnet tool install --global dotnet-ef
dotnet tool list --global
```