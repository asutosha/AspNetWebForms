<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="DetalheCliente.aspx.cs" Inherits="CRUD.Web.Admin.Pages.DetalheCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudoPrincipal" runat="server">

    <h3>Detalhes do Cliente</h3>
    <a href="PesquisaCliente.aspx">Ir para Pesquisa de Clientes</a>
    <hr />

    <div class="row">

        <div class="col-xs-4">

            <label>Código do Cliente</label><br />
            <asp:TextBox ID="txtIdCliente" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <br />

            <label>Nome:</label><br />
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqNome" runat="server" 
                ControlToValidate="txtNome" 
                ErrorMessage="Por favor, informe o Nome." 
                ForeColor="Red"
                Display="Dynamic" />
            <br />

            <label>RG:</label><br />
            <asp:TextBox ID="txtRg" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqRg" runat="server"
                ControlToValidate="txtRg"
                ErrorMessage="Por favor, informe o RG."
                ForeColor="Red"
                Display="Dynamic" />            
            <asp:RegularExpressionValidator ID="regexpRg" runat="server"
                ErrorMessage="RG inválido."
                ControlToValidate="txtRg"
                ValidationExpression="^[0-9\s]{9,9}$"
                ForeColor="Red"
                Display="Dynamic" />            
            <br />

            <label>CPF:</label><br />
            <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqCpf" runat="server" 
                ControlToValidate="txtCpf" 
                ErrorMessage="Por favor, informe o CPF." 
                ForeColor="Red"
                Display="Dynamic" />
            <asp:RegularExpressionValidator ID="regexCpf" runat="server"
                ErrorMessage="CPF inválido."
                ControlToValidate="txtCpf"
                ValidationExpression="^[0-9\s]{11,11}$"
                ForeColor="Red"
                Display="Dynamic" />
            <br />

            <label>Data de Cadastro:</label><br />
            <asp:TextBox ID="txtDataCadastro" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            <br />

        </div>

        <div class="col-xs-4">

            <label>Descrição do Endereço:</label><br />
            <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqDescricao" runat="server" 
                ControlToValidate="txtDescricao" 
                ErrorMessage="Por favor, informe o Endereço." 
                ForeColor="Red" 
                Display="Dynamic" />
            <br />

            <label>Bairro:</label><br />
            <asp:TextBox ID="txtBairro" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqBairro" runat="server" 
                ControlToValidate="txtBairro" 
                ErrorMessage="Por favor, informe o Bairro." 
                ForeColor="Red" 
                Display="Dynamic" />
            <br />

            <label>Cidade:</label><br />
            <asp:TextBox ID="txtCidade" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqCidade" runat="server" 
                ControlToValidate="txtCidade" 
                ErrorMessage="Por favor, informe o Cidade." 
                ForeColor="Red" 
                Display="Dynamic" />
            <br />

            <label>Estado:</label><br />
            <asp:DropDownList ID="ddlEstados" runat="server" CssClass="form-control"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="reqEstado" runat="server" 
                ControlToValidate="ddlEstados" 
                ErrorMessage="Por favor, informe o Estado." 
                ForeColor="Red" 
                Display="Dynamic" />
            <br />

            <label>Cep:</label><br />
            <asp:TextBox ID="txtCep" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqCep" runat="server" 
                ControlToValidate="txtCep" 
                ErrorMessage="Por favor, informe o CEP." 
                ForeColor="Red"
                Display="Dynamic" />
            <asp:RegularExpressionValidator ID="regexCep" runat="server"
                ErrorMessage="CPF inválido."
                ControlToValidate="txtCep"
                ValidationExpression="^[0-9\s]{8,8}$"
                ForeColor="Red"
                Display="Dynamic" />
            <br />

        </div>

    </div>

    <div class="row">

        <div class="col-xs-2">

            <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar Cliente" CssClass="btn btn-primary btn-block" OnClick="btnAtualizar_Click" />
            <br />
            <br />

        </div>

    </div>

    <div class="row">

        <div class="col-xs-12">

            <asp:Label ID="lblMensagem" runat="server"></asp:Label>

        </div>

    </div>

</asp:Content>
