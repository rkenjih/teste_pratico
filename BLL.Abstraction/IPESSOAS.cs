using System.Collections.Generic;

namespace BLL.Abstraction
{
    public interface IPESSOAS
    {
        /// <summary>
        /// Carrega um registro a partir do seu ID.
        /// </summary>
        /// <param name="id">Chave primária</param>
        /// <returns>DAO.PESSOAS</returns>
        DAO.Abstraction.IPESSOAS Carregar(decimal id);

        /// <summary>
        /// Adiciona um novo registro e retorna o novo objeto adicionado.
        /// </summary>
        /// <param name="entidade">DAO.PESSOAS</param>
        /// <returns>PESSOAS</returns>
        DAO.Abstraction.IPESSOAS Adicionar(DAO.Abstraction.IPESSOAS entidade);

        /// <summary>
        /// Edita um registro da entidade [PESSOAS].
        /// </summary>
        /// <param name="entidade">PESSOAS</param>
        void Editar(DAO.Abstraction.IPESSOAS entidade);

        /// <summary>
        /// Remove um registro da entidade [PESSOAS] a partir da sua chave primária (PK).
        /// </summary>
        /// <param name="id">Chave primária</param>
        void Excluir(decimal id);

        /// <summary>
        /// Carrega todos os itens da entidade.
        /// </summary>
        /// <returns>List(DAO.PESSOAS)</returns>
        IList<DAO.Abstraction.IPESSOAS> CarregarTodos();
    }
}