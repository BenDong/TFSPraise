using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFSPraise.Abstract;
using TFSPraise.Domains;

namespace TFSPraise.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        TFSPraiseContext context = new TFSPraiseContext();
        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;
        }
    }
}