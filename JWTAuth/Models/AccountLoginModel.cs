using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JWTAuth.Models
{
    public class AccountLoginModel
    {
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string Email { get; set; }
        public string RememberMe { get; set; }


    }
}