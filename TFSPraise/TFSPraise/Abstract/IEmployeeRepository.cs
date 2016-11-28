using System.Collections.Generic;
using TFSPraise.Domains;

namespace TFSPraise.Abstract
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
    }
}