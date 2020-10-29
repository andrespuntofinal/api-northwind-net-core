using Northwind.Models;
using System.Collections.Generic;

namespace Northwind.Repositories
{
    public interface ISupplierRepository:IRepository<Supplier>
    {

        IEnumerable<Supplier> SupplierPagedList(int pag, int rows);

    }
}
