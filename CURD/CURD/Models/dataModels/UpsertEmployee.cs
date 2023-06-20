namespace CURD.Models.dataModels
{
    public class UpsertEmployee
    {
        public int? EmpId { get; set; }
        public string EmpName { get; set; } = null!;
        public string EmpEmail { get; set; } = null!;
        public long? EmpMobile { get; set; }
        public long? EmpSalary { get; set; }

        public int EmpDeptId { get; set; } 
    }
}
