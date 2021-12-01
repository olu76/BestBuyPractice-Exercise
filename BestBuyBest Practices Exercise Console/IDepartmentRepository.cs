using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBest_Practices_Exercise_Console
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments(); //Stubbed out method


        public void InsertDepartment(string newDepartmentName);

    }
}
