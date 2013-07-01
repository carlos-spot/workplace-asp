<%@ Page Language="VB" MasterPageFile="~/Pages/Rol 3 - Asistente/PrincipalAsistente.master" AutoEventWireup="true" CodeFile="ClonarContactosEncuesta.aspx.vb" Inherits="Pages_Rol_3___Asistente_ClonarContactosEncuesta" title="Clonar contactos" %>
<%@ Register assembly="obout_Grid_NET" namespace="Obout.Grid" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" Runat="Server">

 <div id="ContenedorPrincipal" style ="width:1000px; height: 580px;">
                    <div id="titulo" style=" width:1000px; height:35px; padding-top:10">
                   <div id ="title" style=" width:200px; margin-left:400px; margin-top:20px">
                        <h2>Clonar contactos</h2>
                   </div>
                    
                    </div>
                
                    <div id="encuesta" style="padding-top:1px; clear:both; height: 122px; width: 1024px;">
                        
                        <div id="divEcuesta" 
                            style="width: 407px; float:left; margin-left: 280px;">
                    <cc1:Grid ID="gvEncuestas" runat="server" PageSize="0" 
                    AllowAddingRecords="False" AllowMultiRecordSelection="False" 
                                    AllowPageSizeSelection="False" AllowSorting="False" Height="150px" 
                                ShowFooter="False">
                        <ScrollingSettings ScrollHeight="150px" />
                </cc1:Grid>
                </div>
                <div id="btnCargar" 
                            style ="  text-align:left; width: 260px; float: left; height: 99px; text-align:left ">
                     <asp:Button ID="btnCargarContactos" runat="server" 
                         Text="Cargar contactos" Height="25px" Width="146px" 
                         style="margin-top: 33px" />
                </div>
                </div>
                <!----fin div grid-->
                <div id="textoDescripcion" style ="width:990px; height: 79px; clear:both">
                                <p style="text-align: center; margin-left:31px; width: 883px; height: 82px;">Seleccione la encuesta de la que desea obtener los contactos y presione el bot&oacute;n cargar contactos.<br />
                        Seleccionar los contactos que participaron en una encuesta previa para invitarlos a que participen en una nueva encuesta.</p>
                </div><!---fin texto descripcion---->
                    <div id="contenedorGrids" style=" width:823px; height:256px; margin-left:140px"> <!--contenedor texto-titulos grid--->
                        <div id="ContenedorIsq"  style=" width:301px; float:left;height:226px; " >
                            <div id="titloIzquierdoGrid" 
                                style=" width:296px; height:30px; margin-left: 4px;">
                                <h2 style="padding-left:15px;">Lista de contactos disponibles</h2>
                            </div>
                            <div id="IzquierdoGrid" style=" width:300px; height:192px; " ><!---gridIzquierdo-->
                                <cc1:Grid ID="gvContactoEncuesta" runat="server" AllowAddingRecords="False" 
                                    AllowPageSizeSelection="False" AllowSorting="False" PageSize="0" 
                                    AllowColumnResizing="False" AllowPaging="False" Height="230px" 
                                    ShowFooter="False" Width="252px">
                                    <PagingSettings ShowRecordsCount="False" />
                                    <ScrollingSettings ScrollHeight="230px" />
                                </cc1:Grid>
                            
                            </div>
                        </div><!-Contenedor botones medio-->
                        <div id="contenedorMedio"  
                            
                            style=" width:88px; float:left;height:126px; padding-top:100px; text-align:center">
                            <asp:Button ID="btnInvitarContacto" runat="server" Text="Agregar" 
                Height="25px" style =" vertical-align : middle" Width="80px"  />  
               
                            <br />
                            <asp:Label ID="lblException" runat="server" Text="Exception"></asp:Label>
                        </div>
                        <div id="ContenedorDerecho"  style=" width:432px; float:left;height:223px;"><!---gridDerecho-->
                             <div id="tituloDerechoGrid" style=" width:293px; height:30px;">
                                 <h2 style="padding-left:15px;">Lista de contactos invitados</h2>
                            </div>
                            <div id="DerechoGrid" style=" width:300px; height:195px; float:left;">
                                <cc1:Grid ID="gContactosInvitados" runat="server" AllowAddingRecords="False" 
                                 AllowPaging="False" AllowSorting="False" Width="252px" PageSize="0" 
                                    Height="230px" ShowFooter="False">
                                    <ScrollingSettings ScrollHeight="230px" />
                                 </cc1:Grid>
                         
                            </div>
                            <div id="botonRemover"  
                            
                            
                                
                                
                                
                                
                                style=" width:116px; float:left;height:130px; padding-top:60px; margin-left: 0px; text-align:center">
               
                  <asp:Button ID="btnBorrar" runat="server" Height="25px" Text="Remover" 
                      Width="100px" />
                        </div>
                        
                    </div>
                        </div>
                         
                <!--fin texto-titulos grid--->
                   
                                <br />
                                
                       <div id="boton" style="text-align: right; width: 926px"> 
                           <asp:Button ID="btnAtras" runat="server" Text="Regresar" Width="120px" 
                            Height="25px" />  </div>
                            
              </div>
        
        <!--- contenedor titulos y bontones-->
         

</asp:Content>

