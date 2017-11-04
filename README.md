# Angular CLI ASP.NET Core

> Angular CLI & ASP.NET Core WebAPI in the same project. AoT compilation in development & production mode, and small bundles.

Get the [Changelog](https://github.com/robisim74/AngularCliAspNetCore/blob/master/CHANGELOG.md).

## Features
- Angular v5 & ASP.NET Core 2
- Angular CLI
- AoT compilation in development & production mode
- Angular CLI, .NET Core CLI or Visual Studio 2017
- Angular Material
- Dotnet watch
- Debugging
- Path Location Strategy
- Hot Module Replacement

## Project structure
**AngularCliAspNetCore**
- **Controllers**
	- **ValuesController.cs** _Resource API_
- **Properties**
	- **lanchSettings.json** _ASP.NET Core environments_
- **src** _Angular application_
- **wwwroot** _Root for Angular application deployment_
- **.angular-cli.json** _Angular CLI configuration_
- **package.json** _Packages for Angular app_
- **proxy.config.json** _Proxy configuration for ng serve command_
- **Startup.cs** _Web API configuration_

## Installing
- Requirements
	- [.NET Core 2.0](https://www.microsoft.com/net/download/core)
	- [Node.js and npm](https://docs.npmjs.com/getting-started/installing-node)
    - [Angular CLI](https://github.com/angular/angular-cli)

#### Command line & .NET Core CLI
- `npm install`
- Restore & build the solution:
	```Shell
	dotnet restore
	dotnet build
	```
#### Visual Studio 2017
- Make sure your configuration for external tools is correct:
	_Tools_ > _Options_ > _Projects and Solutions_ > _Web Package Management_ > _External Web Tools_
	```
	.\node_modules\.bin
	$(PATH)
	...
	```
- Wait for packages restoring and build the solution
- To run _npm_ commands in Visual Studio you can use [NPM Task Runner](https://marketplace.visualstudio.com/items?itemName=MadsKristensen.NPMTaskRunner) extension

## Running

### Command line & .NET Core CLI

#### Development
- Set _Development_ as environment variable: [Working with multiple environments](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments)
- `dotnet watch run`

Make the changes to the controllers or to the Angular app: the browser will update without refreshing.

#### Staging / Production
- `npm run build`
- Set _Staging_ as environment variable: [Working with multiple environments](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments)
- `dotnet run --no-launch-profile`

### Visual Studio 2017

#### Development
- Select _AngularCliAspNetCore_Dev_ profile
- Start debugging
- Wait for building

Make the changes to the Angular app: the browser will update without refreshing.

#### Staging / Production
- `npm run build`
- Select _AngularCliAspNetCore_Prod_ profile
- Start debugging

## Credits
- [Integrating ASP.Net Core 2.0 and Angular 4 projects using CLI and Visual Studio Code](https://www.codeproject.com/Articles/1206306/Integrating-ASP-Net-Core-and-Angular-project)
- [How to build an Angular Application with ASP.NET Core in Visual Studio 2017](https://medium.com/@levifuller/building-an-angular-application-with-asp-net-core-in-visual-studio-2017-visualized-f4b163830eaa)
- [Live Reloading Angular Application with ASP.NET Core in Visual Studio 2017](https://medium.com/@faisalmuhammad/live-reloading-angular-application-with-asp-net-core-in-visual-studio-2017-957619f31008)

## License
MIT
