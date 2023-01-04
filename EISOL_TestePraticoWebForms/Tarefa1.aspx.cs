using System;

namespace EISOL_TestePraticoWebForms
{
    public partial class Tarefa1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Para saber se o seu registro foi realmente adicionado à tabela, utilize um dos métodos de BLL.PESSOAS.
            // Você poderá realizar a depuração aqui no VS e conferir se tudo deu certo.
            // Sinta-se livre para fazer a sua arte, mas tente fazer o formulário funcionar ok!
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            /* Olá!
             * Trabalhamos com camadas de acesso a dados e negócios, isso também é conhecido por arquitetura em camadas ou N-Tier.
             * Observe que passamos um objeto tipado da camada de acesso (DAO - Data Access Object).
             * E devemos utilizar esse objeto DAO e chamar os métodos da camada de negócios (BLL - Business Logical Layer).
             * É o que por padrão o MVC te induz a fazer, mas aqui no WebForms devemos ter esse cuidado para não dificultar as coisas criando códigos macarrônicos (eita).
             * Você está livre para espiar os códigos e entender o seu funcionamento.
             * Só não vai me bagunçar os códigos pois deu muito trabalho fazer tudo isso aqui =/
             * */
            var pessoa = new DAO.PESSOAS();

            // Parece que faltam algumas coisas aqui! =/

            // O Objeto pessoa não parece ser uma pessoa de verdade ainda. 
            // As pessoas não são objetos mas aqui podemos considerá-las assim =S
            // - Faça as devidas atribuições ao objeto 'pessoa' para que ela seja uma pessoa de verdade e feliz!


            // Verifique os tamanhos dos campos da tabela e a obrigatoriedade deles e faça o devido tratamento para evitar erros.
            // - O leiaute da tabela em questão (TB_TESTE_PESSOAS) poderá ser verificado nos arquivos .sql anexados ao projeto.

            // Coloque o seu lindo código aqui! (O_o)
            this.Gravar(pessoa);
        }

        /// <summary>
        /// Persistir os dados no Banco.
        /// </summary>
        /// <param name="pessoa">DAO.PESSOAS</param>
        private void Gravar(DAO.PESSOAS pessoa)
        {
            // Teste
            // Se a pessoa for uma pessoa de verdade e feliz, com certeza ela será lembrada pelo banco de dados.
            new BLL.PESSOAS().Adicionar(pessoa);
            this.Alertar();
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
            // Isso é apenas um bônus!
            // Tente fazê-lo e colocar em um lugar apropriado no código.
        }
    }
}