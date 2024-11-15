using System;
using System.Collections.Generic;
using System.Data;
using DAO.Abstraction;
using Microsoft.Practices.Unity;

namespace BLL
{
    public class CIDADES : BLL.Abstraction.ICIDADES
    {
        [Dependency]
        public IConversor Conversor { get; set; }

        [Dependency]
        public IConexaoFactory ConexaoFactory { get; set; }

        #region Campos

        private const string SELECT = @"
            SELECT COD_CIDADE, COD_UF, NOME FROM DEV.CIDADES
        ";

        #endregion

        #region Métodos

        /// <summary>
        /// Carrega um registro a partir do seu ID.
        /// </summary>
        /// <param name="id">Chave primária</param>
        /// <returns>DAO.CIDADES</returns>
        public ICIDADES Carregar(decimal id)
        {
            string sql = SELECT + " WHERE COD_CIDADE = :COD_CIDADE ";
            var parametros = new System.Data.Common.DbParameter[1];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("COD_CIDADE", id);
            var dataTable = ConexaoFactory.CreateConexaoBD().Executar(sql, CommandType.Text, parametros);

            if (dataTable.Rows.Count > 0)
            {
                return Conversor.ConverterParaObjeto<ICIDADES>(dataTable);
            }

            return null;
        }

        /// <summary>
        /// Adiciona um novo registro e retorna o novo objeto adicionado.
        /// </summary>
        /// <param name="entidade">DAO.CIDADES</param>
        /// <returns>UF</returns>
        public ICIDADES Adicionar(ICIDADES entidade)
        {
            var parametros = new System.Data.Common.DbParameter[3];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("out_COD_CIDADE", -1);
            parametros[1] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_COD_UF", entidade.COD_UF);
            parametros[2] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_NOME", entidade.NOME);
            parametros[0].Direction = ParameterDirection.Output;
            ConexaoFactory.CreateConexaoBD().Executar("DEV.DML_CIDADES.INS_CIDADES", CommandType.StoredProcedure, "out_COD_CIDADE", parametros);
            return Carregar(Convert.ToInt32(parametros[0].Value));
        }

        /// <summary>
        /// Edita um registro da entidade [UF].
        /// </summary>
        /// <param name="entidade">UF</param>
        public void Editar(ICIDADES entidade)
        {
            var parametros = new System.Data.Common.DbParameter[3];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_COD_CIDADE", entidade.COD_CIDADE);
            parametros[1] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_COD_UF", entidade.COD_UF);
            parametros[2] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_NOME", entidade.NOME);
            ConexaoFactory.CreateConexaoBD().ExecutarSemRetorno("DEV.DML_CIDADES.UPD_CIDADES", CommandType.StoredProcedure, parametros);
        }

        /// <summary>
        /// Remove um registro da entidade [UF] a partir da sua chave primária (PK).
        /// </summary>
        /// <param name="id">Chave primária</param>
        public void Excluir(decimal id)
        {
            var parametros = new System.Data.Common.DbParameter[1];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_COD_CIDADE", id);
            ConexaoFactory.CreateConexaoBD().ExecutarSemRetorno("DEV.DML_CIDADES.DEL_CIDADES", CommandType.StoredProcedure, parametros);
        }

        /// <summary>
        /// Carrega todos os itens da entidade.
        /// </summary>
        /// <returns>List(DAO.CIDADES)</returns>
        public IList<ICIDADES> CarregarTodos()
        {
            var dataTable = ConexaoFactory.CreateConexaoBD().Executar(SELECT, CommandType.Text);

            if (dataTable.Rows.Count > 0)
            {
                return Conversor.ConverterParaLista<ICIDADES>(dataTable);
            }

            return null;
        }

        /// <summary>
        /// Carrega todos os itens da entidade por UF
        /// </summary>
        /// <param name="codigoUF">Código da UF</param>
        /// <returns>List(DAO.CIDADES)</returns>
        public IList<ICIDADES> CarregarPorUF(int codigoUF) // <----------------------------------------------- Ei! Veja esse método aqui.
        {
            var parametros = new System.Data.Common.DbParameter[1];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_COD_UF", codigoUF);

            // Parece estar faltando algo nessa consulta SQL.
            // Dica: Observe o método Carregar pra ter uma iéia do que fazer! =D
            string sql = SELECT + " WHERE COD_UF = :COD_UF";

            var dataTable = ConexaoFactory.CreateConexaoBD().Executar(sql, CommandType.Text, parametros);

            if (dataTable.Rows.Count > 0)
            {
                return Conversor.ConverterParaLista<ICIDADES>(dataTable);
            }

            return null;
        }

        #endregion
    }

    public class BLLDependencyInjectionModule : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<Abstraction.ICIDADES, CIDADES>();
            Container.RegisterType<Abstraction.IPESSOAS, PESSOAS>();
            Container.RegisterType<Abstraction.IUF, UF>();
        }
    }
}
