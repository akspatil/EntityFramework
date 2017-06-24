using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class StudentEntity
    {
        public long StudentId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Suburb { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public int EnrolledHours { get; set; } = 0;
    }
}
