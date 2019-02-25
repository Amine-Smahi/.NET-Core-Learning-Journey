using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace WeatherMicroservice {
    public class Startup {
        public void ConfigureServices (IServiceCollection services) { }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.Run (async (context) => {
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
                var latString = context.Request.Query["lat"].FirstOrDefault ();
                var longString = context.Request.Query["long"].FirstOrDefault ();
                var latitude = latString.TryParse ();
                var longitude = longString.TryParse ();
                if (latitude.HasValue && longitude.HasValue) {
                    var forecast = new List<WeatherReport> ();
                    for (var days = 1; days <= 5; days++) {
                        forecast.Add (new WeatherReport (latitude.Value, longitude.Value, days));
                    }
                    var json = JsonConvert.SerializeObject (forecast, Formatting.Indented);
                    context.Response.ContentType = "application/json; charset=utf-8";
                    await context.Response.WriteAsync (json);
                } else {
                    #region WriteResponse
                    await context.Response.WriteAsync ($"Retrieving Weather for lat: {latitude}, long: {longitude}");
                    #endregion
                }
            });
        }
    }
}