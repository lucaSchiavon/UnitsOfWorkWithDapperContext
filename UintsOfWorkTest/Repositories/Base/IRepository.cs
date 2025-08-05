using Dapper;
using System.Data;

namespace UintsOfWorkTest.Repositories.Base
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
    }
}
