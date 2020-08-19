﻿#if NETCOREAPP3_1
using System.Net.Http;
using System.Net.Http.Headers;

namespace SAEON.Observations.Core
{
    public static class HttpClientExtensions
    {
        public static void SetBearerToken(this HttpClient client, string token)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}
#endif

