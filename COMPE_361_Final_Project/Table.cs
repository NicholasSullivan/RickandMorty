using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMPE_361_Final_Project
{
    class Table
    {
        // Gets / Sets data in the Database
        public string Question1 { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string FullQuestion
        {
            get
            {
                return $"{Question1} {Answer1} {Answer2} {Answer3}";
            }
        }
    }
}
