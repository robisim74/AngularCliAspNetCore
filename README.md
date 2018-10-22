# Angular CLI ASP.NET Core

> Angular CLI & ASP.NET Core WebAPI in the same project. Angular AoT compilation in development & production mode.

Get the [Changelog](https://github.com/robisim74/AngularCliAspNetCore/blob/master/CHANGELOG.md).

## Features
- Angular v7 & ASP.NET Core 2.1
- Angular CLI
- AoT compilation in development & production mode
- Angular CLI, .NET Core CLI or Visual Studio 2017
- Angular Material

## Project structure
**AngularCliAspNetCore**
- **Controllers**
	- **ValuesController.cs** _Resource API_
- **Properties**
	- **lanchSettings.json** _ASP.NET Core environments_
- **ClientApp** _Angular application_
- **wwwroot** _Root for Angular application deployment_
- **Startup.cs** _WebAPI configuration_

## Installing
- Requirements
	- At least [.NET Core 2.1](https://www.microsoft.com/net/download/core)
	- [Node.js and npm](https://nodejs.org)
    - At least [Angular CLI 7.0.0](https://github.com/angular/angular-cli)

#### Command line & .NET Core CLI
- In _ClientApp_ folder run: `npm install`
- `dotnet build`

#### Visual Studio 2017
- In _ClientApp_ folder run: `npm install`
- Build the solution

## Running
The app will be served on `https://localhost:5001`

### Command line & .NET Core CLI
#### Development
- `dotnet watch run`

#### Staging
- In _ClientApp_ folder run: `npm run build`
- `dotnet run --launch-profile Staging`

### Visual Studio 2017
#### Development
- Select _AngularCliAspNetCore_ profile
- Start debugging

#### Staging
- In _ClientApp_ folder run: `npm run build`
- Select _Staging_ profile
- Start debugging

## Start from scratch
- Create the ASP.NET Core WebAPI:
```Shell
dotnet new webapi -o AngularCliAspNetCore
```
- Create the Angular app:
```Shell
cd AngularCliAspNetCore
ng new --skipGit=true ClientApp
```
- Open `angular.json` file and set the `outputPath`:
```Shell
"outputPath": "../wwwroot"
```
- Open `package.json` file and set the following scripts:
```Json
"start": "ng serve --aot",
"build": "ng build --prod",
```
- Open `Startup.cs` file and add to the `ConfigureServices` method:
```C#
services.AddSpaStaticFiles(configuration =>
{
	if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
	{
		configuration.RootPath = "ClientApp/dist/ClientApp";
	}
	else
	{
		configuration.RootPath = "wwwroot";
	}
});
```
and to `Configure` method:
```C#
app.UseStaticFiles();
app.UseSpaStaticFiles();

app.UseMvc(routes =>
{
	routes.MapRoute(
		name: "default",
		template: "{controller}/{action=Index}/{id?}");
});

app.UseSpa(spa =>
{
	spa.Options.SourcePath = "ClientApp";

	if (env.IsDevelopment())
	{
		spa.UseAngularCliServer(npmScript: "start");
	}
});
```
- Open [launchSettings.json](https://github.com/robisim74/AngularCliAspNetCore/blob/master/Properties/launchSettings.json) file and update the environments.

For other features, refer to the repository.

## License
MIT
