using MySql.Data.EntityFrameworkCore.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test191218.DataContext
{

    [MySqlCharset("utf8")]
    public class ComplexKey
    {
        
        [MySqlCharset("utf8")]
        public string Key1 { get; set; }
        [MySqlCharset("utf8")]
        public string Key2 { get; set; }
        [MySqlCollation("utf8_general_ci")]
        public string CollationColumn { get; set; }


    }
}
