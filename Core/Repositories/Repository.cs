using Core.Data;
using Dapper;
using System.Data;

namespace Core.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IDapperContext _context;
        
        public Repository(IDapperContext context)
        {
            _context = context;
           
        }

     
        public T QueryFirstOrDefault(string sql, object param = null, int? commandTimeout = null)
        {
            return _context.QueryFirstOrDefault<T>(sql, param, commandTimeout);
        }

        public T QuerySingleOrDefault(string sql, object param = null, int? commandTimeout = null)
        {
            return _context.QuerySingleOrDefault<T>(sql, param, commandTimeout);
        }

        public IList<T> Query(string sql, object param = null, int? commandTimeout = null)
        {
            return _context.Query<T>(sql, param, commandTimeout);
        }

        public IReadOnlyList<dynamic> QueryDynamic(string sql, object param = null, int? commandTimeout = null)
        {
            return _context.Query(sql, param, commandTimeout);
        }

        public TResult ExecuteScalar<TResult>(string sql, object param = null, int? commandTimeout = null)
        {
            return _context.ExecuteScalar<TResult>(sql, param, commandTimeout);
        }

        public int Execute(string sql, object param = null, int? commandTimeout = null)
        {
            return _context.Execute(sql, param, commandTimeout);
        }

        public int Execute(string sql, int? commandTimeout = null)
            => _context.Execute(sql, commandTimeout);

        public int ExecuteStoredProcedure(string procedureName, object parameters = null, int? commandTimeout = null)
            => _context.ExecuteStoredProcedure(procedureName, parameters, commandTimeout);

        public void BulkInsert(IEnumerable<T> data, string tableName)
            => _context.BulkInsert(data, tableName);

        public void Commit()
            => _context.Commit();

        public SqlMapper.GridReader QueryMultiple(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
            => _context.QueryMultiple(sql, param, commandTimeout, commandType);

        public Dictionary<TKey, TValue> QueryToDictionary<TKey, TValue>(string sql, Func<dynamic, TKey> keySelector, Func<dynamic, TValue> valueSelector, object param = null)
            => _context.QueryToDictionary(sql, keySelector, valueSelector, param);

        public DataTable QueryToDataTable(string sql, object param = null)
            => _context.QueryToDataTable(sql, param);

        public List<TResult> QueryWithMapping<TFirst, TSecond, TResult>(
            string sql,
            Func<TFirst, TSecond, TResult> map,
            object param = null,
            string splitOn = "Id")
            => _context.QueryWithMapping(sql, map, param, splitOn);

        // -------------------
        // METODI ASINCRONI
        // -------------------

        //public Task<IReadOnlyList<dynamic>> QueryAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        //    => _context.QueryAsync(sql, param, commandTimeout, commandType);

        public Task<IList<T>> QueryAsync(object param = null, string sql = "", int? commandTimeout = null, CommandType? commandType = null)
            => _context.QueryAsync<T>(sql, param, commandTimeout, commandType);

        public Task<IReadOnlyList<dynamic>> QueryDynamicAsync(string sql, object param = null, int? commandTimeout = null, CommandType? commandType = null)
            =>_context.QueryDynamicAsync(sql, param, commandTimeout, commandType);

        public Task<TResult> ExecuteScalarAsync<TResult>(string sql, object param = null, int? commandTimeout = null)
            => _context.ExecuteScalarAsync<TResult>(sql, param, commandTimeout);

        public Task<int> ExecuteAsync(string sql, object param = null, int? commandTimeout = null)
            => _context.ExecuteAsync(sql, param, commandTimeout);

        public Task<int> ExecuteAsync(string sql, int? commandTimeout = null)
            => _context.ExecuteAsync(sql, commandTimeout);

        public Task<T> QuerySingleOrDefaultAsync(string sql, object param = null, int? commandTimeout = null)
            => _context.QuerySingleOrDefaultAsync<T>(sql, param, commandTimeout);

        public Task<T> QueryFirstOrDefaultAsync(string sql, object param = null, int? commandTimeout = null)
            => _context.QueryFirstOrDefaultAsync<T>(sql, param, commandTimeout);


        //simpleCrud
        public int? Insert(T entity)
    => _context.Insert(entity);

        public T Get(object id)
            => _context.Get<T>(id);

        public IEnumerable<T> GetList(object whereConditions = null)
            => _context.GetList<T>(whereConditions);

        public int Update(T entity)
            => _context.Update(entity);

        public int Delete(T entity)
            => _context.Delete(entity);

        public int Delete(object id)
            => _context.Delete<T>(id);

        public int DeleteList(object whereConditions)
            => _context.DeleteList<T>(whereConditions);

        public int RecordCount(object whereConditions = null)
            => _context.RecordCount<T>(whereConditions);



        public Task<int?> InsertAsync(T entity)
    => _context.InsertAsync(entity);

        public Task<T> GetAsync(object id)
            => _context.GetAsync<T>(id);

        public Task<IEnumerable<T>> GetListAsync(object whereConditions = null)
            => _context.GetListAsync<T>(whereConditions);

        public Task<int> UpdateAsync(T entity)
            => _context.UpdateAsync(entity);

        public Task<int> DeleteAsync(T entity)
            => _context.DeleteAsync(entity);

        public Task<int> DeleteAsync(object id)
            => _context.DeleteAsync<T>(id);

        public Task<int> DeleteListAsync(object whereConditions)
            => _context.DeleteListAsync<T>(whereConditions);

        public Task<int> RecordCountAsync(object whereConditions = null)
            => _context.RecordCountAsync<T>(whereConditions);

    }
}
