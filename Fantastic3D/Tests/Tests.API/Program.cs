// See https://aka.ms/new-console-template for more information
using NBomber.Contracts;
using NBomber.CSharp;
using NBomber.Plugins.Http.CSharp;

Console.WriteLine("Hello, World!");

var httpFactory = HttpClientFactory.Create();

var step = Step.Create("step", clientFactory: httpFactory, execute: async context =>
{ 
   var request =
                        Http.CreateRequest("GET", "https://localhost:7164/api/User")
                            .WithHeader("Accept", "text/html")
                            .WithCheck(async (response) =>
                                response.IsSuccessStatusCode
                                    ? Response.Ok()
                                    : Response.Fail()
                            );

    var response = await Http.Send(request, context);
    return response;
});
var scenario = ScenarioBuilder.CreateScenario("scenario", step)
    .WithLoadSimulations(Simulation.RampConstant(1000, TimeSpan.FromSeconds(50))); ;

NBomberRunner
    .RegisterScenarios(scenario)
    .Run();
Console.WriteLine();