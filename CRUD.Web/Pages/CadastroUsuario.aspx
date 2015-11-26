<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="CadastroUsuario.aspx.cs" Inherits="CRUD.Web.Pages.CadastroUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudoPrincipal" runat="server">

    <div class="row">

        <h3>Cadastro de Usuário</h3>
        <a href="Login.aspx">Voltar para tela de login</a>
        <hr />

        <div class="col-xs-4 well">

            <label>Nome:</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="reqNome"
                runat="server"
                ControlToValidate="txtNome"
                ErrorMessage="Por favor, infome o nome."
                ForeColor="Red"
                Display="Dynamic"
            />
            <asp:RegularExpressionValidator
                ID="regexNome"
                runat="server"
                ControlToValidate="txtNome"
                ValidationExpression="^[A-Za-zÀ-Üà-ü\s]{6,50}$"
                ErrorMessage="Formato de nome inválido."
                ForeColor="Purple"
                Display="Dynamic"
            />
            <br />

            <label>E-mail:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="reqEmail"
                runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="Por favor, infome o e-mail."
                ForeColor="Red"
                Display="Dynamic"
            />
            <asp:RegularExpressionValidator
                ID="regexEmail"
                runat="server"
                ControlToValidate="txtEmail"
                ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                ErrorMessage="Formato de e-mail inválido."
                ForeColor="Purple"
                Display="Dynamic"
            />
            <br />

            <label>Usuário:</label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="reqUsuario"
                runat="server"
                ControlToValidate="txtUsuario"
                ErrorMessage="Por favor, infome o usuário."
                ForeColor="Red"
                Display="Dynamic"
            />
            <asp:RegularExpressionValidator
                ID="regexUsuario"
                runat="server"
                ControlToValidate="txtUsuario"
                ValidationExpression="^[A-Za-zÀ-Üà-ü0-9]{6,25}$"
                ErrorMessage="Formato de login de usuário inválido."
                ForeColor="Purple"
                Display="Dynamic"
            />
            <br />

            <label>Senha:</label>
            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="reqSenha"
                runat="server"
                ControlToValidate="txtSenha"
                ErrorMessage="Por favor, infome a senha."
                ForeColor="Red"
                Display="Dynamic"
            />
            <asp:RegularExpressionValidator
                ID="regexSenha"
                runat="server"
                ControlToValidate="txtSenha"
                ValidationExpression="^[A-Za-zÀ-Üà-ü0-9]{6,20}$"
                ErrorMessage="Formato de senha inválido."
                ForeColor="Purple"
                Display="Dynamic"
            />
            <br />

            <label>Confirme a senha:</label>
            <asp:TextBox ID="txtSenhaConfirm" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="reqSenhaConfirm"
                runat="server"
                ControlToValidate="txtSenhaConfirm"
                ErrorMessage="Por favor, infome a confirmação de senha."
                ForeColor="Red"
                Display="Dynamic"
            />
            <asp:CompareValidator
                ID="compareSenha"
                runat="server"
                ControlToValidate="txtSenhaConfirm"
                ErrorMessage="Erro. Senhas não conferem."
                ForeColor="Purple"
                Display="Dynamic"
                ControlToCompare="txtSenha" 
            />
            <br />
            <br />

            <asp:Button ID="btnCadastro" Text="Criar Conta de Usuário" runat="server" CssClass="btn btn-success btn-block" OnClick="btnCadastro_Click" />
            <br />

            <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>

        </div>

    </div>

</asp:Content>
