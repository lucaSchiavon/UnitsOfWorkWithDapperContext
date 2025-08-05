namespace UintsOfWorkTestWithDapper.Data
{

    using Dapper;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using IsolationLevel = System.Data.IsolationLevel;

   
        /// <summary>
        /// DapperContext: contesto di esecuzione del dal di Dapper legato ad una singola connessione-transazione.
        /// Responsabile del ciclo di vita del context manager, della connection interna e transaction interna (si occupa del dispose di questi elementi).
        /// </summary>
        public class DapperContext : IDapperContext //, IInternalContext
    {
            private bool isReadOnly;
            /// <summary>Valore precedente del context manager del bool IsReadOnly, serve per il ripristino in caso di nested context</summary>
            //private bool? previousContextReadOnlyInfo;

            /// <summary>Valore precedente del context manager del TableNameResolverMode, serve per il ripristino in caso di nested context</summary>
            //private TableNameResolverMode? previousTableResolverMode;
            //private IsolationLevel? isolationLevel;

            internal DbConnection InternalConnection;
            internal DbTransaction InternalTransaction;
            /// <summary>Internal context cmanager</summary>
            //protected internal IContextManager InternalContextManager;
            /// <summary>True if the transaction is completed, false otherwise</summary>
            public bool IsTransactionCompleted { get; protected set; }

            /// <inheritdoc />
            //public bool IsReadOnly => isReadOnly;

            /// <inheritdoc />
            //public IsolationLevel? ContextIsolationLevel => isolationLevel;

            /// <summary>True if the object is disposed, false otherwise (used by internal dispose)</summary>
            protected bool IsDisposed;
            /// <summary>True if there is no transaction associted with the context (no transaction scope), false otherwise</summary>
            protected bool IsTransactionLess;
            /// <summary>True if the context is nested (created from other parent context), false otherwise</summary>
            protected internal bool IsNestedContext;
            /// <summary>Database server process id (SPID)</summary>
            //protected int ServerProcessId;
            /// <summary>Database server name property</summary>
            //protected string ServerName;
            /// <summary>Database user name property</summary>
            //protected string UserName;
        //internal SimpleCRUD InternalSimpleCRUD;
        ///// <inheritdoc />
        //bool IInternalContext.IsTransactionLessInternal { get { return IsTransactionLess; } }
        ///// <inheritdoc />
        //bool IInternalContext.IsDisposedInternal { get { return IsDisposed; } }
        /// <inheritdoc />
        //void IInternalContext.SetReadOnlyInfo(bool readOnly)
        //{
        //    if (readOnly != this.isReadOnly && IsNestedContext)
        //    {
        //        //se cambio valore rispetto a quanto impostato nel ctor lo mantengo e notifico al context manager
        //        //utile per simulare il read only nelle fixture
        //        previousContextReadOnlyInfo = this.isReadOnly;
        //        ((ContextManager)this.InternalContextManager).SetReadOnly(readOnly);
        //    }
        //    this.isReadOnly = readOnly;
        //}
        /// <inheritdoc />
        //public void SetIsolationLevelInfo(IsolationLevel? isolation)
        //{
        //    this.isolationLevel = isolation;
        //}

        /// <summary>Internal set</summary>
        //void IInternalContext.SetTableNameResolver(TableNameResolverMode tableResolverMode)
        //{
        //    if (tableResolverMode != this.InternalContextManager.TableNameResolverMode && IsNestedContext)
        //    {
        //        //se cambio valore rispetto a quanto impostato nel ctor lo mantengo e notifico al context manager
        //        //utile per simulare il read only nelle fixture
        //        previousTableResolverMode = this.InternalContextManager.TableNameResolverMode;
        //        ((ContextManager)this.InternalContextManager).SetTableNameResolver(tableResolverMode);
        //    }
        //    //applico il valore del context manager al contesto
        //    SetResolver();
        //}

        internal DapperContext(DbConnection connection)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));

            this.InternalConnection = connection;
            this.InternalTransaction = null;
            //this.InternalContextManager = internalContextManager;
            //this.InternalSimpleCRUD = new SimpleCRUD();
            //SetResolver();

            //this.isReadOnly = InternalContextManager.IsReadOnly;
            //this.isolationLevel = InternalContextManager.IsolationLevel;
            //this.IsDisposed = false;
            //this.IsTransactionCompleted = false;
            //this.IsTransactionLess = true;
            //((ContextManager)this.InternalContextManager).IgnoreCmdStatistics = true;
            //var info = RetrieveServerInformation();
            //((ContextManager)this.InternalContextManager).IgnoreCmdStatistics = false;
            //this.ServerProcessId = info.Spid;
            //this.ServerName = info.ServerName;
            //this.UserName = info.UserName;
            //((ContextManager)this.InternalContextManager).SetServerInfo(this.ServerProcessId, this.ServerName);
        }

        internal DapperContext(DbTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));

            this.InternalConnection = transaction.Connection;
            this.InternalTransaction = transaction;
            //this.InternalContextManager = internalContextManager;
            //this.InternalSimpleCRUD = new SimpleCRUD();
            //SetResolver();

            //this.isReadOnly = InternalContextManager.IsReadOnly;
            //this.isolationLevel = InternalContextManager.IsolationLevel;
            //this.IsDisposed = false;
            //this.IsTransactionCompleted = false;
            //this.IsTransactionLess = false;
            //((ContextManager)this.InternalContextManager).IgnoreCmdStatistics = true;
            //var info = RetrieveServerInformation();
            //((ContextManager)this.InternalContextManager).IgnoreCmdStatistics = false;
            //this.ServerProcessId = info.Spid;
            //this.ServerName = info.ServerName;
            //this.UserName = info.UserName;
            //((ContextManager)this.InternalContextManager).SetServerInfo(this.ServerProcessId, this.ServerName);
        }

        //internal DapperContext(DapperContext parentContext, bool isScopeLess)
        //{
        //    if (parentContext == null) throw new ArgumentNullException(nameof(parentContext));
        //    //poi quando si fa rollback o commit si rimette il valore precedetente
        //    this.InternalConnection = parentContext.InternalConnection;
        //    this.InternalTransaction = parentContext.InternalTransaction;
        //    this.InternalContextManager = parentContext.InternalContextManager;
        //    this.InternalSimpleCRUD = new SimpleCRUD();
        //    SetResolver();

        //    this.isReadOnly = parentContext.IsReadOnly;
        //    this.isolationLevel = parentContext.ContextIsolationLevel;
        //    this.IsDisposed = false;
        //    this.IsTransactionCompleted = false;
        //    this.IsTransactionLess = isScopeLess;
        //    this.IsNestedContext = true;
        //    this.ServerProcessId = parentContext.ServerProcessId;
        //    this.ServerName = parentContext.ServerName;
        //}



        ///// <inheritdoc />
        //public IDbConnection Connection
        //{
        //    get
        //    {
        //        return this.InternalConnection;
        //    }
        //}



        ///// <inheritdoc />
        //public IDbTransaction Transaction
        //{
        //    get
        //    {
        //        return this.InternalTransaction;
        //    }
        //}





        internal class ServerInformation
            {
                internal int Spid { get; set; }
                internal string ServerName { get; set; }
                internal string UserName { get; set; }
            }

            /// <summary>retrieve @@SPID server value from database</summary>
            /// <returns></returns>
            //private ServerInformation RetrieveServerInformation()
            //{
            //    if (this.InternalConnection == null || this.InternalConnection.State != ConnectionState.Open)
            //        return new ServerInformation();

            //    ServerInformation info = QuerySingleOrDefault<ServerInformation>("SELECT @@SPID AS Spid, @@SERVERNAME AS ServerName, SYSTEM_USER AS UserName");
            //    return info;
            //}

            /// <summary>retrieve @@SPID server value from database</summary>
            /// <returns></returns>
            //protected int RetrieveServerProcessId()
            //{
            //    if (this.InternalConnection == null || this.InternalConnection.State != ConnectionState.Open)
            //        return -1;

            //    int sqlProcessId = ExecuteScalar<short>("SELECT @@SPID");
            //    return sqlProcessId;
            //}

            /// <summary>retrieve @@SERVERNAME server value from database</summary>
            /// <returns></returns>
            //protected string RetrieveServerName()
            //{
            //    if (this.InternalConnection == null || this.InternalConnection.State != ConnectionState.Open)
            //        return null;

            //    string serverName = ExecuteScalar<string>("SELECT @@SERVERNAME");
            //    return serverName;
            //}

            /// <summary>retrieve SYSTEM_USER value from database</summary>
            /// <returns></returns>
            //protected string RetrieveUserName()
            //{
            //    if (this.InternalConnection == null || this.InternalConnection.State != ConnectionState.Open)
            //        return null;

            //    string userName = ExecuteScalar<string>("SELECT SYSTEM_USER");
            //    return userName;
            //}

            /// <inheritdoc />
            //public void UseDatabase(string dbName)
            //{
            //    Execute($"USE [{dbName}]");
            //}

        ///// <summary>Retrieve table name of an entity using current context resolver.</summary>
        ///// <param name="entity">The entity type</param>
        ///// <returns>The table name with brackets []</returns>
        //public string GetTableName(Type entity)
        //{
        //    return this.InternalSimpleCRUD.GetTableName(entity);
        //}

        ///// <summary>Retrieve table name of an entity using current context resolver.</summary>
        ///// <typeparam name="T">The entity type</typeparam>
        ///// <returns>The table name with brackets []</returns>
        //public string GetTableName<T>()
        //{
        //    return this.InternalSimpleCRUD.GetTableName(typeof(T));
        //}

        /// <summary>Begin internal transaction</summary>
        /// <param name="isolationLevelInfo"></param>
        //protected void BeginTransaction(IsolationLevel isolationLevelInfo)
        //    {
        //        this.InternalTransaction = this.InternalConnection.BeginTransaction(isolationLevelInfo);
        //        this.IsTransactionLess = false;
        //        this.IsTransactionCompleted = false;
        //    }


            /// <inheritdoc />
            public virtual void Commit()
            {
            //if (this.IsTransactionLess)
            //    throw new ContextTransactionException("Context has been created without transaction, cannot call commit.");
            //if (this.InternalTransaction == null)
            //    throw new ContextTransactionException("Internal transaction is null, cannot commit.");
            //if (this.InternalTransaction.Connection == null)
            //    throw new ContextTransactionException("Internal connection linked to transaction is null, cannot commit.");
            //if (this.InternalConnection == null)
            //    throw new ContextTransactionException("Internal connection is null, cannot commit.");
            //if (this.InternalConnection.State != ConnectionState.Open)
            //    throw new ContextTransactionException("Internal connection is already closed, cannot commit.");
            //if (this.IsTransactionCompleted)
            //    throw new ContextTransactionException("Internal transaction is already completed, cannot commit.");

            try
                {
                    this.InternalTransaction.Commit();
                    if (!this.IsNestedContext) //non si chiude la connection in un contesto annidato
                    {
                        this.InternalConnection.Close();
                    }
                }
                finally
                {
                    this.IsTransactionCompleted = true;
                }
            }

            /// <inheritdoc />
            public virtual void Rollback()
            {
                //if (this.IsTransactionLess)
                //    throw new ContextTransactionException("Context has been created without transaction, cannot call rollback.");

                if (!this.IsTransactionCompleted && this.InternalTransaction != null && this.InternalConnection != null &&
                    this.InternalConnection.State == ConnectionState.Open)
                {
                    try
                    {
                        this.InternalTransaction.Rollback();
                        if (!this.IsNestedContext) //non si chiude la connection in un contesto annidato
                        {
                            this.InternalConnection.Close();
                        }
                    }
                    finally
                    {
                        this.IsTransactionCompleted = true;
                    }
                }
            }


        /// <inheritdoc />
        public T QueryFirstOrDefault<T>(string sql, object param = null, int? commandTimeout = null)
        {
            var result = this.InternalConnection.QueryFirstOrDefault<T>(sql, param, this.InternalTransaction, commandTimeout);
            if (Debugger.IsAttached)
                Trace.WriteLine($"QueryFirstOrDefault: {sql}");
            return result;
        }

        /// <inheritdoc />
        public T QuerySingleOrDefault<T>(string sql, object param = null, int? commandTimeout = null)
        {
            var result = this.InternalConnection.QuerySingleOrDefault<T>(sql, param, this.InternalTransaction, commandTimeout);
            if (Debugger.IsAttached)
                Trace.WriteLine($"QuerySingleOrDefault: {sql}");
            return result;
        }

        /// <inheritdoc />
        public IReadOnlyList<dynamic> Query(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var result = this.InternalConnection.Query(sql, param, this.InternalTransaction, true, commandTimeout, commandType).AsList();
            if (Debugger.IsAttached)
                Trace.WriteLine($"Query: {sql}");
            return result;
        }

        /// <inheritdoc />
        public IList<T> Query<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var result = this.InternalConnection.Query<T>(sql, param, this.InternalTransaction, true, commandTimeout, commandType).AsList();
            if (Debugger.IsAttached)
                Trace.WriteLine($"Query: {sql}");
            return result;
        }

        /// <inheritdoc />


        /// <inheritdoc />
        public T ExecuteScalar<T>(string sql, object param = null, int? commandTimeout = null)
        {
            var result = (T)this.InternalConnection.ExecuteScalar<T>(sql, param, this.InternalTransaction, commandTimeout);
            if (Debugger.IsAttached)
                Trace.WriteLine($"ExecuteScalar: {sql}");
            return result;
        }

        /// <inheritdoc />
        public int Execute(string sql, int? commandTimeout = null)
        {
            var result = this.InternalConnection.Execute(sql, null, this.InternalTransaction, commandTimeout);
            if (Debugger.IsAttached)
                Trace.WriteLine($"Execute: {sql}");
            return result;
        }

        /// <inheritdoc />
        public int Execute(string sql, object param, int? commandTimeout = null)
        {
            var result = this.InternalConnection.Execute(sql, param, this.InternalTransaction, commandTimeout);
            if (Debugger.IsAttached)
                Trace.WriteLine($"Execute: {sql}");
            return result;
        }
        /// <inheritdoc />
        public async Task<IReadOnlyList<dynamic>> QueryDynamicAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
            {
                var result = await this.InternalConnection.QueryAsync(sql, param, this.InternalTransaction, commandTimeout, commandType);
                if (Debugger.IsAttached)
                    Trace.WriteLine($"QueryAsync: {sql}");
                return result.AsList();
            }

            /// <inheritdoc />
            public async Task<IList<T>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
            {
                // buffered è true, si parla qui (https://github.com/StackExchange/Dapper/issues/1239) della necessità di specificarlo ma non viene gestito in questo metodo base con pochi parametri
                var result = await this.InternalConnection.QueryAsync<T>(sql, param, this.InternalTransaction, commandTimeout, commandType);
                if (Debugger.IsAttached)
                    Trace.WriteLine($"QueryAsync: {sql}");
                return result.AsList();
            }

          

            /// <inheritdoc />
            public Task<T> ExecuteScalarAsync<T>(string sql, object param = null, int? commandTimeout = null)
            {
                var result = this.InternalConnection.ExecuteScalarAsync<T>(sql, param, this.InternalTransaction, commandTimeout);
                if (Debugger.IsAttached)
                    Trace.WriteLine($"ExecuteScalarAsync: {sql}");
                return result;
            }

            /// <inheritdoc />
            public Task<int> ExecuteAsync(string sql, object param, int? commandTimeout = null)
            {
                var result = this.InternalConnection.ExecuteAsync(sql, param, this.InternalTransaction, commandTimeout);
                if (Debugger.IsAttached)
                    Trace.WriteLine($"ExecuteAsync: {sql}");
                return result;
            }

            /// <inheritdoc />
            public Task<int> ExecuteAsync(string sql, int? commandTimeout = null)
            {
                var result = this.InternalConnection.ExecuteAsync(sql, null, this.InternalTransaction, commandTimeout);
                if (Debugger.IsAttached)
                    Trace.WriteLine($"ExecuteAsync: {sql}");
                return result;
            }

            /// <inheritdoc />
            public Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null)
            {
                var result = this.InternalConnection.QueryFirstOrDefaultAsync<T>(sql, param, this.InternalTransaction, commandTimeout);
                if (Debugger.IsAttached)
                    Trace.WriteLine($"QueryFirstOrDefaultAsync: {sql}");
                return result;
            }

            /// <inheritdoc />
            public Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null)
            {
                var result = this.InternalConnection.QuerySingleOrDefaultAsync<T>(sql, param, this.InternalTransaction, commandTimeout);
                if (Debugger.IsAttached)
                    Trace.WriteLine($"QuerySingleOrDefaultAsync: {sql}");
                return result;
            }


        public SqlMapper.GridReader QueryMultiple(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            var result = this.InternalConnection.QueryMultiple(sql, param, this.InternalTransaction, commandTimeout, commandType);
            if (Debugger.IsAttached)
                Trace.WriteLine($"QueryMultiple: {sql}");
            return result;
        }

        public int ExecuteStoredProcedure(string procedureName, object parameters = null, int? commandTimeout = null)
        {
            var result = this.InternalConnection.Execute(procedureName, parameters, this.InternalTransaction, commandTimeout, CommandType.StoredProcedure);
            if (Debugger.IsAttached)
                Trace.WriteLine($"ExecuteStoredProcedure: {procedureName}");
            return result;
        }

        public void BulkInsert<T>(IEnumerable<T> data, string tableName)
        {
            if (InternalConnection is SqlConnection sqlConnection)
            {
                using var bulkCopy = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.Default, (SqlTransaction)InternalTransaction)
                {
                    DestinationTableName = tableName
                };

                var table = new DataTable();
                var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var prop in properties)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }

                foreach (var item in data)
                {
                    var values = properties.Select(p => p.GetValue(item) ?? DBNull.Value).ToArray();
                    table.Rows.Add(values);
                }

                bulkCopy.WriteToServer(table);
                if (Debugger.IsAttached)
                    Trace.WriteLine($"BulkInsert into {tableName}, {data.Count()} rows.");
            }
            else
            {
                throw new NotSupportedException("BulkInsert is only supported with SqlConnection.");
            }
        }

        public Dictionary<TKey, TValue> QueryToDictionary<TKey, TValue>(string sql, Func<dynamic, TKey> keySelector, Func<dynamic, TValue> valueSelector, object param = null)
        {
            var result = this.InternalConnection.Query(sql, param, this.InternalTransaction);
            return result.ToDictionary(keySelector, valueSelector);
        }

        public DataTable QueryToDataTable(string sql, object param = null)
        {
            using var reader = this.InternalConnection.ExecuteReader(sql, param, this.InternalTransaction);
            var dt = new DataTable();
            dt.Load(reader);
            return dt;
        }

        public List<TResult> QueryWithMapping<TFirst, TSecond, TResult>(
        string sql,
        Func<TFirst, TSecond, TResult> map,
        object param = null,
        string splitOn = "Id")
        {
            var result = this.InternalConnection.Query(sql, map, param, this.InternalTransaction, splitOn: splitOn).ToList();
            if (Debugger.IsAttached)
                Trace.WriteLine($"QueryWithMapping: {sql}");
            return result;
        }




        #region IDisposable

        // http://lostechies.com/chrispatterson/2012/11/29/idisposable-done-right/
        // http://msdn.microsoft.com/en-us/magazine/cc163392.aspx

        /// <inheritdoc />

        public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            /// <summary>Call to Dispose</summary>
            ~DapperContext()
            {
                Dispose(false);
            }

            /// <summary>Dispose internal DalUsageStats</summary>
            /// <param name="disposing"></param>
            protected virtual void Dispose(bool disposing)
            {
                if (this.IsDisposed)
                {
                    return;
                }

                if (disposing)
                {
                // nested case, riprisitno il readon only del context manager se valorizzato il previous
                //if (this.IsNestedContext && this.previousContextReadOnlyInfo != null)
                //{
                //    ((ContextManager)this.InternalContextManager).SetReadOnly(this.previousContextReadOnlyInfo.Value);
                //}
                // free other managed objects that implement
                // IDisposable only
                if (this.InternalTransaction != null)
                    {
                        // The behavior of Dispose di provider specific:
                        // SqlTransaction rolls back the transaction if it's in a pending state, different providers may not.
                        // https://msdn.microsoft.com/en-us/library/bf2cw321(v=vs.110).aspx
                        //NON chiamo il rollback se sono transaction less (cioè creato come context scopeless)
                        if (!this.IsTransactionLess && !this.IsTransactionCompleted && this.InternalConnection != null && this.InternalConnection.State == ConnectionState.Open)
                        {
                            this.InternalTransaction.Rollback();
                        }
                        if (!this.IsNestedContext)
                        {
                            this.InternalTransaction.Dispose();
                        }
                        this.InternalTransaction = null;
                        this.IsTransactionCompleted = true;
                    }

                    if (this.InternalConnection != null)
                    {
                        if (!this.IsNestedContext)
                        {
                            this.InternalConnection.Dispose();
                        }
                        this.InternalConnection = null;
                    }

                  
                }
                // release any unmanaged objects
                // set the object references to null
                this.IsDisposed = true;
            }

            #endregion
        }
   

}
