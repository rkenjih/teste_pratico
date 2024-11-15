using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO.Abstraction;
using Microsoft.Practices.Unity;

namespace EISOL_TestePraticoWebForms
{
	public partial class Tarefa1 : System.Web.UI.Page
	{
		[Dependency]
        public IServico Servico { get; set; }

		[Dependency]
		public IPessoasFactory PessoasFactory { get; set; }

		[Dependency]
        public BLL.Abstraction.IPESSOAS BllPessoas { get; set; }

        protected void Page_Load(object sender, EventArgs e)
		{
			msgErro.Text = string.Empty;

			//var pessoas = new BLL.PESSOAS().CarregarTodos();
		}

		protected void btnGravar_Click(object sender, EventArgs e)
		{
			Servico.DoSomething();
			/**/
			if (!PessoaValida(msgErro))
			{
				msgErro.Visible = true;
				return;
			}

			var pessoa = PessoasFactory.CreateInstance();

            pessoa.NOME = txtNome.Text;
            pessoa.CPF = txtCpf.Text;
			pessoa.EMAIL = txtEmail.Text;
            pessoa.DATA_NASCIMENTO = Convert.ToDateTime(txtDataNascimento.Text);
			pessoa.TELEFONE = txtTelefone.Text;
            pessoa.SEXO = ddlSexo.SelectedValue;
            pessoa.RG = txtRg.Text;

            this.Gravar(pessoa);
		}

		/// <summary>
		/// Persistir os dados no Banco.
		/// </summary>
		/// <param name="pessoa">DAO.PESSOAS</param>
		private void Gravar(IPESSOAS pessoa)
		{
			// Se a pessoa for uma pessoa de verdade e feliz, com certeza ela será lembrada pelo banco de dados.
			BllPessoas.Adicionar(pessoa);
			this.Alertar();
			this.Limpar();
		}

		/// <summary>
		/// Apresentar o alerta de sucesso na operação.
		/// </summary>
		private void Alertar()
		{
			this.divAlerta.Visible = true;
		}

		/// <summary>
		/// Limpar os campos após a presistência dos dados.
		/// </summary>
		private void Limpar()
		{
            PercorrerControlesELimpar(this);
            
            msgErro.Text = string.Empty;
            msgErro.Visible = false;
		}
		
		private void PercorrerControlesELimpar(Control container)
		{
			foreach (Control control in container.Controls)
			{
				if (control is TextBox)
				{
					var txtBox = control as TextBox;
					txtBox.Text = string.Empty;
				}

				if (control is DropDownList)
				{
					var dropDownList = control as DropDownList;
					dropDownList.SelectedIndex = 0;
				}

				if (control.HasControls())
				{
					PercorrerControlesELimpar(control);
				}
			}
		}


        private bool PessoaValida(Label msglabel)
        {
            const string MsgInicial = "Erro, verifique o Campo: ";
	        
            var camposInvalidos = PercorrerControlesEValidar(this, new List<string>());

            msglabel.Text = $"{MsgInicial} {string.Join(", ", camposInvalidos)}";

            return !camposInvalidos.Any();
        }
        
        private IList<string> PercorrerControlesEValidar(Control container, IList<string> camposInvalidos)
        {
            const string ID_txtTelefone = "txtTelefone";
            const string ID_txtEmail = "txtEmail";
            const string TextBox_Prefix = "txt";
            const string DropDownList_Prefix = "ddl";

            foreach (Control control in container.Controls)
	        {
		        if (control is TextBox)
		        {
			        var txtBox = control as TextBox;

					if (txtBox.ID == ID_txtTelefone ||  txtBox.ID == ID_txtEmail)
						continue;

			        if (string.IsNullOrEmpty(txtBox.Text.Trim()))
				        camposInvalidos.Add(txtBox.ID.Replace(TextBox_Prefix, ""));
				
			        continue;
		        }
				
		        if (control is DropDownList)
		        {
			        var dropDownList = control as DropDownList;
			        if (dropDownList.SelectedIndex == 0)
				        camposInvalidos.Add(dropDownList.ID.Replace(DropDownList_Prefix, ""));
		        }

		        if (control.HasControls())
		        {
			        PercorrerControlesEValidar(control, camposInvalidos);
		        }
	        }

	        return camposInvalidos;
        }
        
	}

    public interface IServico
    {
        void DoSomething();
    }

    public class Servico : IServico
    {
        public void DoSomething()
        {
            
        }
    }
}