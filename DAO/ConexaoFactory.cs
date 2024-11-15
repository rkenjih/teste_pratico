using DAO.Abstraction;

namespace DAO
{
    public class ConexaoFactory : IConexaoFactory
    {
        public IConexaoBD CreateConexaoBD()
        {
            return new ConexaoBD();
        }
    }
}