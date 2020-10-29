using Dapper;
using Northwind.DataAcces;
using Northwind.Models;
using Northwind.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace Northwind.DataAccess
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {

        public CustomerRepository(string connectionstring) : base(connectionstring)
        {


        }

        public IEnumerable<Customer> CustomerPagedList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);

            using (var connection = new SqlConnection(_connectionString))

            {
                return connection.Query<Customer>("dbo.CustomerPagedList",
                                                 parameters,
                                                 commandType: System.Data.CommandType.StoredProcedure);

            }

        }
    }   

  
}
