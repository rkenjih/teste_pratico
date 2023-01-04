using System;
using System.Collections.Generic;
using System.Data;

namespace BLL
{
    public class PESSOAS
    {
        #region Campos

        private const string SELECT = @"
            SELECT COD_PESSOA,
                   NOME,
                   CPF,
                   RG,
                   TELEFONE,
                   EMAIL,
                   SEXO,
                   DATA_NASCIMENTO
              FROM TESTE.TB_TESTE_PESSOAS
        ";

        #endregion

        #region Métodos

        /// <summary>
        /// Carrega um registro a partir do seu ID.
        /// </summary>
        /// <param name="id">Chave primária</param>
        /// <returns>DAO.PESSOAS</returns>
        public DAO.PESSOAS Carregar(decimal id)
        {
            string sql = SELECT + " WHERE COD_PESSOA = :COD_PESSOA ";
            var parametros = new System.Data.Common.DbParameter[1];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("COD_PESSOA", id);
            var dataTable = new DAO.ConexaoBD().Executar(sql, CommandType.Text, parametros);

            if (dataTable.Rows.Count > 0)
            {
                return DAO.Conversor.ConverterParaObjeto<DAO.PESSOAS>(dataTable);
            }

            return null;
        }

        /// <summary>
        /// Adiciona um novo registro e retorna o novo objeto adicionado.
        /// </summary>
        /// <param name="entidade">DAO.PESSOAS</param>
        /// <returns>PESSOAS</returns>
        public DAO.PESSOAS Adicionar(DAO.PESSOAS entidade)
        {
            var parametros = new System.Data.Common.DbParameter[8];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("out_COD_PESSOA", -1);
            parametros[1] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_NOME", entidade.NOME);
            parametros[2] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_CPF", entidade.CPF);
            parametros[3] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_RG", entidade.RG);
            parametros[4] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_TELEFONE", entidade.TELEFONE);
            parametros[5] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_EMAIL", entidade.EMAIL);
            parametros[6] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_SEXO", entidade.SEXO);
            parametros[7] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_DATA_NASCIMENTO", entidade.DATA_NASCIMENTO);
            parametros[0].Direction = ParameterDirection.Output;
            new DAO.ConexaoBD().Executar("TESTE.DML_TB_TESTE_PESSOAS.INS_TB_TESTE_PESSOAS", CommandType.StoredProcedure, "out_COD_PESSOA", parametros);
            return Carregar(Convert.ToInt32(parametros[0].Value));
        }

        /// <summary>
        /// Edita um registro da entidade [PESSOAS].
        /// </summary>
        /// <param name="entidade">PESSOAS</param>
        public void Editar(DAO.PESSOAS entidade)
        {
            var parametros = new System.Data.Common.DbParameter[8];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_COD_PESSOA", entidade.COD_PESSOA);
            parametros[1] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_NOME", entidade.NOME);
            parametros[2] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_CPF", entidade.CPF);
            parametros[3] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_RG", entidade.RG);
            parametros[4] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_TELEFONE", entidade.TELEFONE);
            parametros[5] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_EMAIL", entidade.EMAIL);
            parametros[6] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_SEXO", entidade.SEXO);
            parametros[7] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_DATA_NASCIMENTO", entidade.DATA_NASCIMENTO);
            new DAO.ConexaoBD().ExecutarSemRetorno("TESTE.DML_TB_TESTE_PESSOAS.UPD_TB_TESTE_PESSOAS", CommandType.StoredProcedure, parametros);
        }

        /// <summary>
        /// Remove um registro da entidade [PESSOAS] a partir da sua chave primária (PK).
        /// </summary>
        /// <param name="id">Chave primária</param>
        public void Excluir(decimal id)
        {
            var parametros = new System.Data.Common.DbParameter[1];
            parametros[0] = new Oracle.ManagedDataAccess.Client.OracleParameter("in_COD_PESSOA", id);
            new DAO.ConexaoBD().ExecutarSemRetorno("TESTE.DML_TB_TESTE_PESSOAS.DEL_TB_TESTE_PESSOAS", CommandType.StoredProcedure, parametros);
        }

        /// <summary>
        /// Carrega todos os itens da entidade.
        /// </summary>
        /// <returns>List(DAO.PESSOAS)</returns>
        public List<DAO.PESSOAS> CarregarTodos()
        {
            var dataTable = new DAO.ConexaoBD().Executar(SELECT, CommandType.Text);

            if (dataTable.Rows.Count > 0)
            {
                return DAO.Conversor.ConverterParaLista<DAO.PESSOAS>(dataTable);
            }

            return null;
        }

        #endregion
    }
}
