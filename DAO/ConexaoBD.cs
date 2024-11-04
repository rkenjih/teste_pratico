using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.Common;

namespace DAO
{
	public class ConexaoBD
    {
        #region Métodos

        /// <summary>
        /// Cria um objeto de conexão com o Banco de Dados
        /// </summary>
        /// <returns>OracleConnection</returns>
        private OracleConnection Conectar()
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["OracleCS"].ConnectionString;
            OracleConnection conn = new OracleConnection(connection);
            return conn;
        }

        /// <summary>
        /// Executa uma conexão com o Banco e retorna um DataTable
        /// </summary>
        /// <param name="comando">Instrução SQL</param>
        /// <param name="tipo">Tipo de comando SQL</param>
        /// <returns>DataTable</returns>
        public DataTable Executar(string comando, CommandType tipo)
        {
            var conexao = new OracleConnection();
            var comandoOracle = conexao.CreateCommand();
            var dataTable = new DataTable();
            conexao = Conectar();
            comandoOracle.CommandText = comando;
            comandoOracle.CommandType = tipo;

            try
            {
                comandoOracle.Connection = conexao;
                OracleDataAdapter oDa = new OracleDataAdapter(comandoOracle);
                oDa.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }

                comandoOracle.Dispose();
                conexao.Dispose();
                throw ex;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }

                comandoOracle.Dispose();
                conexao.Dispose();
            }
        }

        /// <summary>
        /// Executa uma conexão parametrizada com o Banco e retorna um DataTable
        /// </summary>
        /// <param name="comando">Instrução SQL</param>
        /// <param name="tipo">Tipo de comando SQL</param>
        /// <param name="parametros">Parâmetros SQL</param>
        /// <returns>DataTable</returns>
        public DataTable Executar(string comando, CommandType tipo, params DbParameter[] parametros)
        {
            var conexao = new OracleConnection();
            var comandoOracle = conexao.CreateCommand();
            var dataTable = new DataTable();

            if (parametros != null && parametros.Length > 0)
            {
                foreach (DbParameter parametro in parametros)
                {
                    comandoOracle.Parameters.Add(parametro);
                }
            }

            conexao = Conectar();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            comandoOracle.CommandText = comando;
            comandoOracle.CommandType = tipo;

            try
            {
                comandoOracle.Connection = conexao;
                var adaptador = new OracleDataAdapter(comandoOracle);
                adaptador.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }

                comandoOracle.Dispose();
                conexao.Dispose();
                throw ex;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }

                comandoOracle.Dispose();
                conexao.Dispose();
            }
        }

        /// <summary>
        /// Executa uma conexão parametrizada com o Banco e retorna um Object
        /// </summary>
        /// <param name="comando">Instrução SQL</param>
        /// <param name="tipo">Tipo de comando SQL</param>
        /// <param name="campoRetorno">Campo de retorno da instrução (OUT)</param>
        /// <param name="parametros">Parâmetros SQL</param>
        /// <returns>object</returns>
        public object Executar(string comando, CommandType tipo, string campoRetorno, params DbParameter[] parametros)
        {
            var objeto = new object();
            var conexao = new OracleConnection();
            var comandoOracle = conexao.CreateCommand();

            if (parametros != null && parametros.Length > 0)
            {
                foreach (DbParameter p in parametros)
                {
                    comandoOracle.Parameters.Add(p);
                }
            }

            conexao = Conectar();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            comandoOracle.CommandText = comando;
            comandoOracle.CommandType = tipo;

            try
            {
                comandoOracle.Connection = conexao;
                comandoOracle.ExecuteNonQuery();
                int i = comandoOracle.Parameters.IndexOf(campoRetorno);

                if (i >= 0)
                {
                    objeto = comandoOracle.Parameters[i].Value;
                }

            }
            catch (Exception ex)
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }

                comandoOracle.Dispose();
                conexao.Dispose();
                throw ex;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }

                comandoOracle.Dispose();
                conexao.Dispose();
            }

            return objeto;
        }

        /// <summary>
        /// Executa uma conexão parametrizada com o Banco e não retorna valores
        /// </summary>
        /// <param name="comando">Instrução SQL</param>
        /// <param name="tipo">Tipo de comando SQL</param>
        /// <param name="parametros">Parâmetros SQL</param>
        public void ExecutarSemRetorno(string comando, CommandType tipo, params DbParameter[] parametros)
        {
            var conexao = new OracleConnection();
            var comandoOracle = conexao.CreateCommand();

            if (parametros != null && parametros.Length > 0)
            {
                foreach (DbParameter parametro in parametros)
                {
                    comandoOracle.Parameters.Add(parametro);
                }
            }

            conexao = Conectar();

            if (conexao.State == ConnectionState.Closed)
            {
                conexao.Open();
            }

            comandoOracle.CommandText = comando;
            comandoOracle.CommandType = tipo;

            try
            {
                comandoOracle.Connection = conexao;
                comandoOracle.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }

                comandoOracle.Dispose();
                conexao.Dispose();
                throw ex;
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }

                comandoOracle.Dispose();
                conexao.Dispose();
            }
        }

        #endregion
    }
}
