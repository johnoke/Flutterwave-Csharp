using System;
using System.Collections.Generic;
using Flutterwave.Constants;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
namespace Flutterwave.Utilities
{
    class ApiRequest
    {
        public object Data { get; set; }
        public string Url { get; set; }
        public ApiRequest(string url)
        {
            this.Url = url;
        }
        public async Task<string> MakeRequest(object data = null, List<KeyValuePair<string, string>> headers = null, string method = Verbs.GET)
        {
            var client = new HttpClient();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            client.BaseAddress = new Uri(this.Url);
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            HttpResponseMessage response = null;
            client.Timeout = TimeSpan.FromMinutes(5);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (method.Equals(Verbs.POST))
            {
                response = await client.PostAsJsonAsync(this.Url, data);
            }
            else if(method.Equals(Verbs.GET))
            {
                response = await client.GetAsync(this.Url);
            }
            var httpStatusCode = (int)response.StatusCode;
            if (httpStatusCode == 200 || httpStatusCode == 201 || httpStatusCode == 202)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return await response.Content.ReadAsStringAsync();
        }
    }
}
