### 3) How long did you spend on the coding test? What would you add to your solution if you had more time?
All in all i spent about 4-5 days (on and off) to develop this application. If I had more time I would:
- Use Entity Framework for the data layer.
- Take an actual course on React / Angular to learn best practices and design patterns (I used the bare minimum documentation to develop this).
- Seperate out some more of the front end logic.
- Implement some security within the API layer to ensure only trusted applications could call it.
- Use DTOs to transfer only relevant data (I included an ID propery to the Hotel object as best practice and to help me visualise the number of items in a list).
- Integrate some logging framework, such as Log4Net.

### 4) What was the most useful feature that was added to the latest version of your chosen language?
I used ASP.NET Core v2.2 for the back end. There's a few minor additions from v2.1 so there's not anything I could really "use" in this project - but for the sake of mentioning, v2.2 comes with improved "endpoint routing" - which essentially improves the performance of routing to API endpoints.
More info can be found here: https://rolandguijt.com/endpoint-routing-in-asp-net-core-2-2-explained/

### 5) How would you track down a performance issue in production? Have you ever had to do this?
Some ways I would track performance issues is by using a performance monitor either within Visual Studio's default profiler or something such as Glimpse. This would help me track down how and why particular endpoints or implementations are causing slowdowns - which could range from issues such as memory leaks/GC issues/external service dependants being slow etc..
I've used these tools to track performance issues in my own applications and to help me assess what (and if) something needs fixing or refactoring.
