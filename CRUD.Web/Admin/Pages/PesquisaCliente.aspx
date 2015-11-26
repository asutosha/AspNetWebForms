<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Layout.Master" AutoEventWireup="true" CodeBehind="PesquisaCliente.aspx.cs" Inherits="CRUD.Web.Admin.Pages.PesquisaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudoPrincipal" runat="server">

    <div>

        <h3>Pesquisa de Cliente</h3>

        <a href="../Default.aspx">Voltar</a>

        <hr />

        <div class="row">

            <div class="col-xs-3">

                <label>Bairro:</label><br />

                <asp:TextBox ID="txtBairro" runat="server" placeholder="Digite aqui" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="col-xs-3">

                <label>Cidade:</label>

                <asp:TextBox ID="txtCidade" runat="server" placeholder="Digite aqui" CssClass="form-control"></asp:TextBox>

            </div>

            <div class="col-xs-3">

                <label>Estado:</label><br />

                <asp:DropDownList ID="ddlEstados" runat="server" CssClass="form-control"></asp:DropDownList>
                <br />

            </div>

        </div>

        <div class="row">

            <div class="col-xs-2">

                <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar Cliente" CssClass="btn btn-primary btn-block" OnClick="btnFiltrar_Click" />
                <br />

            </div>

            <div class="col-xs-10">

                <asp:Label ID="lblMensagem" runat="server" ForeColor="Red"></asp:Label>

            </div>

        </div>

        <br />
        <br />

        <asp:GridView ID="gridClientes" runat="server" CssClass="table table-hover" GridLines="None" AutoGenerateColumns="false">

            <Columns>
                <asp:TemplateField HeaderText="Código do Cliente" Visible="false">
                    <ItemTemplate><%# Eval("IdCliente") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Nome">
                    <ItemTemplate><%# Eval("Nome") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="RG">
                    <ItemTemplate><%# Eval("Rg") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="CPF">
                    <ItemTemplate><%# Eval("Cpf") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Data de Cadastro">
                    <ItemTemplate><%# Eval("DataCadastro","{0:dd/MM/yyyy}") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Endereço">
                    <ItemTemplate><%# Eval("Endereco.Descricao") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Bairro">
                    <ItemTemplate><%# Eval("Endereco.Bairro") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Cidade">
                    <ItemTemplate><%# Eval("Endereco.Cidade") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate><%# Eval("Endereco.Estado") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Cep">
                    <ItemTemplate><%# Eval("Endereco.Cep") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <Columns>
                <asp:TemplateField HeaderText="Operações">
                    <ItemTemplate>
                        <a href='DetalheCliente.aspx?cod=<%# Eval("IdCliente") %>' class="btn btn-primary btn-sm" title="Detalhes do Cliente">
                            <span class="glyphicon glyphicon-user"></span>
                        </a>
                        <asp:LinkButton ID="btnExcluir" runat="server" OnClick="btnExcluir_Click" CssClass="btn btn-danger btn-sm" CommandArgument='<%# Eval("IdCliente") %>' title="Excluir Cliente">
                            <span class="glyphicon glyphicon-trash"></span>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

            <EmptyDataTemplate>
                Nenhum cliente encontrado.
            </EmptyDataTemplate>

        </asp:GridView>

    </div>

</asp:Content>
