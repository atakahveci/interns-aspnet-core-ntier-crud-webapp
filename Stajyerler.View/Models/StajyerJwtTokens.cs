using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stajyerler.View.Models
{
    public class StajyerJwtTokens
    {
        public const string Issuer = "Stajyerler";
        public const string Audience = "ApiUser";
        public const string Key = "1234567890123456";
        public const string AuthSchemes = 
            "Identity.Application" + "," + JwtBearerDefaults.AuthenticationScheme;
    }
}
