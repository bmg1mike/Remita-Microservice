using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models.Auth
{
    public class TokenResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<Data> data { get; set; }
    }
    public class Data
    {
        public string accessToken { get; set; }
        public int expiresIn { get; set; }
    }
}