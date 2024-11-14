using System;
using System.Collections.Generic;
using DAO;

namespace EISOL_TestePraticoWebForms
{
    public partial class Tarefa3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.CarregarControles();
            }
        }

        /// <summary>
        /// Carregar dados e povoar os controles
        /// </summary>
        private void CarregarControles()
        {
            // Povoando as Unidades da Federação.
            this.ddlUf.Items.Clear();
            this.ddlUf.DataSource = new BLL.UF().CarregarTodos();
            this.ddlUf.DataTextField = "NOME";
            this.ddlUf.DataValueField = "COD_UF";
            this.ddlUf.DataBind();

            // Povoando as Cidades
            CarregarCidades(new BLL.CIDADES().CarregarTodos());
        }

        protected void ddlUf_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codUf;

            if (int.TryParse(ddlUf.SelectedValue, out codUf))
                CarregarCidades(new BLL.CIDADES().CarregarPorUF(codUf));
        }

        private void CarregarCidades(IList<CIDADES> ddlCidadesDataSource)
        {
            this.ddlCidades.Items.Clear();
            this.ddlCidades.DataSource = ddlCidadesDataSource;
            this.ddlCidades.DataTextField = "NOME";
            this.ddlCidades.DataValueField = "COD_CIDADE";
            this.ddlCidades.DataBind();
        }
    }
}