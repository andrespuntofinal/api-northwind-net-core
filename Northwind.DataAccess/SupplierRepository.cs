using Dapper;
using Northwind.DataAcces;
using Northwind.Models;
using Northwind.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Northwind.DataAccess
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Supplier> SupplierPagedList(int pag, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", pag);
            parameters.Add("@rows", rows);

            using (var connection = new SqlConnection(_connectionString))
            {

                return connection.Query<Supplier>("dbo.SupplierPagedList",
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }

            
        }
    }
}
