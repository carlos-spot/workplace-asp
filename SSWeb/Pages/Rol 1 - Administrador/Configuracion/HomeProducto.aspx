<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 1 - Administrador/PrincipalAdministrador.master" AutoEventWireup="false" CodeFile="HomeProducto.aspx.vb" Inherits="Pages_Rol_1___Administrador_HomeProducto" title="Mantenimiento de productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">
    <div id="Contenedor" style="width: 982px; font-size: 16px; text-align:justify; padding-top: 10px; height: 561px; ">
         <div id="izquierdaDiv1" 
                 
             style="float:left; height: 39px; width: 411px; margin-top: 17px; margin-left: 205px;">
            <div id="DivPrincipalCabezera" 
                style="height: 29px; width: 399px; text-align: center; margin-left: 0px; margin-top: 7px;">
                <asp:Label ID="lblMantenimiento" runat="server" Enabled="False" Font-Names="Arial" Font-Size="20pt" ForeColor="#000066" 
                    Text="Mantenimiento de productos"></asp:Label>
               
            </div>
        </div>
         <div id="Div1"
             style="height: 532px; float:left; width: 640px; text-align: left; margin-left: 85px; margin-top: 0px; margin-right: 0px;">
            <%--Div con el titulo de la pagina--%>
        
            <p style="font-size:20px; text-align:center; width:620px; height: 114px; line-height: 25px; margin-bottom: 0px;" >
                El mantenimiento de productos consiste en la funcionalidades de: registrar, modificar, 
                eliminar y consultar un determinado producto. Estos productos estan ligados a las opciones
                de las pregunta. Para aclarar mejor este consepto miremos el siguiente ejemplo:
            </p>            
            <div id ="DivPregunta" style=" text-align:center; font-size:20px; text-align:left; width:618px; height: 169px; line-height: 25px; margin-top: 0px; margin-left: 0px;">
                <p style="font-size:20px; text-align:center; width:620px; height: 43px; line-height: 25px; margin-bottom: 0px;">
                    ¿Cuáles de los siguientes lenguajes de programación usted conoce?
                </p>
                <input type="checkbox" name="chkJava" id="idJava" style="margin-left: 209px" />Java<input 
                    type="checkbox" name="chkVbnet" id="idVbnet" style="margin-left: 51px" />VB.Net
                <br />
                <input type="checkbox" name="chkC" id="idC" style="margin-left: 210px" />C++
                <input type="checkbox" name="chkDelphi" id="idDelphi" 
                    style="margin-left: 58px" />Delphi<br />
           <p style="font-size:20px; text-align:center; width:620px; height: 111px; line-height: 25px; margin-bottom: 0px;">
                Tanto Java, como VB.Net, C++ y Delphi representan productos, cada uno de ellos tiene 
                su marca, fabricante y tema al que pertenece. Esto facilita al usuario a la hora de
                crear nuevas preguntas.
            </p>
          </div>
        </div>
        <div style="height: 87px; float:right; width: 170px; text-align: left; margin-top: 187px; margin-right: 72px; margin-left: 0px;">
            <div style="width: 149px; margin-top: 9px; text-align: center; margin-left: 17px;">
            <br />
                <asp:Button ID="btnConfigurar" runat="server" Height="25px" 
                    Text="Configurar productos" Width="140px" />
            </div>
        </div>
    </div>
</asp:Content>

