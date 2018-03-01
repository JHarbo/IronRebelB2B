using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Options;
using IronRebelB2B.Models;

namespace IronRebelB2B.Services
{
    public class BaseService
    {
        private readonly ShopifyCredentials _creds;
        public BaseService(ShopifyCredentials creds)
        {
            _creds = creds;
        }
        public HttpClientHandler GetAuthHandle()
        {
            return new HttpClientHandler
            {
                Credentials = new NetworkCredential(_creds.API_KEY, _creds.PASSWORD),
                PreAuthenticate = true
            };
        }

        public string GetUrl()
        {
            return $@"https://{_creds.HOSTNAME}";
        }
    }
}
