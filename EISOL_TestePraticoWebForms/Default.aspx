<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EISOL_TestePraticoWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Teste Prático ASP.NET WebForms</h1>
        <p class="lead">Você está diante do maior desafio da sua vida! Execute as tarefas para alcançar o cálice sagrado dos grandes guerreiros e seja imortalizado pelas mãos das Valquírias até Valhalla!</p>
        <small>Na verdade, apenas faça os testes práticos e avise quando terminar =D</small>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Tarefa 1</h2>
            <p>
                Entre de cabeça no mundo sombrio do Server Side, mas cuidado! Não trilhe o caminho da escuridão Sith. Conheça os controles e descubra como utilizar a força da luz para iluminar o seu código até a aprovação final.
            </p>
            <p>
                <a class="btn btn-default" href="Tarefa1.aspx">Iniciar &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Tarefa 2</h2>
            <p>
               Entre o caos e o mundo perfeito surge o Client Side. Beleza exagerei, mas que ele é importante nos sistemas web isso é indiscutível. Mostre-nos o poder que o Client Side pode exercer sobre os usuário e como eles podem torná-los mais felizes. ;D
            </p>
            <p>
                <a class="btn btn-default" href="Tarefa2.aspx">Iniciar &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Tarefa 3</h2>
            <p>
                É muito importante aprender e desenvolver as técnicas do Leviatã. Ela consiste em executar funções após o término de uma função anterior. Apresente a sua sabedoria sobre os controles em cascata que podem ser criados com WebForms.
            </p>
            <p>
                <a class="btn btn-default" href="Tarefa3.aspx">Iniciar &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
