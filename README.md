# Introduction
### The aim of the current project is to explore some of the new features brought by .NET 5
###### Project Net5Api
This is a basic ASP.NET Web API project that provide two controller: the built-in controller WeatherForecast and a new controller NewsFeed that use a json file to display an example of a news feed.<br />
The main pourpose of this project is to expose some data and to display the new integration between ASP.NET Core and Swagger.<br />
Starting with .NET 5 the ASP.NET Core API template contains a built-in support for OpenApi and Swagger.<br /> 
So, when you start a new Core API project you have the Swashbuckle package already included with some default settings (check the Configure method in Startup.cs).<br />
Having OpenApi enabled for an API project will offer an opportunity to automatically import the APIs into Azure API Management via Visual studio publish flow.<br />

###### Net5Console
This is a console application whose purpose is to explore some new feature brought by C# 9.0 and in detail:
1) Top Level Calls (see the comment on the top of Program.cs).
2) Initial setter: a new mechanisms for building immutable data.
3) Target-typed New Expressions
4) Relational pattern improvements
5) Logical pattern matching in switch expression
6) Records

# Execute the demo
1) Open the solution with Visual Studio.
2) Right click on the solution, then click on properties. From Startup Project select Multiple startup project
3) Press ctrl + f5