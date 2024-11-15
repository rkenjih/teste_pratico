using System.Collections.Generic;

namespace BLL.Abstraction
{
    public interface IUF
    {
        /// <summary>
        /// Carrega um registro a partir do seu ID.
        /// </summary>
        /// <param name="id">Chave primária</param>
        /// <returns>DAO.UF</returns>
        DAO.Abstraction.IUF Carregar(decimal id);

        /// <summary>
        /// Adiciona um novo registro e retorna o novo objeto adicionado.
        /// </summary>
        /// <param name="entidade">DAO.UF</param>
        /// <returns>UF</returns>
        DAO.Abstraction.IUF Adicionar(DAO.Abstraction.IUF entidade);

        /// <summary>
        /// Edita um registro da entidade [UF].
        /// </summary>
        /// <param name="entidade">UF</param>
        void Editar(DAO.Abstraction.IUF entidade);

        /// <summary>
        /// Remove um registro da entidade [UF] a partir da sua chave primária (PK).
        /// </summary>
        /// <param name="id">Chave primária</param>
        void Excluir(decimal id);

        /// <summary>
        /// Carrega todos os itens da entidade.
        /// </summary>
        /// <returns>List(DAO.UF)</returns>
        IList<DAO.Abstraction.IUF> CarregarTodos();
    }
}