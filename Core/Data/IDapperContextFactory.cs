using System.Data;
using System.Data.Common;

namespace Core.Data
{
    public interface IDapperContextFactory
    {
        /// <summary>
        /// Crea una nuova istanza di DapperContext con una transazione esistente.
        /// </summary>
        /// <param name="existingTransaction">Transazione da usare per il contesto.</param>
        /// <returns>Istanza di DapperContext.</returns>
        IDapperContext CreateScope();

        /// <summary>
        /// Crea una nuova istanza di DapperContext con una nuova connessione e transazione.
        /// </summary>
        /// <param name="isolationLevel">Livello di isolamento della transazione.</param>
        /// <returns>Istanza di DapperContext.</returns>
        //DapperContext CreateScope2(IsolationLevel isolationLevel);
    }
}
