using DAO.Abstraction;

namespace DAO
{
    public class CIDADES : ICIDADES
    {
        public decimal COD_CIDADE { get; set; }
        public decimal COD_UF { get; set; }
        public string NOME { get; set; }
    }
}
