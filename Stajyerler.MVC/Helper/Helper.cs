using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Stajyerler.MVC.Helper
{
    public class StajyerAPI
    {
        public HttpClient initial() {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44327/");
            return client;
        }

    }
}
