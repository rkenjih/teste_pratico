
using DAO.Abstraction;
using Microsoft.Practices.Unity;

namespace DAO
{
    public class DAODependencyInjectionModule : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<ICIDADES, CIDADES>();
            Container.RegisterType<IConexaoBD, ConexaoBD>();
            Container.RegisterType<IConexaoFactory, ConexaoFactory>();
            Container.RegisterType<IConversor, ConversorSingleton>();
            Container.RegisterType<IPESSOAS, PESSOAS>();
            Container.RegisterType<IPessoasFactory, PessoasFactory>();
            Container.RegisterType<IUF, UF>();
        }
    }
}
