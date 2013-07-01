<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 2 - Profesor/PrincipalProfesor.master" AutoEventWireup="false" CodeFile="ModificarOpcion.aspx.vb" Inherits="Pages_Rol_2___Profesor_ModificarOpcion" title="Modificar opción" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
   <div style="height: 602px">
       <br />
       <h2 style="height: 32px; margin-left: 267px">Modificar opción de pregunta:
           <asp:Label ID="lblPregunta" runat="server" Text="pregunta" Font-Bold="False" 
               Font-Size="12pt"></asp:Label>
       </h2>
       <p style="width: 531px; margin-left: 224px; text-align: center;">Modificar una opción</p>

       <div style="height: 231px">
    
        <div id="DivDatos" 
               style="float:left; height: 128px; width: 316px; margin-left: 333px;">
            <asp:Label ID="lblProducto" runat="server" Text="Producto:" Font-Size="11pt"></asp:Label>
            <asp:DropDownList ID="cbxProducto" runat="server" CssClass="texto" 
            Height="20px" Width="220px">
        </asp:DropDownList>
            <br />
            <br />
        <asp:Label ID="Label2" runat="server" Text="Texto:" Font-Size="11pt"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtTextoOpcion" runat="server" Height="20px" 
            Width="220px"></asp:TextBox>
            <br />
            <br />  
            <div style="text-align: center"> 
                    <asp:Label ID="lblError" runat="server" Text="Error" ForeColor="#FF3300" 
                    Visible="False" Font-Size="11pt"></asp:Label>
             </div>      
            <br />
            <br />
   
        </div>
        <div style="height: 145px; float:right; width: 246px;">
        
        </div>
        <div style="height: 39px; float:left; width: 969px; text-align: left;">
        
        <asp:Button ID="btnIrPregunta" runat="server" Text="Guardar cambios  "
            Width="120px" Height="25px" style="margin-left: 396px" />
   
            <br />
   
        <asp:Button ID="btnAtras" runat="server" Text="Regresar" 
            Width="120px" style="margin-left: 830px; margin-top: 75px;" Height="25px" />
   
        </div>
           &nbsp;
           <br />
           <br />
   
        <br />
        <%--Div con el recuadro--%>
        </div>
   </div>
</asp:Content>

