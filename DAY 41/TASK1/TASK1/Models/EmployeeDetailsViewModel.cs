using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TASK1.Models
{
    public class EmployeeDetailsViewModel
    {
        public Employee employee { get; set; }
        public Department department { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }

    }
}
