namespace UintsOfWorkTestWithDapper.Data
{
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

        /// <summary>Dappers Context interface with all db command plus internal object.</summary>
        public interface IDapperContext : IDisposable
        {
        //// props
        ///// <summary>Get Context DbConnection</summary>
        //IDbConnection Connection { get; }

        ///// <summary>Get Context DbTransaction</summary>
        //IDbTransaction Transaction { get; }

        ///// <summary>Get Context DbTransaction</summary>
        //bool IsTransactionCompleted { get; }

        ///// <summary>Get Context read only behaviour</summary>
        //bool IsReadOnly { get; }

        ///// <summary>Get Context transaction isolation level (if not transaction less)</summary>
        //IsolationLevel? ContextIsolationLevel { get; }

        ///// <summary>Default initial catalog name</summary>
        //string DefaultDbName { get; }

        ///// <summary>
        ///// Set a database default for the connection overriding current one
        ///// </summary>
        ///// <param name="dbName">The name of the db that will be the new default</param>
        //void UseDatabase(string dbName);

        ///// <summary>Retrieve table name of an entity using current context resolver.</summary>
        ///// <param name="entity">The entity type</param>
        ///// <returns>The table name with brackets []</returns>
        //string GetTableName(Type entity);

        ///// <summary>Retrieve table name of an entity using current context resolver.</summary>
        ///// <typeparam name="T">The entity type</typeparam>
        ///// <returns>The table name with brackets []</returns>
        //string GetTableName<T>();

        // sync
        /// <summary>Call dynamic version of Query command</summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns>Note: each row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</returns>
        IReadOnlyList<dynamic> Query(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null); //OK    
        ///// <summary>Call generic T version of Query command</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="sql"></param>
        ///// <param name="param"></param>
        ///// <param name="commandTimeout"></param>
        ///// <param name="commandType"></param>
        ///// <returns></returns>
        IList<T> Query<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null); //OK

        ///// <summary>Call generic T version of ExecuteScalar command</summary>
        ///// <typeparam name="T">Expected T type from database</typeparam>
        ///// <param name="sql"></param>
        ///// <param name="param"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns>Return T type from database</returns>
        T ExecuteScalar<T>(string sql, object param = null, int? commandTimeout = null); //OK

        ///// <summary>Call Execute command</summary>
        ///// <param name="sql"></param>
        ///// <param name="param"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns>Number of rows affected</returns>
        int Execute(string sql, object param, int? commandTimeout = null); //OK

        ///// <summary>Call Execute command</summary>
        ///// <param name="sql"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns>Number of rows affected</returns>
        int Execute(string sql, int? commandTimeout = null); //OK
        ///// <summary>Commit of current Context</summary>
        void Commit();

        ///// <summary>Rollback of current Context</summary>
        //void Rollback();

        ///// <summary>Retrieve entity T from database with a key id</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="id"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //T Get<T>(object id, int? commandTimeout = null);

        ///// <summary>Retrieve entity T from database with a key id</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="id"></param>
        ///// <param name="sortFieldList">sort field list</param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //T GetFirst<T>(object id, IList<ISortField> sortFieldList, int? commandTimeout = null);

        ///// <summary>Retrieve entity T from database with a double key id</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="idOne"></param>
        ///// <param name="idTwo"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //T Get<T>(object idOne, object idTwo, int? commandTimeout = null);

        ///// <summary>Retrieve entity T derived from TBase from database with a key id</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="id"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //T Get<T, TBase>(object id, int? commandTimeout = null);

        ///// <summary>Retrieve entity T from database with a left key id of a bridge</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="idLeft"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //T GetByLeft<T>(object idLeft, int? commandTimeout = null);

        ///// <summary>Retrieve entity T from database with a right key id of a bridge</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="idRight"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //T GetByRight<T>(object idRight, int? commandTimeout = null);

        ///// <summary>Retrieve entity TLeft foreign table (LEFT) of TBridge table using the key property of the RIGHT table</summary>
        ///// <typeparam name="TLeft">Return entity type (foreign) LEFT table in FK with FIRST property key of the bridge</typeparam>
        ///// <typeparam name="TBridge">Bridge entity type</typeparam>
        ///// <param name="idRight">SECOND property key of the bridge (RIGHT table id)</param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //TLeft GetLeft<TLeft, TBridge>(object idRight, int? commandTimeout = null);

        ///// <summary>Retrieve entity TRight foreign table (RIGHT) of TBridge table using the key property of the LEFT table</summary>
        ///// <typeparam name="TRight">Return entity type (foreign) RIGHT table in FK with SECOND property key of the bridge</typeparam>
        ///// <typeparam name="TBridge">Bridge entity type</typeparam>
        ///// <param name="idLeft">FIRST property key of the bridge (LEFT table id)</param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //TRight GetRight<TRight, TBridge>(object idLeft, int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database with where condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="whereCondition"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetList<T>(object whereCondition, int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database with where condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="whereCondition"></param>
        ///// <param name="sortFieldList"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetList<T>(object whereCondition, IList<ISortField> sortFieldList, int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetList<T>(int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="sortFieldList"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetList<T>(IList<ISortField> sortFieldList, int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database with string condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetList<T>(string conditions, object parameters = null, int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database with string condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="sortFieldList"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetList<T>(string conditions, IList<ISortField> sortFieldList, object parameters = null, int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database with where condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="whereCondition"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetList<T, TBase>(object whereCondition, int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database with where condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="whereCondition"></param>
        ///// <param name="sortFieldList"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetList<T, TBase>(object whereCondition, IList<ISortField> sortFieldList, int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetList<T, TBase>(int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="sortFieldList"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetList<T, TBase>(IList<ISortField> sortFieldList, int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database with string condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetList<T, TBase>(string conditions, object parameters = null, int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database with string condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="sortFieldList"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetList<T, TBase>(string conditions, IList<ISortField> sortFieldList, object parameters = null, int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database with left key id of a bridge</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="idLeft"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetListByLeft<T>(object idLeft, int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database with right key id of a bridge</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="idRight"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetListByRight<T>(object idRight, int? commandTimeout = null);

        ///// <summary>Retrieve list of entity TLeft foreign table (LEFT) of TBridge table using the key property of the RIGHT table</summary>
        ///// <typeparam name="TLeft">Return entity type (foreign) LEFT table in FK with FIRST property key of the bridge</typeparam>
        ///// <typeparam name="TBridge">Bridge entity type</typeparam>
        ///// <param name="idRight">SECOND property key of the bridge (RIGHT table id)</param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<TLeft> GetLeftList<TLeft, TBridge>(object idRight, int? commandTimeout = null);

        ///// <summary>Retrieve list of entity TRight foreign table (RIGHT) of TBridge table using the key property of the LEFT table</summary>
        ///// <typeparam name="TRight">Return entity type (foreign) RIGHT table in FK with SECOND property key of the bridge</typeparam>
        ///// <typeparam name="TBridge">Bridge entity type</typeparam>
        ///// <param name="idLeft">FIRST property key of the bridge (LEFT table id)</param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<TRight> GetRightList<TRight, TBridge>(object idLeft, int? commandTimeout = null);

        ///// <summary>Retrieve a list of Tkey of entity T from database with where condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TKey"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<TKey> GetKeyList<T, TKey>(string conditions, object parameters = null, int? commandTimeout = null);

        ///// <summary>Retrieve a list of Tkey of entity T from database with where condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TKey"></typeparam>
        ///// <param name="whereCondition"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<TKey> GetKeyList<T, TKey>(object whereCondition, int? commandTimeout = null);

        ///// <summary>Retrieve a list of dynamic of all fields of entity from database with string condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns>Note: each row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</returns>
        //IReadOnlyList<dynamic> GetAllFieldsList<T>(string conditions = null, int? commandTimeout = null);

        ///// <summary>Retrieve a single dynamic of all fields of entity from database with object id filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="id"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns>Note: result can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</returns>
        //dynamic GetAllFields<T>(object id, int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database in paged mode (string conditions in form 'WHERE ... ' and order by in form 'Field ASC'</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="pageNumber"></param>
        ///// <param name="rowsPerPage"></param>
        ///// <param name="conditions"></param>
        ///// <param name="orderBy"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //IList<T> GetListPaged<T>(int pageNumber, int rowsPerPage, string conditions, string orderBy, object parameters = null, int? commandTimeout = null);

        ///// <summary>Retrieve a list of entity T from database in paged mode (object where conditions and IList of ISortField)</summary>
        ///// <param name="pageNumber"></param>
        ///// <param name="rowsPerPage"></param>
        ///// <param name="whereConditions"></param>
        ///// <param name="sortFieldList"></param>
        ///// <param name="commandTimeout"></param>
        ///// <typeparam name="T"></typeparam>
        ///// <returns></returns>
        //IList<T> GetListPaged<T>(int pageNumber, int rowsPerPage, object whereConditions, IList<ISortField> sortFieldList, int? commandTimeout = null);

        ///// <summary>Insert entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToInsert"></param>
        ///// <param name="commandTimeout"></param>
        //void Insert<TEntity>(TEntity entityToInsert, int? commandTimeout = null);

        ///// <summary>Insert entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToInsert"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="commandTimeout"></param>
        //void Insert<TEntity>(TEntity entityToInsert, UseEntitySys useEntitySys, int? commandTimeout = null);

        ///// <summary>Insert entity TEntity with a TKey key into database</summary>
        ///// <typeparam name="TKey"></typeparam>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToInsert"></param>
        ///// <param name="commandTimeout"></param>
        //void Insert<TKey, TEntity>(TEntity entityToInsert, int? commandTimeout = null);

        ///// <summary>Insert entity TEntity with a TKey key into database</summary>
        ///// <typeparam name="TKey"></typeparam>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToInsert"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="commandTimeout"></param>
        //void Insert<TKey, TEntity>(TEntity entityToInsert, UseEntitySys useEntitySys, int? commandTimeout = null);

        ///// <summary>Insert entity TEntity derived from TBase with a TKey key into database</summary>
        ///// <typeparam name="TKey"></typeparam>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="entityToInsert"></param>
        ///// <param name="commandTimeout"></param>
        //void Insert<TKey, TEntity, TBase>(TEntity entityToInsert, int? commandTimeout = null);

        ///// <summary>Insert entity TEntity derived from TBase with a TKey key into database</summary>
        ///// <typeparam name="TKey"></typeparam>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="entityToInsert"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="commandTimeout"></param>
        //void Insert<TKey, TEntity, TBase>(TEntity entityToInsert, UseEntitySys useEntitySys, int? commandTimeout = null);

        ///// <summary>Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //int Update<TEntity>(TEntity entityToUpdate, int? commandTimeout = null);

        ///// <summary>Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //int Update<TEntity>(TEntity entityToUpdate, params string[] updateOnlyFields);

        ///// <summary>Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="commandTimeout"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //int Update<TEntity>(TEntity entityToUpdate, int? commandTimeout, params string[] updateOnlyFields);

        ///// <summary>Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //int Update<TEntity>(TEntity entityToUpdate, UseEntitySys useEntitySys, int? commandTimeout = null);

        ///// <summary>Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="partitionFieldName"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //int Update<TEntity>(TEntity entityToUpdate, UseEntitySys useEntitySys, string partitionFieldName, int? commandTimeout = null);

        ///// <summary>Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //int Update<TEntity>(TEntity entityToUpdate, UseEntitySys useEntitySys, params string[] updateOnlyFields);

        ///// <summary>Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="commandTimeout"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //int Update<TEntity>(TEntity entityToUpdate, UseEntitySys useEntitySys, int? commandTimeout, params string[] updateOnlyFields);

        ///// <summary>Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="partitionFieldName"></param>
        ///// <param name="commandTimeout"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //int Update<TEntity>(TEntity entityToUpdate, UseEntitySys useEntitySys, string partitionFieldName, int? commandTimeout, params string[] updateOnlyFields);

        ///// <summary>Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="attinionalWhereConditions"></param>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //int Update<TEntity>(TEntity entityToUpdate, object attinionalWhereConditions, UseEntitySys useEntitySys, int? commandTimeout = null);

        ///// <summary>Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="attinionalWhereConditions"></param>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="partitionFieldName"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //int Update<TEntity>(TEntity entityToUpdate, object attinionalWhereConditions, UseEntitySys useEntitySys, string partitionFieldName, int? commandTimeout = null);

        ///// <summary>Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="attinionalWhereConditions"></param>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //int Update<TEntity>(TEntity entityToUpdate, object attinionalWhereConditions, UseEntitySys useEntitySys, params string[] updateOnlyFields);

        ///// <summary>Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="attinionalWhereConditions"></param>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="commandTimeout"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //int Update<TEntity>(TEntity entityToUpdate, object attinionalWhereConditions, UseEntitySys useEntitySys, int? commandTimeout, params string[] updateOnlyFields);

        ///// <summary>Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="attinionalWhereConditions"></param>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="partitionFieldName"></param>
        ///// <param name="commandTimeout"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //int Update<TEntity>(TEntity entityToUpdate, object attinionalWhereConditions, UseEntitySys useEntitySys, string partitionFieldName, int? commandTimeout, params string[] updateOnlyFields);

        ///// <summary>Delete entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToDelete"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //int Delete<TEntity>(TEntity entityToDelete, int? commandTimeout = null);

        ///// <summary>Delete entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToDelete"></param>
        ///// <param name="partitionFieldName"></param>
        ///// <param name="commandTimeout"></param>
        ///// <param name="useEntitySys"></param>
        ///// <returns></returns>
        //int Delete<TEntity>(TEntity entityToDelete, UseEntitySys useEntitySys, string partitionFieldName, int? commandTimeout = null);

        ///// <summary>Delete entity TEntity into database with id key</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="id"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //int Delete<TEntity>(object id, int? commandTimeout = null);

        ///// <summary>Delete entity TEntity into database with double id key</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="idOne"></param>
        ///// <param name="idTwo"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //int Delete<TEntity>(object idOne, object idTwo, int? commandTimeout = null);

        ///// <summary>Delete entity bridge TEntity into database with left id key</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="idLeft"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //int DeleteByLeft<TEntity>(object idLeft, int? commandTimeout = null);

        ///// <summary>Delete entity bridge TEntity into database with right id key</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="idRight"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //int DeleteByRight<TEntity>(object idRight, int? commandTimeout = null);

        ///// <summary>Delete a list of entity TEntity into database with where condition filter</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="whereConditions"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //int DeleteList<TEntity>(object whereConditions, int? commandTimeout = null);

        ///// <summary>Delete a list of entity TEntity into database with string condition filter</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //int DeleteList<TEntity>(string conditions, object parameters = null, int? commandTimeout = null);

        ///// <summary>Count of record of entity TEntity into database  with where condition filter</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="whereConditions"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //int RecordCount<TEntity>(object whereConditions, int? commandTimeout = null);

        ///// <summary>Count of record of entity TEntity into database  with string condition filter</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //int RecordCount<TEntity>(string conditions = "", object parameters = null, int? commandTimeout = null);

        /// <summary>Retrieve single or default of generic T type from database (exception if more than one entity found)</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        T QuerySingleOrDefault<T>(string sql, object param = null, int? commandTimeout = null); //OK

        /// <summary>Retrieve first or default of generic T type from database</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        T QueryFirstOrDefault<T>(string sql, object param = null, int? commandTimeout = null); //OK

        // async
        // todo: cancellation token non previsti perché Dapper.SqlMapper non li prevede, aggiungerli solo se necessario
        /// <summary>Async Call dynamic version of Query command</summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns>Note: each row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</returns>
        Task<IReadOnlyList<dynamic>> QueryDynamicAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>Async Call generic T version of Query command</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        Task<IList<T>> QueryAsync<T>(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);

        /// <summary>ASync Call generic T version of ExecuteScalar command</summary>
        /// <typeparam name="T">Expected T type from database</typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>Return T type from database</returns>
        Task<T> ExecuteScalarAsync<T>(string sql, object param = null, int? commandTimeout = null);

        /// <summary>Async Call Execute command</summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>Number of rows affected</returns>
        Task<int> ExecuteAsync(string sql, object param, int? commandTimeout = null);

        /// <summary>Async Call Execute command</summary>
        /// <param name="sql"></param>
        /// <param name="commandTimeout"></param>
        /// <returns>Number of rows affected</returns>
        Task<int> ExecuteAsync(string sql, int? commandTimeout = null);

        ///// <summary>Async Retrieve entity T from database with a key id</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="id"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<T> GetAsync<T>(object id, int? commandTimeout = null);

        ///// <summary>Async Retrieve entity T from database with a key id</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="id"></param>
        ///// <param name="sortFieldList">sort filed list</param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<T> GetFirstAsync<T>(object id, IList<ISortField> sortFieldList, int? commandTimeout = null);

        ///// <summary>Async Retrieve entity T from database with a double key id</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="idOne"></param>
        ///// <param name="idTwo"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<T> GetAsync<T>(object idOne, object idTwo, int? commandTimeout = null);

        ///// <summary>Async Retrieve entity T derived from TBase from database with a key id</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="id"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<T> GetAsync<T, TBase>(object id, int? commandTimeout = null);

        ///// <summary>Async Retrieve entity T from database with a left key id of a bridge</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="idLeft"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<T> GetByLeftAsync<T>(object idLeft, int? commandTimeout = null);

        ///// <summary>Async Retrieve entity T from database with a right key id of a bridge</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="idRight"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<T> GetByRightAsync<T>(object idRight, int? commandTimeout = null);

        ///// <summary>Async Retrieve entity TLeft foreign table (LEFT) of TBridge table using the key property of the RIGHT table</summary>
        ///// <typeparam name="TLeft">Return entity type (foreign) LEFT table in FK with FIRST property key of the bridge</typeparam>
        ///// <typeparam name="TBridge">Bridge entity type</typeparam>
        ///// <param name="idRight">SECOND property key of the bridge (RIGHT table id)</param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<TLeft> GetLeftAsync<TLeft, TBridge>(object idRight, int? commandTimeout = null);

        ///// <summary>Async Retrieve entity TRight foreign table (RIGHT) of TBridge table using the key property of the LEFT table</summary>
        ///// <typeparam name="TRight">Return entity type (foreign) RIGHT table in FK with SECOND property key of the bridge</typeparam>
        ///// <typeparam name="TBridge">Bridge entity type</typeparam>
        ///// <param name="idLeft">FIRST property key of the bridge (LEFT table id)</param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<TRight> GetRightAsync<TRight, TBridge>(object idLeft, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database with where condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="whereCondition"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListAsync<T>(object whereCondition, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database with where condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="whereCondition"></param>
        ///// <param name="sortFieldList"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListAsync<T>(object whereCondition, IList<ISortField> sortFieldList, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListAsync<T>(int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="sortFieldList"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListAsync<T>(IList<ISortField> sortFieldList, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database with string condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListAsync<T>(string conditions, object parameters = null, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database with string condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="sortFieldList"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListAsync<T>(string conditions, IList<ISortField> sortFieldList, object parameters = null, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database with where condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="whereCondition"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListAsync<T, TBase>(object whereCondition, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database with where condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="whereCondition"></param>
        ///// <param name="sortFieldList"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListAsync<T, TBase>(object whereCondition, IList<ISortField> sortFieldList, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListAsync<T, TBase>(int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="sortFieldList"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListAsync<T, TBase>(IList<ISortField> sortFieldList, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database with string condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListAsync<T, TBase>(string conditions, object parameters = null, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database with string condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="sortFieldList"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListAsync<T, TBase>(string conditions, IList<ISortField> sortFieldList, object parameters = null, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database with left key id of a bridge</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="idLeft"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListByLeftAsync<T>(object idLeft, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database with right key id of a bridge</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="idRight"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListByRightAsync<T>(object idRight, int? commandTimeout = null);

        ///// <summary>Async Retrieve list of entity TLeft foreign table (LEFT) of TBridge table using the key property of the RIGHT table</summary>
        ///// <typeparam name="TLeft">Return entity type (foreign) LEFT table in FK with FIRST property key of the bridge</typeparam>
        ///// <typeparam name="TBridge">Bridge entity type</typeparam>
        ///// <param name="idRight">SECOND property key of the bridge (RIGHT table id)</param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<TLeft>> GetLeftListAsync<TLeft, TBridge>(object idRight, int? commandTimeout = null);

        ///// <summary>Async Retrieve list of entity TRight foreign table (RIGHT) of TBridge table using the key property of the LEFT table</summary>
        ///// <typeparam name="TRight">Return entity type (foreign) RIGHT table in FK with SECOND property key of the bridge</typeparam>
        ///// <typeparam name="TBridge">Bridge entity type</typeparam>
        ///// <param name="idLeft">FIRST property key of the bridge (LEFT table id)</param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<TRight>> GetRightListAsync<TRight, TBridge>(object idLeft, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of Tkey of entity T from database with where condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TKey"></typeparam>
        ///// <param name="whereCondition"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<TKey>> GetKeyListAsync<T, TKey>(object whereCondition, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of Tkey of entity T from database with where condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="TKey"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<TKey>> GetKeyListAsync<T, TKey>(string conditions, object parameters = null, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of dynamic of all fields of entity from database with string condition filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns>Note: each row can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</returns>
        //Task<IEnumerable<dynamic>> GetAllFieldsListAsync<T>(string conditions = null, int? commandTimeout = null);

        ///// <summary>Async Retrieve a single dynamic of all fields of entity from database with object id filter</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="id"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns>Note: result can be accessed via "dynamic", or by casting to an IDictionary&lt;string,object&gt;</returns>
        //Task<dynamic> GetAllFieldsAsync<T>(object id, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database in paged mode</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="pageNumber"></param>
        ///// <param name="rowsPerPage"></param>
        ///// <param name="conditions"></param>
        ///// <param name="orderBy"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListPagedAsync<T>(int pageNumber, int rowsPerPage, string conditions, string orderBy, object parameters = null, int? commandTimeout = null);

        ///// <summary>Async Retrieve a list of entity T from database in paged mode</summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="pageNumber"></param>
        ///// <param name="rowsPerPage"></param>
        ///// <param name="sortFieldList"></param>
        ///// <param name="commandTimeout"></param>
        ///// <param name="whereConditions"></param>
        ///// <returns></returns>
        //Task<IList<T>> GetListPagedAsync<T>(int pageNumber, int rowsPerPage, object whereConditions, IList<ISortField> sortFieldList, int? commandTimeout = null);

        ///// <summary>Async Insert entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToInsert"></param>
        ///// <param name="commandTimeout"></param>
        //Task InsertAsync<TEntity>(TEntity entityToInsert, int? commandTimeout = null);

        ///// <summary>Async Insert entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToInsert"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="commandTimeout"></param>
        //Task InsertAsync<TEntity>(TEntity entityToInsert, UseEntitySys useEntitySys, int? commandTimeout = null);

        ///// <summary>Async Insert entity TEntity with a TKey key into database</summary>
        ///// <typeparam name="TKey"></typeparam>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToInsert"></param>
        ///// <param name="commandTimeout"></param>
        //Task InsertAsync<TKey, TEntity>(TEntity entityToInsert, int? commandTimeout = null);

        ///// <summary>Async Insert entity TEntity with a TKey key into database</summary>
        ///// <typeparam name="TKey"></typeparam>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToInsert"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="commandTimeout"></param>
        //Task InsertAsync<TKey, TEntity>(TEntity entityToInsert, UseEntitySys useEntitySys, int? commandTimeout = null);

        ///// <summary>Async Insert entity TEntity derived from TBase with a TKey key into database</summary>
        ///// <typeparam name="TKey"></typeparam>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="entityToInsert"></param>
        ///// <param name="commandTimeout"></param>
        //Task InsertAsync<TKey, TEntity, TBase>(TEntity entityToInsert, int? commandTimeout = null);

        ///// <summary>Async Insert entity TEntity derived from TBase with a TKey key into database</summary>
        ///// <typeparam name="TKey"></typeparam>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <typeparam name="TBase"></typeparam>
        ///// <param name="entityToInsert"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="commandTimeout"></param>
        //Task InsertAsync<TKey, TEntity, TBase>(TEntity entityToInsert, UseEntitySys useEntitySys, int? commandTimeout = null);

        ///// <summary>Async Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<int> UpdateAsync<TEntity>(TEntity entityToUpdate, int? commandTimeout = null);

        ///// <summary>Async Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //Task<int> UpdateAsync<TEntity>(TEntity entityToUpdate, params string[] updateOnlyFields);

        ///// <summary>Async Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="commandTimeout"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //Task<int> UpdateAsync<TEntity>(TEntity entityToUpdate, int? commandTimeout, params string[] updateOnlyFields);

        ///// <summary>Async Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<int> UpdateAsync<TEntity>(TEntity entityToUpdate, UseEntitySys useEntitySys, int? commandTimeout = null);

        ///// <summary>Async Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="partitionFieldName"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<int> UpdateAsync<TEntity>(TEntity entityToUpdate, UseEntitySys useEntitySys, string partitionFieldName, int? commandTimeout = null);

        ///// <summary>Async Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //Task<int> UpdateAsync<TEntity>(TEntity entityToUpdate, UseEntitySys useEntitySys, params string[] updateOnlyFields);

        ///// <summary>Async Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="commandTimeout"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //Task<int> UpdateAsync<TEntity>(TEntity entityToUpdate, UseEntitySys useEntitySys, int? commandTimeout, params string[] updateOnlyFields);

        ///// <summary>Async Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="partitionFieldName"></param>
        ///// <param name="commandTimeout"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //Task<int> UpdateAsync<TEntity>(TEntity entityToUpdate, UseEntitySys useEntitySys, string partitionFieldName, int? commandTimeout, params string[] updateOnlyFields);

        ///// <summary>Async Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="attinionalWhereConditions"></param>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<int> UpdateAsync<TEntity>(TEntity entityToUpdate, object attinionalWhereConditions, UseEntitySys useEntitySys, int? commandTimeout = null);


        ///// <summary>Async Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="attinionalWhereConditions"></param>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="partitionFieldName"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<int> UpdateAsync<TEntity>(TEntity entityToUpdate, object attinionalWhereConditions, UseEntitySys useEntitySys, string partitionFieldName, int? commandTimeout = null);

        ///// <summary>Async Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="attinionalWhereConditions"></param>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //Task<int> UpdateAsync<TEntity>(TEntity entityToUpdate, object attinionalWhereConditions, UseEntitySys useEntitySys, params string[] updateOnlyFields);

        ///// <summary>Async Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="attinionalWhereConditions"></param>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="commandTimeout"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //Task<int> UpdateAsync<TEntity>(TEntity entityToUpdate, object attinionalWhereConditions, UseEntitySys useEntitySys, int? commandTimeout, params string[] updateOnlyFields);

        ///// <summary>Async Update entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="attinionalWhereConditions"></param>
        ///// <param name="entityToUpdate"></param>
        ///// <param name="useEntitySys"></param>
        ///// <param name="partitionFieldName"></param>
        ///// <param name="commandTimeout"></param>
        ///// <param name="updateOnlyFields"></param>
        ///// <returns></returns>
        //Task<int> UpdateAsync<TEntity>(TEntity entityToUpdate, object attinionalWhereConditions, UseEntitySys useEntitySys, string partitionFieldName, int? commandTimeout, params string[] updateOnlyFields);

        ///// <summary>Async Delete entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToDelete"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<int> DeleteAsync<TEntity>(TEntity entityToDelete, int? commandTimeout = null);

        ///// <summary>Async Delete entity TEntity into database</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="entityToDelete"></param>
        ///// <param name="partitionFieldName"></param>
        ///// <param name="commandTimeout"></param>
        ///// <param name="useEntitySys"></param>
        ///// <returns></returns>
        //Task<int> DeleteAsync<TEntity>(TEntity entityToDelete, UseEntitySys useEntitySys, string partitionFieldName, int? commandTimeout = null);

        ///// <summary>Async Delete entity TEntity into database with id key</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="id"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<int> DeleteAsync<TEntity>(object id, int? commandTimeout = null);

        ///// <summary>Async Delete entity TEntity into database with double id key</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="idOne"></param>
        ///// <param name="idTwo"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<int> DeleteAsync<TEntity>(object idOne, object idTwo, int? commandTimeout = null);

        ///// <summary>Async Delete entity bridge TEntity into database with left id key</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="idLeft"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<int> DeleteByLeftAsync<TEntity>(object idLeft, int? commandTimeout = null);

        ///// <summary>Async Delete entity bridge TEntity into database with right id key</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="idRight"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<int> DeleteByRightAsync<TEntity>(object idRight, int? commandTimeout = null);

        ///// <summary>Async Delete a list of entity TEntity into database with where condition filter</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="whereConditions"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<int> DeleteListAsync<TEntity>(object whereConditions, int? commandTimeout = null);

        ///// <summary>Async Delete a list of entity TEntity into database with string condition filter</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<int> DeleteListAsync<TEntity>(string conditions, object parameters = null, int? commandTimeout = null);

        ///// <summary>Async Count of record of entity TEntity into database  with where condition filter</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="whereConditions"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<int> RecordCountAsync<TEntity>(object whereConditions, int? commandTimeout = null);

        ///// <summary>Async Count of record of entity TEntity into database  with string condition filter</summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="conditions"></param>
        ///// <param name="parameters"></param>
        ///// <param name="commandTimeout"></param>
        ///// <returns></returns>
        //Task<int> RecordCountAsync<TEntity>(string conditions = "", object parameters = null, int? commandTimeout = null);

        /// <summary>Async Retrieve single or default of generic T type from database (exception if more than one entity found)</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<T> QuerySingleOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null);

        /// <summary>Async Retrieve first or default of generic T type from database</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandTimeout"></param>
        /// <returns></returns>
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, int? commandTimeout = null);

        SqlMapper.GridReader QueryMultiple(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        int ExecuteStoredProcedure(string procedureName, object parameters = null, int? commandTimeout = null);
        public void BulkInsert<T>(IEnumerable<T> data, string tableName);
        Dictionary<TKey, TValue> QueryToDictionary<TKey, TValue>(string sql, Func<dynamic, TKey> keySelector, Func<dynamic, TValue> valueSelector, object param = null);

        DataTable QueryToDataTable(string sql, object param = null);
        List<TResult> QueryWithMapping<TFirst, TSecond, TResult>(string sql,Func<TFirst, TSecond, TResult> map,object param = null,string splitOn = "Id");
        //// todo: RollbackAsync non previsto dalla attuale versione di DbTransaction
        //// Task CommitAsync();
        //// todo: RollbackAsync non previsto dalla attuale versione di DbTransaction
        //// Task RollbackAsync();

        ///// <summary>Execute a stored procedure with a simple return value of type T</summary>
        ///// <typeparam name="T">Simple type of return</typeparam>
        ///// <param name="spName">Name of the stored procedure</param>
        ///// <param name="param">Anonimous type for so parameters</param>
        ///// <param name="commandTimeout">Command timeout (optional)</param>
        ///// <returns>The sp return value</returns>
        //T ExecuteStoredProcedure<T>(string spName, object param = null, int? commandTimeout = null);

        ///// <summary>Async execute a stored procedure with a simple return value of type T</summary>
        ///// <typeparam name="T">Simple type of return</typeparam>
        ///// <param name="spName">Name of the stored procedure</param>
        ///// <param name="param">Anonimous type for so parameters</param>
        ///// <param name="commandTimeout">Command timeout (optional)</param>
        ///// <returns>The sp return value</returns>
        //Task<T> ExecuteStoredProcedureAsync<T>(string spName, object param = null, int? commandTimeout = null);
    }

    public interface ISortField
    {
        /// <summary>
        /// Nome del campo appartente ad un tipo
        /// </summary>
        string Field { get; }
        /// <summary>
        /// Tipo di sort
        /// </summary>
        SortType Sort { get; }
    }
    public enum SortType
    {
        /// <summary>
        /// ASC
        /// </summary>
        Ascending,
        /// <summary>
        /// DESC
        /// </summary>
        Descending,
    }
    public enum UseEntitySys : byte
    {
        /// <summary>No SYS field expected (Default.)</summary>
        None = 1,

        /// <summary>SYSDataCreazione field expected</summary>
        Creation = 2,
        /// <summary>SYSDataCreazione e SYSDataUltimaModifica field expected</summary>
        Update = Creation | OnlyUpdate,

        /// <summary>SYSDataUltimaModifica field expected</summary>
        OnlyUpdate = 4,

        /// <summary>SYSDataPartizione field expected with one temporal specification value (cannot be alone)</summary>
        Partitioned = 8,

        /// <summary>Monthly value used in partition (cannot be alone)</summary>
        Monthly = 32,
        /// <summary>Semestral value used in partition (cannot be alone)</summary>
        Biannual = 64,

        /// <summary>SYSDataPartizione field expected with monthly value</summary>
        MonthlyPartitioned = Partitioned | Monthly,
        /// <summary>SYSDataPartizione field expected with semestral value</summary>
        BiannualPartitioned = Partitioned | Biannual,
    }
}
