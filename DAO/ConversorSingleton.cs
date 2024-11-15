using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using DAO.Abstraction;

namespace DAO
{
    public class ConversorSingleton : IConversor
    {
        #region Métodos

        /// <summary>
        /// Converte um único item do DataTable em um objeto tipado.
        /// <para>DataTable ---> T</para>
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="dataTable">DataTable fonte de dados</param>
        /// <returns>Objeto tipado</returns>
        /// <author>FRR201502121447</author>
        public T ConverterParaObjeto<T>(DataTable dataTable)
        {
            return CarregarItem<T>(dataTable.Rows[0]);
        }

        /// <summary>
        /// Converte um DataTable para uma lista tipada.
        /// <para>DataTable ---> List(T)</para>
        /// </summary>
        /// <typeparam name="T">Tipo do objeto</typeparam>
        /// <param name="dataTable">DataTable fonte de dados</param>
        /// <returns>Lista tipada</returns>
        /// <author>FRR201502121447</author>
        public IList<T> ConverterParaLista<T>(DataTable dataTable)
        {
            List<T> listaGenerica = new List<T>();

            foreach (DataRow linha in dataTable.Rows)
            {
                T item = CarregarItem<T>(linha);
                listaGenerica.Add(item);
            }

            return listaGenerica;
        }

        /// <summary>
        /// Converter DataTable para Dictionary.
        /// <para>DataTable ---> Dictionary(T, T)</para>
        /// </summary>
        /// <typeparam name="TKey">Tipo da Key</typeparam>
        /// <typeparam name="TRow">Tipo do Value</typeparam>
        /// <param name="dataTable">Fonte de dados ou DataTable</param>
        /// <param name="chave">Item do DataTable que representará a chave do dicionário</param>
        /// <param name="valor">Item do DataTable que representará o valor do dicionário</param>
        /// <returns>Dictionary(T, T)</returns>
        /// <author>FRR201511131110</author>
        public IDictionary<Key, Value> ConverterParaDicionario<Key, Value>(DataTable dataTable, Func<DataRow, Key> chave, Func<DataRow, Value> valor)
        {
            return dataTable.Rows.OfType<DataRow>().ToDictionary(chave, valor);
        }

        /// <summary>
        /// Converte um DataTable para uma lista genérica contendo DataRow's
        /// </summary>
        /// <param name="dataTable">Fonte de dados DataTable</param>
        /// <returns>List(DataRow)</returns>
        /// <author>FRR201511131110</author>
        public IList<DataRow> ConverterParaListaGenerica(DataTable dataTable)
        {
            var lista = new List<DataRow>();

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow linha in dataTable.Rows)
                {
                    lista.Add((DataRow)linha);
                }

                return lista;
            }

            return null;
        }

        /// <summary>
        /// Raliza a leitua de cada item para identificar o seu tipo.
        /// </summary>
        /// <typeparam name="T">Tipo da propriedade</typeparam>
        /// <param name="dataRow">Item do DataTable que será convertido para o tipo da entidade correspondente</param>
        /// <returns>Tipo da propriedade</returns>
        /// <author>FRR201502121447</author>
        private T CarregarItem<T>(DataRow dataRow)
        {
            Type tipoObjeto = typeof(T);
            T objetoTipado = Activator.CreateInstance<T>();

            foreach (DataColumn coluna in dataRow.Table.Columns)
            {
                foreach (PropertyInfo propriedade in tipoObjeto.GetProperties())
                {
                    if (propriedade.Name == coluna.ColumnName)
                    {
                        // Tratamento para não tentar colocar um DBNull.Value dentro de uma String.
                        if (coluna.DataType.Name == "String" && dataRow[coluna.ColumnName] == DBNull.Value)
                        {
                            propriedade.SetValue(objetoTipado, string.Empty, null);
                            continue;
                        }

                        if (dataRow[coluna.ColumnName] == DBNull.Value)
                        {
                            propriedade.SetValue(objetoTipado, null, null);
                            continue;
                        }

                        propriedade.SetValue(objetoTipado, dataRow[coluna.ColumnName], null);
                        break;
                    }
                }
            }

            return objetoTipado;
        }

        /// <summary>
        /// Converte uma lista de strings em uma única string de texto com os itens concatenados por vígula.
        /// </summary>
        /// <param name="lista">Lista de string</param>
        /// <returns>String</returns>
        public string ConverterParametrosString(IList<string> lista)
        {
            string listaParametros = string.Empty;

            foreach (var item in lista)
            {
                listaParametros += string.Format("'{0}',", item);
            }

            if (listaParametros != string.Empty)
            {
                return listaParametros.Substring(0, listaParametros.Length - 1);
            }

            return listaParametros;
        }

        /// <summary>
        /// Converte uma Lista Genérica (System.Collections.Generic) em DataTable. 
        /// </summary>
        /// <param name="fonteDados">Lista genérica</param>
        /// <returns>DataTable</returns>
        public DataTable ConverterParaDatatable(IEnumerable fonteDados)
        {
            DataTable tabela = new DataTable();

            foreach (var item in fonteDados)
            {
                foreach (var prop in item.GetType().GetProperties())
                {
                    tabela.Columns.Add(prop.Name);
                }

                break;
            }

            foreach (var item in fonteDados)
            {
                DataRow novaLinha = tabela.NewRow();

                foreach (var prop in item.GetType().GetProperties())
                {
                    var nomeColuna = prop.Name;
                    var valorColuna = prop.GetValue(item, null);
                    novaLinha[nomeColuna] = valorColuna ?? DBNull.Value;
                }

                tabela.Rows.Add(novaLinha);
            }

            return tabela;
        }

        #endregion
    }
}