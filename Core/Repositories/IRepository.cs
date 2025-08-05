using Dapper;
using System.Data;

namespace Core.Repositories
{
    public interface IRepository<T> where T : class
    {
   
        T QueryFirstOrDefault(string sql, object param = null, int? commandTimeout = null);
        T QuerySingleOrDefault(string sql, object param = null, int? commandTimeout = null);
        IList<T> Query(string sql, object param = null, int? commandTimeout = null);
        IReadOnlyList<dynamic> QueryDynamic(string sql, object param = null, int? commandTimeout = null);
        TResult ExecuteScalar<TResult>(string sql, object param = null, int? commandTimeout = null);
        int Execute(string sql, object param = null, int? commandTimeout = null);
        int Execute(string sql, int? commandTimeout = null);
        int ExecuteStoredProcedure(string procedureName, object parameters = null, int? commandTimeout = null);
        void BulkInsert(IEnumerable<T> data, string tableName);
        void Commit();
        SqlMapper.GridReader QueryMultiple(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Dictionary<TKey, TValue> QueryToDictionary<TKey, TValue>(string sql, Func<dynamic, TKey> keySelector, Func<dynamic, TValue> valueSelector, object param = null);
        DataTable QueryToDataTable(string sql, object param = null);
        List<TResult> QueryWithMapping<TFirst, TSecond, TResult>(
            string sql,
            Func<TFirst, TSecond, TResult> map,
            object param = null,
            string splitOn = "Id"
        );

        // Asincroni
        Task<IReadOnlyList<dynamic>> QueryDynamicAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null);
        Task<IList<T>> QueryAsync(object param = null, string sql = "", int? commandTimeout = null, CommandType? commandType = null);
        Task<TResult> ExecuteScalarAsync<TResult>(string sql, object param = null, int? commandTimeout = null);
        Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null);
        Task<int> ExecuteAsync(string sql, int? commandTimeout = null);
        Task<T> QuerySingleOrDefaultAsync(string sql, object param = null, int? commandTimeout = null);
        Task<T> QueryFirstOrDefaultAsync(string sql, object param = null, int? commandTimeout = null);

        // SimpleCRUD - sincroni
        int? Insert(T entity);
        T Get(object id);
        IEnumerable<T> GetList(object whereConditions = null);
        int Update(T entity);
        int Delete(T entity);
        int Delete(object id);
        int DeleteList(object whereConditions);
        int RecordCount(object whereConditions = null);

        // SimpleCRUD - asincroni
        Task<int?> InsertAsync(T entity);
        Task<T> GetAsync(object id);
        Task<IEnumerable<T>> GetListAsync(object whereConditions = null);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<int> DeleteAsync(object id);
        Task<int> DeleteListAsync(object whereConditions);
        Task<int> RecordCountAsync(object whereConditions = null);
    }
}
