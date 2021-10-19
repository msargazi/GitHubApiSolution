using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Settings
{
    public class ApiSettings : IApiSettings
    {
        public string BaseAddress { get; set; }
        public string UserPath { get; set; }
    }
}
