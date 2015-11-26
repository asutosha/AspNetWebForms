<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PainelLogin.ascx.cs" Inherits="ClientControl.Web.Components.PainelLogin" %>

<div id="area" runat="server" class="panel panel-primary">

    <div class="panel-body">

        <div class="row">

            <div class="col-xs-10" style="margin-right: -30px;">

                <span>Bem vindo, </span>
                <strong>
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                </strong>

            </div>

            <div class="col-xs-2">

                <asp:Button ID="btnSair" runat="server" Text="Sair" CssClass="btn btn-danger btn-sm" OnClick="btnSair_Click" CausesValidation="false" />

            </div>

        </div>

    </div>

</div>