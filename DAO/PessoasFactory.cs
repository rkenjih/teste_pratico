using DAO.Abstraction;

namespace DAO
{
    public class PessoasFactory : IPessoasFactory
    {
        public IPESSOAS CreateInstance()
        {
            return new PESSOAS();
        }
    }
}