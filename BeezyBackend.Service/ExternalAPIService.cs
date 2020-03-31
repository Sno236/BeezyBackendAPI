using BeezyBackend.Repository.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeezyBackend.Service
{
    public static class ExternalAPIService
    {
        private static string GetEndpointDataFromConfig(string connectionString, int isPaging)
        {
            string apiConn = new APIConfiguration().GetEndpointDataFromConfig(connectionString);
            if (isPaging == 0)
                return apiConn;
            else
                return apiConn.Replace("", isPaging.ToString());
        }

        public static async Task<T> GetSpecifiedListFromMovieWebAPI<T>(string connectionString, int isPaging)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(GetEndpointDataFromConfig(connectionString, isPaging)).ConfigureAwait(continueOnCapturedContext: false); ;
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<T>(json);
                    return model;
                }
                return default(T);
            }
        }



        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            NullValueHandling = NullValueHandling.Ignore,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
