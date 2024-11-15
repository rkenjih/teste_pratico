using System;

namespace DAO.Abstraction
{
    public interface IPessoasFactory
    {
        IPESSOAS CreateInstance();
    }
    public interface IPESSOAS
    {
        decimal COD_PESSOA { get; set; }
        string NOME { get; set; }
        string CPF { get; set; }
        string RG { get; set; }
        string TELEFONE { get; set; }
        string EMAIL { get; set; }
        string SEXO { get; set; }
        DateTime DATA_NASCIMENTO { get; set; }
    }
}