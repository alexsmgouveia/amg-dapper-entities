# amg-dapper-entities
CLI to assist in the generation of .NET entity classes
 
## Features
AMG.Dapper.Entities is an aid in creating entity classes. In the current version it only supports the SQLServer database.

The following platforms have been tested and are supported:
- `Win10 x64`
- `Win10 x86`
 
## Dependences 
`NetCore 3.1` [installing the available version](https://dotnet.microsoft.com/download/dotnet/3.1)

## Getting started
The easiest way to get started is by [installing AMG.DapperEntities.Setup.msi](https://www.nuget.org/packages/PESALEXMapper.Helper) e follow these steps:

#### Install AMG Dapper Entities:
![image](https://user-images.githubusercontent.com/35737565/115893106-3a63c500-a42e-11eb-928e-c91551236fd1.png)

#### Change the environment variables and add the installation path:
<pre>C:\Program Files (x86)\AMG Sistemas\AMG DapperEntities\</pre>

#### Or run the command:
<pre>for /F "tokens=2* delims= " %%f IN ('reg query HKCU\Environment /v PATH ^| findstr /i path') do set OLD_SYSTEM_PATH=%%g
setx PATH "C:\Program Files (x86)\AMG Sistemas\AMG DapperEntities\bin;%OLD_SYSTEM_PATH%"</pre>

#### Open your project:
right-click the project and click `open in terminal`

#### Commands:
<pre>
amg-dapper -h             : Display this help message
amg-dapper --help         : Display this help message
amg-dapper -v             : Display this application version
amg-dapper --version      : Display this application version
amg-dapper config-get     : Display the current configuration on the screen
amg-dapper config-test    : Test the connection of the current configuration
amg-dapper config-install : Creates a new configuration
amg-dapper config-delete  : Deletes the file from the current configuration
amg-dapper entity-create  : Creates the entity class based on table properties
amg-dapper entity-update  : Updates the entity class based on table properties
</pre>

#### File amg-dapper-entities.json:
<pre>
{
  "engine": "SQLSERVER",
  "server": "",
  "database": "",
  "user": "",
  "password": "",
  "schemas": "all",
  "tables": "all",
  "entitynamespace": "YourProject.Domain.Entities",
  "projectsubfolder": "\\Entities"
}
</pre>


## License
This project is licensed under the MIT License - see the [LICENSE.md](https://gist.github.com/hi-hi-ray/LICENSE.md) file for details
