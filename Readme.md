
BeezyBackEndAPI : 
A .Net core application which enables the users (Viewers and Thertre Managers here) to perform multiple functions related to retrieval of movies,documentaries and TV shows.


Running the application :

Ensure that the appsettings.json file contains a valid ConnectionStrings section.It is preconfigured as of now.

Ensure that nuget packages are installed after cloning the project in case of any errors.Follwingerrors.Following packages are used - 

* AutoMapper Version="9.0.0"
* Microsoft.EntityFrameworkCore.Design Version="3.1.3"
* Swashbuckle.AspNetCore Version="5.2.1"
* Swashbuckle.AspNetCore.Swagger Version="5.2.1"
* Swashbuckle.Core Version="5.6.0"
* Newtonsoft.Json Version="12.0.3"
* Microsoft.EntityFrameworkCore Version="3.1.3"
* Microsoft.EntityFrameworkCore.SqlServer Version="3.1.3"
* Microsoft.Extensions.Configuration.Json Version="3.1.3"

A swagger UI will enable the user to enter the input parameters.

![image](https://user-images.githubusercontent.com/60900869/78076020-e65eec00-73a5-11ea-8ec4-20a08417f12a.png)

Controllers :
BeezyBackend.Web\Controllers\TheatreManagersController.cs
BeezyBackend.Web\Controllers\ViewersController.cs

Interfaces:
BeezyBackend.Service.Interfaces

Services project:
BeezyBackend.Service

Repository project  : BeezyBackend.Repository

Entities/EF classes here : BeezyBackend.Data


