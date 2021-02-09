using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanBlog.Entity
{
    public class Contact
    {
        public int ContactID { get; set; }

        public string ContactFullName { get; set; }
        public string ContactEmail {get;set;}
        public string ContactNumber {get;set;}

        
        public string Message { get; set; }

    }
}
