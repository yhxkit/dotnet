using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test191218.ModelsForView
{
    public class LoginUserModel
    {
        [Required(ErrorMessage = "ID 필수임")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "비번 필수임")]
        public string UserPassword { get; set; }
    }
}
