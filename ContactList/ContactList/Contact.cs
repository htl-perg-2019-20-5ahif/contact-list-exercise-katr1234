using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList
{
    public class Contact
    {
        [Required]
        public Int32 id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        [Required]
        public string email { get; set; }
    }
}
