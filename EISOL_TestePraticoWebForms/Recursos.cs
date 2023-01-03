using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Web.UI.WebControls;

namespace EISOL_TestePraticoWebForms
{
    public class Recursos
    {
        /// <summary>
        /// Converte uma fonte de dados IList em uma ListItemCollection.
        /// </summary>
        /// <param name="fonteDados">Fonte de dados</param>
        /// <param name="campoValor">Valor do item</param>
        /// <param name="campoTexto">Texto do item</param>
        /// <returns>ListItemCollection</returns>
        /// <author>FRR201502131554</author>
        public static ListItemCollection ConverterParaListItemCollection(IList fonteDados, string campoValor, string campoTexto)
        {
            if (fonteDados != null && fonteDados.Count > 0)
            {
                var lista = new ListItemCollection();

                foreach (var item in fonteDados)
                {
                    lista.Add(new ListItem()
                    {
                        Value = item.GetType().GetProperty(campoValor).GetValue(item, null).ToString(),
                        Text = item.GetType().GetProperty(campoTexto).GetValue(item, null).ToString()
                    });
                }

                return lista;
            }

            return null;
        }

        /// <summary>
        /// Converte uma fonte de dados List(string) em uma ListItemCollection.
        /// </summary>
        /// <param name="fonteDados">Fonte de dados</param>
        /// <returns>ListItemCollection</returns>
        /// <author>FRR201511131428</author>
        public static ListItemCollection ConverterParaListItemCollection(List<string> fonteDados)
        {
            if (fonteDados != null && fonteDados.Count > 0)
            {
                var lista = new ListItemCollection();

                foreach (var item in fonteDados)
                {
                    lista.Add(new ListItem()
                    {
                        Value = item,
                        Text = item
                    });
                }

                return lista;
            }

            return null;
        }

        /// <summary>
        /// Converte uma fonte de dados DataTable em uma ListItemCollection.
        /// </summary>
        /// <param name="fonteDados">Fonte de dados</param>
        /// <param name="campoValor">Valor do item</param>
        /// <param name="campoTexto">Texto do item</param>
        /// <returns>ListItemCollection</returns>
        /// <author>FRR201504290749</author>
        public static ListItemCollection ConverterParaListItemCollection(DataTable fonteDados, string campoValor, string campoTexto)
        {
            if (fonteDados != null && fonteDados.Rows.Count > 0)
            {
                var lista = new ListItemCollection();

                for (int i = 0, max = fonteDados.Rows.Count; i < max; i++)
                {
                    lista.Add(new ListItem()
                    {
                        Value = fonteDados.Rows[i][campoValor].ToString(),
                        Text = fonteDados.Rows[i][campoTexto].ToString()
                    });
                }

                return lista;
            }

            return null;
        }

        /// <summary>
        /// Povoa um controle que herda do ListControl e povoa com os dados informados.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto que herda do ListControl</typeparam>
        /// <param name="controle">Controle que herda do ListControl</param>
        /// <param name="fonteDados">ListItemCollection de dados</param>
        /// <param name="possuiItemPadrao">Controle possui item padrão</param>
        /// <param name="padrao">Texto do item padrão</param>
        /// <returns>Objeto de acordo com o tipo informado e povoado com a fonte de dados</returns>
        /// <author>FRR201502131559</author>
        public static T PovoarControle<T>(object controle, ListItemCollection fonteDados, bool possuiItemPadrao = false, string padrao = "[Selecione]")
        {
            if (fonteDados == null)
            {
                fonteDados = new ListItemCollection();
                fonteDados.Add(new ListItem() { Value = string.Empty, Text = "[Nenhum item encontrado]", Selected = true, Enabled = false });
            }
            else
            {
                if (possuiItemPadrao)
                {
                    fonteDados.Insert(0, new ListItem { Text = padrao, Value = string.Empty, Selected = true });
                }
            }

            T objetoTipado = Activator.CreateInstance<T>();
            PropertyInfo propriedade;
            MethodInfo metodo;
            objetoTipado = (T)controle;
            propriedade = objetoTipado.GetType().GetProperty("Items");
            metodo = propriedade.PropertyType.GetMethod("Clear");
            metodo.Invoke(propriedade.GetValue(objetoTipado, null), null);
            propriedade = objetoTipado.GetType().GetProperty("DataValueField");
            propriedade.SetValue(objetoTipado, "Value", null);
            propriedade = objetoTipado.GetType().GetProperty("DataTextField");
            propriedade.SetValue(objetoTipado, "Text", null);
            propriedade = objetoTipado.GetType().GetProperty("DataSource");
            propriedade.SetValue(objetoTipado, fonteDados, null);
            metodo = objetoTipado.GetType().GetMethod("DataBind");
            metodo.Invoke(objetoTipado, null);
            return objetoTipado;
        }

        /// <summary>
        /// Converte uma lista de strings em uma única string de texto com os itens concatenados por vígula.
        /// </summary>
        /// <param name="lista">Lista de string</param>
        /// <returns>String</returns>
        public static string ConverterParametrosString(List<string> lista)
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
        public static DataTable ConverterParaDatatable(IEnumerable fonteDados)
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
    }
}