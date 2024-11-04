using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class UF
    {
        #region Campos

        private const string SELECT = @"
            SELECT COD_UF, NOME FROM DBAODB.TESTE_DEV_UF
        ";

        #endregion

        #region Métodos

        /// <summary>
        /// Carrega um registro a partir do seu ID.
        /// </summary>
        /// <param name="id">Chave primária</param>
        /// <returns>DAO.UF</returns>
        public DAO.UF Carregar(decimal id)
        {
            string sql = SELECT + " WHERE COD_UF = :COD_UF ";
            var parametros = new System.Data.Common.DbParameter[1];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("COD_UF", id);
            var dataTable = new DAO.ConexaoBD().Executar(sql, CommandType.Text, parametros);

            if (dataTable.Rows.Count > 0)
            {
                return DAO.Conversor.ConverterParaObjeto<DAO.UF>(dataTable);
            }

            return null;
        }

        /// <summary>
        /// Adiciona um novo registro e retorna o novo objeto adicionado.
        /// </summary>
        /// <param name="entidade">DAO.UF</param>
        /// <returns>UF</returns>
        public DAO.UF Adicionar(DAO.UF entidade)
        {
            var parametros = new System.Data.Common.DbParameter[2];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("out_COD_UF", -1);
            parametros[1] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_NOME", entidade.NOME);
            parametros[0].Direction = ParameterDirection.Output;
            new DAO.ConexaoBD().Executar("DBAODB.DML_TESTE_DEV_UF.INS_TESTE_DEV_UF", CommandType.StoredProcedure, "out_COD_UF", parametros);
            return Carregar(Convert.ToInt32(parametros[0].Value));
        }

        /// <summary>
        /// Edita um registro da entidade [UF].
        /// </summary>
        /// <param name="entidade">UF</param>
        public void Editar(DAO.UF entidade)
        {
            var parametros = new System.Data.Common.DbParameter[2];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_COD_UF", entidade.COD_UF);
            parametros[1] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_NOME", entidade.NOME);
            new DAO.ConexaoBD().ExecutarSemRetorno("DBAODB.DML_TESTE_DEV_UF.UPD_TESTE_DEV_UF", CommandType.StoredProcedure, parametros);
        }

        /// <summary>
        /// Remove um registro da entidade [UF] a partir da sua chave primária (PK).
        /// </summary>
        /// <param name="id">Chave primária</param>
        public void Excluir(decimal id)
        {
            var parametros = new System.Data.Common.DbParameter[1];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_COD_UF", id);
            new DAO.ConexaoBD().ExecutarSemRetorno("DBAODB.DML_TESTE_DEV_UF.DEL_TESTE_DEV_UF", CommandType.StoredProcedure, parametros);
        }

        /// <summary>
        /// Carrega todos os itens da entidade.
        /// </summary>
        /// <returns>List(DAO.UF)</returns>
        public List<DAO.UF> CarregarTodos()
        {
            var dataTable = new DAO.ConexaoBD().Executar(SELECT, CommandType.Text);

            if (dataTable.Rows.Count > 0)
            {
                return DAO.Conversor.ConverterParaLista<DAO.UF>(dataTable);
            }

            return null;
        }

        #endregion
    }
}
