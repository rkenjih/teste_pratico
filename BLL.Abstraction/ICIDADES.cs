using System.Collections.Generic;

namespace BLL.Abstraction
{
    public interface ICIDADES
    {
        /// <summary>
        /// Carrega um registro a partir do seu ID.
        /// </summary>
        /// <param name="id">Chave primária</param>
        /// <returns>DAO.CIDADES</returns>
        DAO.Abstraction.ICIDADES Carregar(decimal id);

        /// <summary>
        /// Adiciona um novo registro e retorna o novo objeto adicionado.
        /// </summary>
        /// <param name="entidade">DAO.CIDADES</param>
        /// <returns>UF</returns>
        DAO.Abstraction.ICIDADES Adicionar(DAO.Abstraction.ICIDADES entidade);

        /// <summary>
        /// Edita um registro da entidade [UF].
        /// </summary>
        /// <param name="entidade">UF</param>
        void Editar(DAO.Abstraction.ICIDADES entidade);

        /// <summary>
        /// Remove um registro da entidade [UF] a partir da sua chave primária (PK).
        /// </summary>
        /// <param name="id">Chave primária</param>
        void Excluir(decimal id);

        /// <summary>
        /// Carrega todos os itens da entidade.
        /// </summary>
        /// <returns>List(DAO.CIDADES)</returns>
        IList<DAO.Abstraction.ICIDADES> CarregarTodos();

        /// <summary>
        /// Carrega todos os itens da entidade por UF
        /// </summary>
        /// <param name="codigoUF">Código da UF</param>
        /// <returns>List(DAO.CIDADES)</returns>
        IList<DAO.Abstraction.ICIDADES> CarregarPorUF(int codigoUF);
    }
}