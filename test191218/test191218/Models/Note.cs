using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace test191218.Models
{
    public class Note
    {
        [Key]
        public int NoteNo { get; set; }

        [Required(ErrorMessage ="내용 필수임")]
        public string NoteContents { get; set; }

        [Required(ErrorMessage = "제목 필수임")]
        public string NoteTitle { get; set; }

        [Required]
        public int UserNo{ get; set; }


        ///작성자의이름을 가져와야하므로 join 필요 
        [ForeignKey("UserNo")] ///상기 필드 중 UserNo를 foreign key 설정 
        public virtual User User { get; set; }///virtual 로 해당 객체를 레이지 로딩함



    }
}
