using Northwind.Models;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Repositories
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        IEnumerable<Customer> CustomerPagedList(int pag, int rows);

    }
}
