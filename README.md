This repository was created to fixure CQRS pattern and increase the knowledge of dotnet.

The follow problem describe's what need to do: 
> We want to create a system to maintain data about cities (name, state, website), where each city has one or more restaurants (name, meal price) and hotels (name, daily rate). Additionally, we want to record sold tour packages. To register a tour package, one must choose a city, define the travel date, the lodging hotel, and the number of days of stay. It should also be defined whether the package will include a restaurant or not, and if so, how many meals per day will be included.

**Stack**
- ASP.NET Core 8
- SQL Server
- Sqlite (unity test)
- CRQS
- Github Actions CI
