# amg-dapper-entities
CLI to assist in the generation of .NET entities classes
 
## Features
AMG.Dapper.Entities is an aid in creating entity classes. In the current version it only supports the SQLServer database.

The following platforms have been tested and are supported:
- `Win10 x64`
- `Win10 x86`
 
## Dependences 
`NetCore 3.1` [installing the available version](https://dotnet.microsoft.com/download/dotnet/3.1)

## Getting started
The easiest way to get started is by installing [AMG.DapperEntities.Setup.msi](https://github.com/alexsmgouveia/amg-dapper-entities/raw/master/AMG.DapperEntities.Setup.msi) e follow these steps:

#### Install AMG Dapper Entities:
![image](https://user-images.githubusercontent.com/35737565/115893106-3a63c500-a42e-11eb-928e-c91551236fd1.png)

#### Change the environment variables and add the installation path:
<pre>C:\Program Files (x86)\AMG Sistemas\AMG DapperEntities\bin</pre>

#### Or run registerPath.bat:
<pre>for /F "tokens=2* delims= " %%f IN ('reg query HKCU\Environment /v PATH ^| findstr /i path') do set OLD_SYSTEM_PATH=%%g
setx PATH "C:\Program Files (x86)\AMG Sistemas\AMG DapperEntities\bin;%OLD_SYSTEM_PATH%"</pre>

#### Open your project:
Open project path `in CMD`

![image](https://user-images.githubusercontent.com/35737565/115912441-b584a580-a445-11eb-9fcc-716a619a5c97.png)


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

- **`engine`**: This version only includes "SQLSERVER". The other engines such as "MYSQL" and "POSTGRESQL" will be made available in a new version.
- **`server`**: database server path.
- **`database`**: database name.
- **`user`**:  username.
- **`password`**: connection password.
- **`schemas`**: mapping of the schemas. use "all" for everyone, or enter names separated by commas. Example: "schema1,schema2". 
- **`tables`**: mapping of tables. use "all" for everyone, or enter names separated by commas. Example: "Table1,Table2,Table3".
- **`entitynamespace`**: your entity class namespace.
- **`projectsubfolder`**: folder where the entity classes will be generated.

## License
This project is licensed under the [MIT License](https://github.com/alexsmgouveia/amg-dapper-entities/blob/master/LICENSE).
