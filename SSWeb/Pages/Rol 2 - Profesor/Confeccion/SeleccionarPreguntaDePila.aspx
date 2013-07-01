<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="SeleccionarPreguntaDePila.aspx.vb" Inherits="Pages_Rol_2___Profesor_SeleccionarPreguntaDePila" title="Seleccionar pregunta de la pila" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <div style="height: 599px">
        <br />
         <%--Título y descripción de la funcionalidad--%>
         <div>
            <h2 style="text-align: center">Gestión de encuesta: 
                <asp:Label ID="lblTitulo" runat="server" Text="Encuesta" Font-Bold="False" 
                    Font-Size="12pt"></asp:Label>
             </h2>
            <p>Agregar pregunta registrada previamente al cuestionario actual</p>
        </div>
        <%--Capa contenedora--%>
        <div>
            <%--Región de búqueda--%>
            <div style="text-align: center">
                <asp:Label ID="Label1" runat="server" Text="Buscar pregunta:" Font-Size="11pt"></asp:Label>
                <asp:TextBox class = "texto" ID="txtCriterio" runat="server" 
                    style="margin-left: 10px" Width="220px" Height="20px"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" style="margin-left: 10px" 
                    Text="Buscar" Height="25px" Width="120px" />
            </div>
              <br />
             &nbsp;<div style="text-align: center; width: 529px; margin-left: 228px;">
                <cc1:Grid ID="gvPreguntas" runat="server" Height="200px" ShowFooter="False" 
                        Width="200px" AllowAddingRecords="False" 
                    AllowMultiRecordSelection="False" AllowSorting="False" 
                    NumberOfPagesShownInFooter="0">
                </cc1:Grid>
            </div>
            <br />
            <%--Capa del mensaje de error--%>
            <div style="text-align: center">
                <asp:Label ID="lblError" runat="server" Text="Error" ForeColor="#FF3300" 
                Visible="False" Font-Size="11pt" style="text-align: center"></asp:Label>
            </div>
            <br/>
            <%--Region de agregar--%>
            <div style="text-align: center">
            <asp:Button ID="btnAgregar" runat="server" CssClass="espaciador" 
                Text="Agregar" Width="120px" Height="25px" />
                   <asp:Button ID="btnIraCuestionario" runat="server" CssClass="texto" 
                Text="Regresar" style="margin-left: 10px" Width="120px" Height="25px" />           
            </div>
             <br />
             <br />
            </div>
    </div>
</asp:Content>

