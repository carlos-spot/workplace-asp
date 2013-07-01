<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="CriterioEvaluacionPreguntaAbiertas.aspx.vb" Inherits="Pages_Rol_2___Profesor_CriterioEvaluacionPreguntaAbiertas" title="Criterio de evaluación de preguntas abiertas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
   <div style="height: 605px">
        <div>
       <%--Titulo y descripción--%>
       <br />
         <%--Div con el titulo de la pagina--%>
        <div id="DivTitulo" 
            
        
                
                style="height: 40px; text-align: left; margin-left: 355px; margin-top: 0px; margin-right: 0px; width: 458px;">
            <div style="width: 427px; height: 28px; margin-top: 9px; margin-left: 0px;">
                <asp:Label ID="lblHeader" runat="server" Enabled="False" Font-Names="Arial" Font-Size="20pt" ForeColor="#000066" 
                    Text="Gestión de encuesta"></asp:Label>
            </div>
        </div>
       <p>Establecer criterio de evaluaci&oacute;n de preguntas abiertas</p>
       </div>
       <%--Capa de ingreso de datos--%>
       <div style="text-align: center">
            <asp:Label ID="Label2" runat="server" Text="Texto de criterio:" 
                Font-Size="11pt"></asp:Label>
            <asp:TextBox ID="txtTextoOpcion" runat="server" Height="20px" 
                Width="220px" style="margin-left: 10px"></asp:TextBox>
        </div>
            <br />
        <%--label de error--%>
        <div style="text-align: center">
            <asp:Label ID="lblError" runat="server" Text="Error" ForeColor="#FF3300" 
                Visible="False" Font-Size="11pt"></asp:Label>
            <br />
            <br />
       </div>
       <%--botones de guardar y regresar a la pantalla anterior--%>
       <div style="text-align: center">
            <asp:Button ID="btnIrPregunta" runat="server" Text="Guardar" Width="120px" 
                Height="25px" style="margin-left: 23px" />
            <br />
            <asp:Button ID="btnAtras" runat="server" Height="25px" 
                style="margin-left: 828px; margin-top: 74px;" Text="Regresar" 
                Width="120px" />
       </div>
   </div>
</asp:Content>

