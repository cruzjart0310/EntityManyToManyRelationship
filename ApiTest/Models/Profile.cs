using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class Profile
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Profile is required")]
        public string Nickname { get; set; }
        public string Avatar { get; set; }
    }
}
