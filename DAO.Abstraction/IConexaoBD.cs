using System.Data;
using System.Data.Common;

namespace DAO.Abstraction
{
    public interface IConexaoFactory
    {
        IConexaoBD CreateConexaoBD();
    }
    public interface IConexaoBD
    {
        /// <summary>
        /// Executa uma conexão com o Banco e retorna um DataTable
        /// </summary>
        /// <param name="comando">Instrução SQL</param>
        /// <param name="tipo">Tipo de comando SQL</param>
        /// <returns>DataTable</returns>
        DataTable Executar(string comando, CommandType tipo);

        /// <summary>
        /// Executa uma conexão parametrizada com o Banco e retorna um DataTable
        /// </summary>
        /// <param name="comando">Instrução SQL</param>
        /// <param name="tipo">Tipo de comando SQL</param>
        /// <param name="parametros">Parâmetros SQL</param>
        /// <returns>DataTable</returns>
        DataTable Executar(string comando, CommandType tipo, params DbParameter[] parametros);

        /// <summary>
        /// Executa uma conexão parametrizada com o Banco e retorna um Object
        /// </summary>
        /// <param name="comando">Instrução SQL</param>
        /// <param name="tipo">Tipo de comando SQL</param>
        /// <param name="campoRetorno">Campo de retorno da instrução (OUT)</param>
        /// <param name="parametros">Parâmetros SQL</param>
        /// <returns>object</returns>
        object Executar(string comando, CommandType tipo, string campoRetorno, params DbParameter[] parametros);

        /// <summary>
        /// Executa uma conexão parametrizada com o Banco e não retorna valores
        /// </summary>
        /// <param name="comando">Instrução SQL</param>
        /// <param name="tipo">Tipo de comando SQL</param>
        /// <param name="parametros">Parâmetros SQL</param>
        void ExecutarSemRetorno(string comando, CommandType tipo, params DbParameter[] parametros);
    }
}