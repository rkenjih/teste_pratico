using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace DAO.Abstraction
{
    public interface IConversor
    {
        T ConverterParaObjeto<T>(DataTable dataTable);
        IList<T> ConverterParaLista<T>(DataTable dataTable);

        IDictionary<Key, Value> ConverterParaDicionario<Key, Value>(DataTable dataTable, Func<DataRow, Key> chave, Func<DataRow, Value> valor);

        IList<DataRow> ConverterParaListaGenerica(DataTable dataTable);

        string ConverterParametrosString(IList<string> lista);

        DataTable ConverterParaDatatable(IEnumerable fonteDados);

    }
}