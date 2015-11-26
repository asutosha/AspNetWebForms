<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="AlterarSenha.aspx.cs" Inherits="CRUD.Web.Admin.Pages.AlterarSenha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudoPrincipal" runat="server">

    <div class="row">

        <h3>Alterar Senha</h3>
        <a href="../Default.aspx">Voltar</a>
        <hr />

        <div class="col-xs-3">

            <label>Senha Antiga:</label>
            <br />
            <asp:TextBox ID="txtSenhaAntiga" runat="server" CssClass="form-control" TextMode="Password" placeholder="Digite aqui."></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="reqSenhaAntiga" 
                runat="server"
                ErrorMessage="Por favor, informe a senha antiga."
                ControlToValidate="txtSenhaAntiga"
                ForeColor="Red"
                Display="Dynamic"
                />
            <br />

            <label>Senha Nova:</label>
            <br />
            <asp:TextBox ID="txtSenhaNova" runat="server" CssClass="form-control" TextMode="Password" placeholder="Digite aqui."></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="reqSenhaNova"
                runat="server"
                ErrorMessage="Por favor, insira a nova senha."
                ControlToValidate="txtSenhaNova"
                ForeColor="Red"
                Display="Dynamic"
                />
            <br />

            <label>Confirme a Senha:</label>
            <br />
            <asp:TextBox ID="txtSenhaConfirm" runat="server" CssClass="form-control" TextMode="Password" placeholder="Digite aqui."></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="reqSenhaConfirm"
                runat="server"
                ErrorMessage="Por favor, confirme a nova senha."
                ControlToValidate="txtSenhaConfirm"
                ForeColor="Red"
                Display="Dynamic"
                />
            <asp:CompareValidator
                ID="senhaConfirm"
                runat="server"
                ErrorMessage="Senhas não conferem."
                ControlToValidate="txtSenhaConfirm"
                ControlToCompare="txtSenhaNova"
                ForeColor="Purple"
                Display="Dynamic"
                />
            <br />

            <asp:Button ID="btnAlterarSenha" runat="server" Text="Alterar Senha" CssClass="btn btn-primary btn-block" OnClick="btnAlterarSenha_Click" />
            <br />

            <asp:Label ID="lblMensagem" runat="server"></asp:Label>

        </div>

    </div>

</asp:Content>
