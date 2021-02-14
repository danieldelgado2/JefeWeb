﻿using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace Proyecto1.IntegrationTests
{

    public static class ContentHelper
    {
        public static StringContent GetStringContent(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
    }

}
