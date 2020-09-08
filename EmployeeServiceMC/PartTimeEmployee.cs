using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeServiceMC
{
    public class PartTimeEmployee:Employee
    {
        public int HoursWorked { get; set; }

        public int HourlyPay { get; set; }
    }
}
