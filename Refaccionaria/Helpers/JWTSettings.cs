using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Refaccionaria.Helpers
{
    public class JWTSettings
    {
        public string Secret { get; set; }
    }
}
