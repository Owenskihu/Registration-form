using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Registration_from
{
    public class Registration
    {
        public int regid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string contactno { get; set; }

        public Registration()
        {
            regid = 0;
            firstname = string.Empty;
            lastname = string.Empty;
            address = string.Empty;
            contactno = string.Empty;
        }
    }
}