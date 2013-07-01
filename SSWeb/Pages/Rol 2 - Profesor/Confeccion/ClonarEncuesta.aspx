<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="ClonarEncuesta.aspx.vb" Inherits="Pages_Rol_2___Profesor_ClonarEncuesta" title="Clonar preguntas de encuesta" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <br />
<div>
    <%--Título y descripción de la funcionalidad--%>
    <h2 style="text-align: center">Gestión de encuesta:
        <asp:Label ID="lblTitulo" runat="server" Text="Encuesta" Font-Bold="False" 
            Font-Size="12pt"></asp:Label>
    </h2>
    <p style="margin-left: 154px; width: 689px;">Selección de una encuesta previamente registrada para clonar sus preguntas 
        a la encusta actual</p>
    <%--Capa contenedora--%>
    <div style="height: 530px">
        <%--Búsqueda de encuestas--%>
        <div style="text-align: center">
            <asp:Label ID="lblCriterio" runat="server" Text="Buscar encuesta por nombre:" 
                    Font-Size="11pt"></asp:Label>

            <asp:TextBox ID="txtCriterio" runat="server" Height="20px" Width="220px" 
                style="margin-left: 10px"></asp:TextBox>

            <asp:Button ID="btnBuscar" runat="server"  Text="Buscar " Height="25px" 
                style="margin-left: 10px" Width="120px" />
        </div>
      
            <br/>
            <%--Capa que contiene el grid que muestra los resultados--%>
            <div style="text-align: center; width: 828px; margin-left: 79px;">
                <cc1:Grid ID="gvEncuestas" runat="server" AllowAddingRecords="False" 
                 Height="200px" ShowFooter="False" Width="750px" 
                    AllowMultiRecordSelection="False" AllowPageSizeSelection="False" 
                    AllowPaging="False" AllowSorting="False" PageSize="0">
                    <LocalizationSettings NoRecordsText="No se encontraron encuestas para clonar" />
                 </cc1:Grid>
            </div>
            <br />
            <%--Label de error--%>
            <div style="text-align: center">
                <asp:Label ID="lblError" runat="server" Text="Error" ForeColor="#FF3300" 
                    Visible="False" Font-Size="11pt"></asp:Label>
            </div>
            <br/>
            <%--Capa que contiene los botones de clonar y regresar a la página anterior--%>
            <div style="text-align: center">
                 <asp:Button ID="btnClonar" runat="server" CssClass="espaciador" 
                     Text="Clonar cuestionario" Height="25px" Width="140px" />
                 <asp:Button ID="btnAtras" runat="server" Height="25px" 
                     style="margin-left: 10px" Text="Regresar" Width="120px" />
            </div>
           <br />
           <br />
    </div>
</div>
</asp:Content>

