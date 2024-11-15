using System;
using System.Collections.Generic;
using System.Data;
using DAO.Abstraction;
using Microsoft.Practices.Unity;

namespace BLL
{
    public class UF : BLL.Abstraction.IUF
    {
        [Dependency]
        public IConexaoFactory ConexaoFactory { get; set; }

        [Dependency]
        public IConversor Conversor { get; set; }

        #region Campos

        private const string SELECT = @"
            SELECT COD_UF, NOME FROM DEV.UF
        ";

        #endregion

        #region Métodos

        /// <summary>
        /// Carrega um registro a partir do seu ID.
        /// </summary>
        /// <param name="id">Chave primária</param>
        /// <returns>DAO.UF</returns>
        public IUF Carregar(decimal id)
        {
            string sql = SELECT + " WHERE COD_UF = :COD_UF ";
            var parametros = new System.Data.Common.DbParameter[1];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("COD_UF", id);
            var dataTable = ConexaoFactory.CreateConexaoBD().Executar(sql, CommandType.Text, parametros);

            if (dataTable.Rows.Count > 0)
            {
                return Conversor.ConverterParaObjeto<IUF>(dataTable);
            }

            return null;
        }

        /// <summary>
        /// Adiciona um novo registro e retorna o novo objeto adicionado.
        /// </summary>
        /// <param name="entidade">DAO.UF</param>
        /// <returns>UF</returns>
        public IUF Adicionar(IUF entidade)
        {
            var parametros = new System.Data.Common.DbParameter[2];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("out_COD_UF", -1);
            parametros[1] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_NOME", entidade.NOME);
            parametros[0].Direction = ParameterDirection.Output;
            ConexaoFactory.CreateConexaoBD().Executar("DEV.DML_UF.INS_UF", CommandType.StoredProcedure, "out_COD_UF", parametros);
            return Carregar(Convert.ToInt32(parametros[0].Value));
        }

        /// <summary>
        /// Edita um registro da entidade [UF].
        /// </summary>
        /// <param name="entidade">UF</param>
        public void Editar(IUF entidade)
        {
            var parametros = new System.Data.Common.DbParameter[2];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_COD_UF", entidade.COD_UF);
            parametros[1] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_NOME", entidade.NOME);
            ConexaoFactory.CreateConexaoBD().ExecutarSemRetorno("DEV.DML_UF.UPD_UF", CommandType.StoredProcedure, parametros);
        }

        /// <summary>
        /// Remove um registro da entidade [UF] a partir da sua chave primária (PK).
        /// </summary>
        /// <param name="id">Chave primária</param>
        public void Excluir(decimal id)
        {
            var parametros = new System.Data.Common.DbParameter[1];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_COD_UF", id);
            ConexaoFactory.CreateConexaoBD().ExecutarSemRetorno("DEV.DML_UF.DEL_UF", CommandType.StoredProcedure, parametros);
        }

        /// <summary>
        /// Carrega todos os itens da entidade.
        /// </summary>
        /// <returns>List(DAO.UF)</returns>
        public IList<IUF> CarregarTodos()
        {
            var dataTable = ConexaoFactory.CreateConexaoBD().Executar(SELECT, CommandType.Text);

            if (dataTable.Rows.Count > 0)
            {
                return Conversor.ConverterParaLista<IUF>(dataTable);
            }

            return null;
        }

        #endregion
    }
}
