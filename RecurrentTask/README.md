# Problematic
Lately I’ve been enjoying Heroku’s free tier to deploy my app prototypes, because well, it’s free and extremely easy to integrate with continuous-integration services, However, Heroku will put your app to sleep after 30 minutes of inactivity.
While I’m sure Heroku appreciates how this might motivate you to become a paid user, the next hiring manager to view your app probably won’t be impressed when it takes 5–10 seconds to load from a cold boot.

# Solution
If you’re anything like me, you probably don’t want to pay much money or spend time fussing with the setup for your small app or prototype.

So i came up with a simple solution that convince the heroku monitoring system that my app is still running by doing a simple task every period of time ( Recurring Task ) using the [Hangfire](https://www.hangfire.io/) .Net library

# Why Hangfire
Simply because its a very easy way to perform background processing in .NET and .NET Core applications.
- No Windows Service or separate process required.
- Backed by persistent storage. 
- [Open source](https://github.com/HangfireIO/Hangfire) and free for commercial use. 

# Setup
1) We start by Adding the hangfire dependecies, so open your .csproj file and add

        <PackageReference Include="Hangfire.Core" Version="1.7.5" />
        <PackageReference Include="Hangfire.MemoryStorage" Version="1.6.1" />
        <PackageReference Include="Hangfire.AspNetCore" Version="1.7.5" />

2) Open your startup.cs file and in the ConfigureServices methode add a new service

        services.AddHangfire(config =>
        {
           config.UseMemoryStorage();
        });
        
3) In the Configure methode we add a new middleware

        app.UseHangfireServer();
        
4) Also In the Configure methode we create a recurrent task ( ex: every 15 minuts )

        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Started");
            RecurringJob.AddOrUpdate(() => Console.WriteLine("\n I'm Alive \n"), "*/15 * * * *");
        });


<br>

## Notice

- We are using InMemory db, you can switch to SqlServer or any db provider. check the documentation for more details 
- You can change the looping time duration to every hour or day simply by adding the Cron schedule

      RecurringJob.AddOrUpdate(() => Console.WriteLine("Recurring!"),Cron.Daily);

- If you need to show the hangfire local monitoring dashboard, Add this to the middleware pipeline

      app.UseHangfireDashboard();
  And simply navigate to [https://localhost:5000/hangfire](https://localhost:5000/hangfire]) and if everything work fine you should see this UI
  
  ![image](https://user-images.githubusercontent.com/24621701/62485417-90a15800-b7b4-11e9-814d-12f6c948044b.png)
 
- Support me by making a <img src="https://user-images.githubusercontent.com/24621701/44811262-193e6e00-abcc-11e8-8e61-e52d8c78d5c9.png" /> for the repo and thank you :D , If you want to contribute to the project and make it better, your help is very welcome. 
