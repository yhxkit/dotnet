using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace test191218.Models
{
    public class User
    {
        [Key]
        public int UserNo { get; set; }

        [Required(ErrorMessage ="이름 필수입니다")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "아이디 필수입니다")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "비번 필수입니다")]
        public string UserPassword { get; set; }
    }
}
