BeezyBackEndAPI : 
A .Net core application which enables the users (Viewers and Thertre Managers here) to perform multiple functions related to retrieval of movies,documentaries and TV shows.

Running the application :
1) Ensure that the appsettings.json file contains a valid ConnectionStrings section.It is preconfigured as of now.
2) Ensure that nuget packeges are installed after cloning the project in case of any errors.Follwing packages are used -
    <PackageReference Include="AutoMapper" Version="9.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="3.1.3">
    <PackageReference Include="Swashbuckle.AspNetCore" Version="5.2.1" />
    <PackageReference Include="Swashbuckle.AspNetCore.Swagger" Version="5.2.1" />
    <PackageReference Include="Swashbuckle.Core" Version="5.6.0" />
    <PackageReference Include="Newtonsoft.Json" Version="12.0.3" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="3.1.3" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.3" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="3.1.3" />
  
3) A swagger UI will enable the user to enter the input parameters.



