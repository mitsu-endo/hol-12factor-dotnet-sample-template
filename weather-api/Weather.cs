using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace WeatherApi;
public static class Weather
{
    [FunctionName("weather")]
    [OpenApiOperation(operationId: "GetCityWeather", tags: new[] { "weather" }, Summary = "町の天気情報を返します。", Description = "町の天気情報を返します。", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiParameter(name: "city", In = ParameterLocation.Path, Required = false, Type = typeof(string), Summary = "city", Description = "町の名前", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "Success")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "weather/{city}")] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        var weather = new
        {
            temperature = "+2 ℃",
            wind = "62 km/h",
            description = "Sunny",
            forecast = new List<object>
            {
                new { day = "1", temperature = "-6 ℃", wind = "63 km/h" },
                new { day = "2", temperature = "1 ℃", wind = "64 km/h" },
                new { day = "3", temperature = "+10 ℃", wind = "42 km/h" }
            }
        };

        return new OkObjectResult(weather);
    }
}
