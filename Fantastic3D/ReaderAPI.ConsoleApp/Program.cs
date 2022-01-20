// See https://aka.ms/new-console-template for more information
using Fantastic3D.Models;
using Fantastic3D.UsersAPI;
using System.Text.Json;

Console.WriteLine("Loading API...");
Console.ReadLine();
var optRequest = new HttpRequestMessage(HttpMethod.Options, "https://localhost:7164/api/User");

var client = new HttpClient();
var optResponse = await client.SendAsync(optRequest);
if (optResponse.IsSuccessStatusCode)
{
    using var responseStream = await optResponse.Content.ReadAsStreamAsync();
    Console.WriteLine(responseStream);
}
else
{
    Console.WriteLine("No OPTIONS on this API.");
}

var getRequest = new HttpRequestMessage(HttpMethod.Get, "https://localhost:7164/api/User/1");
getRequest.Headers.Add("Accept", "application/json");

var response = await client.SendAsync(getRequest);

if (response.IsSuccessStatusCode)
{
    using var responseStream = await response.Content.ReadAsStreamAsync();
    var res = await JsonSerializer.DeserializeAsync
        <UserDto>(responseStream);
    if(res != null)
    { 
        Console.WriteLine("Fetched user : " + res.Name);
    }
}
else
{
    Console.WriteLine("Could not be parseds");
}
Console.ReadLine();