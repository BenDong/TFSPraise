using System.Collections.Generic;
using TFSPraise.Entities;

namespace TFSPraise.Abstract
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
    }
}