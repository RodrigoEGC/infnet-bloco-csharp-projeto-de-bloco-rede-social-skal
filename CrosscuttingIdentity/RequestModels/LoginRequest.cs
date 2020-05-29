using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Crosscutting.Identity.RequestModels
{
    public class LoginRequest
    {
        [Required] public string User { get; set; }
        [Required] public string Password { get; set; }
    }
}
