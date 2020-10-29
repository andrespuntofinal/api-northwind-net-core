using Northwind.Repositories;
using Northwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DataAccess
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {

        public NorthwindUnitOfWork(string connectionString)
        {

            Customer = new CustomerRepository(connectionString);
            User = new UserRepository(connectionString);
            Supplier = new SupplierRepository(connectionString);
        }
        public ICustomerRepository Customer { get; private set; }

        public IUserRepository User  { get; private set; }

        public ISupplierRepository Supplier { get; private set; }
    }
}
