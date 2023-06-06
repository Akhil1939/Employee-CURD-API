using System;
using System.Collections.Generic;

namespace CURD.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; } = null!;
        public string EmpEmail { get; set; } = null!;
        public long? EmpMobile { get; set; }
        public long? EmpSalary { get; set; }
        public int EmpDeptId { get; set; }

        public virtual Department EmpDept { get; set; } = null!;
    }
}
