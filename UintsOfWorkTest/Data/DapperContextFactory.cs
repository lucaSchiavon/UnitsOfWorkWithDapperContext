using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Transactions;

namespace UintsOfWorkTestWithDapper.Data
{

        public class DapperContextFactory: IDapperContextFactory
    {
            private readonly string _connectionString;

            public DapperContextFactory(string connectionString)
            {
                if (string.IsNullOrWhiteSpace(connectionString))
                    throw new ArgumentException("Connection string cannot be null or empty.", nameof(connectionString));

                _connectionString = connectionString;
            }

            ///// <summary>
            ///// Crea una nuova istanza di DapperContext con transazione aperta.
            ///// </summary>
            ///// <param name="isolationLevel">Livello di isolamento (facoltativo).</param>
            ///// <returns>Istanza di DapperContext</returns>
            //public DapperContext CreateScope2(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
            //{
            //    var connection = new SqlConnection(_connectionString);
            //    connection.Open();

            //    var transaction = connection.BeginTransaction(isolationLevel);

            //    return new DapperContext(transaction);
            //}

            /// <summary>
            /// Crea una nuova istanza di DapperContext con transazione esplicita già fornita.
            /// </summary>
            public IDapperContext CreateScope()
            {
           
                var connection = new SqlConnection(_connectionString);
                connection.Open();

                var transaction = connection.BeginTransaction();

                return new DapperContext(transaction);
            }
        }
    }



