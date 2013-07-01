<%@ Page Language="VB" AutoEventWireup="false" CodeFile="TestGridView.aspx.vb" Inherits="TestGridView" %>
<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script> 
    <script type="text/javascript">
        function agregarDato()
        {
        	//Get the Grid object
            var grid = eo_GetObject("GridOrigen");
        	
            //Item que se selecciona
            var item = grid.getSelectedItem();
        	grid.deleteItem(item.getIndex());
        	
        	//Get the Grid object
            var gridDestino = eo_GetObject("GridDestino");
            
            //Add a new item
            var itemDestino = gridDestino.addItem();
            itemDestino.getCell(0).setValue(item.getCell(0).getValue());
            itemDestino.getCell(1).setValue(item.getCell(1).getValue());
        }
        
        function removerDato()
        {
        	//Get the Grid object
            var grid = eo_GetObject("GridDestino");
        	
            //Item que se selecciona
            var item = grid.getSelectedItem();
        	grid.deleteItem(item.getIndex());
        	
        	//Get the Grid object
            var gridDestino = eo_GetObject("GridOrigen");
            
            //Add a new item
            var itemDestino = gridDestino.addItem();
            itemDestino.getCell(0).setValue(item.getCell(0).getValue());
            itemDestino.getCell(1).setValue(item.getCell(1).getValue());
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 388px; width: 1401px;">
        <asp:GridView ID="dgCliente" runat="server">
            <Columns>
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" ButtonType="Button" />
            </Columns>
            <SelectedRowStyle BackColor="#D5F7FF" />
        </asp:GridView>
        
        <%--Grid 1--%>
        <div id="divGridOrigen" style="position:absolute; top: 143px; left: 776px; height: 122px; width: 447px;">
            <eo:Grid runat="server" id="GridOrigen" BorderColor="#828790" BorderWidth="1px" GridLines="Both"
		FixedColumnCount="1" ColumnHeaderDescImage="00050205" GridLineColor="240, 240, 240" Width="186px"
		IsCallbackByMe="False" ItemHeight="19" ColumnHeaderAscImage="00050204" ColumnHeaderHeight="24"
		Height="116px" Font-Size="8.75pt" Font-Names="Tahoma" 
            ColumnHeaderDividerImage="00050203">
		<ItemStyles>
			<eo:GridItemStyleSet>
				<ItemHoverStyle CssText="background-image: url(00050206); background-repeat: repeat-x"></ItemHoverStyle>
				<SelectedStyle CssText="background-image: url(00050207); background-repeat: repeat-x"></SelectedStyle>
				<CellStyle CssText="padding-left:8px;padding-top:2px;"></CellStyle>
				<ItemStyle CssText="background-color: white"></ItemStyle>
			</eo:GridItemStyleSet>
		</ItemStyles>
		<ColumnHeaderHoverStyle CssText="background-image:url('00050202');padding-left:8px;padding-top:4px;"></ColumnHeaderHoverStyle>
		<ColumnTemplates>
			<eo:TextBoxColumn>
				<TextBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 8.75pt; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; FONT-FAMILY: Tahoma"></TextBoxStyle>
			</eo:TextBoxColumn>
			<eo:DateTimeColumn>
				<DatePicker DayHeaderFormat="FirstLetter" DayCellHeight="16" DisabledDates="" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
					OtherMonthDayVisible="True" DayCellWidth="19" TitleRightArrowImageUrl="DefaultSubMenuIcon"
					ControlSkinID="None" SelectedDates="">
					<DayHoverStyle CssText="font-family: tahoma; font-size: 12px; border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid"></DayHoverStyle>
					<TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;"></TitleStyle>
					<DayHeaderStyle CssText="font-family: tahoma; font-size: 12px; border-bottom: #aca899 1px solid"></DayHeaderStyle>
					<DayStyle CssText="font-family: tahoma; font-size: 12px; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DayStyle>
					<SelectedDayStyle CssText="font-family: tahoma; font-size: 12px; background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></SelectedDayStyle>
					<TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
					<TodayStyle CssText="font-family: tahoma; font-size: 12px; border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid"></TodayStyle>
					<PickerStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;font-family:Courier New;font-size:8pt;margin-bottom:0px;margin-left:0px;margin-right:0px;margin-top:0px;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></PickerStyle>
					<OtherMonthDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></OtherMonthDayStyle>
					<CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma"></CalendarStyle>
					<DisabledDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DisabledDayStyle>
					<MonthStyle CssText="font-family: tahoma; font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px"></MonthStyle>
				</DatePicker>
			</eo:DateTimeColumn>
			<eo:MaskedEditColumn>
				<MaskedEdit ControlSkinID="None" TextBoxStyle-CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; font-family:Courier New;font-size:8pt;"></MaskedEdit>
			</eo:MaskedEditColumn>
		</ColumnTemplates>
		<Columns>
			<%--<eo:RowNumberColumn Width="40"></eo:RowNumberColumn>	--%>	        
            <eo:StaticColumn Width="40" HeaderText="Id" DataField="Id"></eo:StaticColumn>
            <%--<eo:StaticColumn HeaderText="Cedula" DataField="Cedula"></eo:StaticColumn>--%>
            <eo:StaticColumn Width="120" HeaderText="Nombre" DataField="Nombre"></eo:StaticColumn>
            <%--<eo:StaticColumn Width="100" HeaderText="PrimerApellido" DataField="PrimerApellido"></eo:StaticColumn>
            <eo:StaticColumn Width="100" HeaderText="SegundoApellido" DataField="SegundoApellido"></eo:StaticColumn>
            <eo:StaticColumn Width="100" HeaderText="NombreUsuario" DataField="NombreUsuario"></eo:StaticColumn>
            <eo:StaticColumn Width="100" HeaderText="Rol" DataField="Rol"></eo:StaticColumn>--%>
		</Columns>
		<ColumnHeaderStyle CssText="background-image:url('00050201');padding-left:8px;padding-top:4px;"></ColumnHeaderStyle>
	</eo:Grid>
	        <input onclick="agregarDato()" type="button" value="Agregar Usuario" /> 
        </div>
        
        
	    <%--<eo:RowNumberColumn Width="40"></eo:RowNumberColumn>	--%>
	     <div id="divGridDestino" 
            
            style="position:absolute; top: 284px; left: 775px; height: 122px; width: 443px;">
	        <eo:Grid runat="server" id="GridDestino" BorderColor="#828790" BorderWidth="1px" GridLines="Both"
		    FixedColumnCount="1" ColumnHeaderDescImage="00050205" GridLineColor="240, 240, 240" Width="184px"
		    IsCallbackByMe="False" ItemHeight="19" ColumnHeaderAscImage="00050204" ColumnHeaderHeight="24"
		    Height="112px" Font-Size="8.75pt" Font-Names="Tahoma" 
                ColumnHeaderDividerImage="00050203">
		    <ItemStyles>
			    <eo:GridItemStyleSet>
				    <ItemHoverStyle CssText="background-image: url(00050206); background-repeat: repeat-x"></ItemHoverStyle>
				    <SelectedStyle CssText="background-image: url(00050207); background-repeat: repeat-x"></SelectedStyle>
				    <CellStyle CssText="padding-left:8px;padding-top:2px;"></CellStyle>
				    <ItemStyle CssText="background-color: white"></ItemStyle>
			    </eo:GridItemStyleSet>
		    </ItemStyles>
		    <ColumnHeaderHoverStyle CssText="background-image:url('00050202');padding-left:8px;padding-top:4px;"></ColumnHeaderHoverStyle>
		    <ColumnTemplates>
			    <eo:TextBoxColumn>
				    <TextBoxStyle CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; FONT-SIZE: 8.75pt; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; FONT-FAMILY: Tahoma"></TextBoxStyle>
			    </eo:TextBoxColumn>
			    <eo:DateTimeColumn>
				    <DatePicker DayHeaderFormat="FirstLetter" DayCellHeight="16" DisabledDates="" TitleLeftArrowImageUrl="DefaultSubMenuIconRTL"
					    OtherMonthDayVisible="True" DayCellWidth="19" TitleRightArrowImageUrl="DefaultSubMenuIcon"
					    ControlSkinID="None" SelectedDates="">
					    <TodayStyle CssText="font-family: tahoma; font-size: 12px; border-right: #bb5503 1px solid; border-top: #bb5503 1px solid; border-left: #bb5503 1px solid; border-bottom: #bb5503 1px solid"></TodayStyle>
					    <SelectedDayStyle CssText="font-family: tahoma; font-size: 12px; background-color: #fbe694; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></SelectedDayStyle>
					    <DisabledDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DisabledDayStyle>
					    <PickerStyle CssText="border-bottom-color:#7f9db9;border-bottom-style:solid;border-bottom-width:1px;border-left-color:#7f9db9;border-left-style:solid;border-left-width:1px;border-right-color:#7f9db9;border-right-style:solid;border-right-width:1px;border-top-color:#7f9db9;border-top-style:solid;border-top-width:1px;font-family:Courier New;font-size:8pt;margin-bottom:0px;margin-left:0px;margin-right:0px;margin-top:0px;padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;"></PickerStyle>
					    <CalendarStyle CssText="background-color: white; border-right: #7f9db9 1px solid; padding-right: 4px; border-top: #7f9db9 1px solid; padding-left: 4px; font-size: 9px; padding-bottom: 4px; border-left: #7f9db9 1px solid; padding-top: 4px; border-bottom: #7f9db9 1px solid; font-family: tahoma"></CalendarStyle>
					    <TitleArrowStyle CssText="cursor:hand"></TitleArrowStyle>
					    <DayHoverStyle CssText="font-family: tahoma; font-size: 12px; border-right: #fbe694 1px solid; border-top: #fbe694 1px solid; border-left: #fbe694 1px solid; border-bottom: #fbe694 1px solid"></DayHoverStyle>
					    <MonthStyle CssText="font-family: tahoma; font-size: 12px; margin-left: 14px; cursor: hand; margin-right: 14px"></MonthStyle>
					    <TitleStyle CssText="background-color:#9ebef5;font-family:Tahoma;font-size:12px;padding-bottom:2px;padding-left:6px;padding-right:6px;padding-top:2px;"></TitleStyle>
					    <OtherMonthDayStyle CssText="font-family: tahoma; font-size: 12px; color: gray; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></OtherMonthDayStyle>
					    <DayHeaderStyle CssText="font-family: tahoma; font-size: 12px; border-bottom: #aca899 1px solid"></DayHeaderStyle>
					    <DayStyle CssText="font-family: tahoma; font-size: 12px; border-right: white 1px solid; border-top: white 1px solid; border-left: white 1px solid; border-bottom: white 1px solid"></DayStyle>
				    </DatePicker>
			    </eo:DateTimeColumn>
			    <eo:MaskedEditColumn>
				    <MaskedEdit ControlSkinID="None" TextBoxStyle-CssText="BORDER-RIGHT: #7f9db9 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #7f9db9 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 1px; MARGIN: 0px; BORDER-LEFT: #7f9db9 1px solid; PADDING-TOP: 2px; BORDER-BOTTOM: #7f9db9 1px solid; font-family:Courier New;font-size:8pt;"></MaskedEdit>
			    </eo:MaskedEditColumn>
		    </ColumnTemplates>
		    <Columns>
		        <%--<eo:RowNumberColumn Width="40"></eo:RowNumberColumn>	--%>	        
                <eo:StaticColumn Width="40" HeaderText="Id" DataField="Id"></eo:StaticColumn>
                <%--<eo:StaticColumn HeaderText="Cedula" DataField="Cedula"></eo:StaticColumn>--%>
                <eo:StaticColumn Width="120" HeaderText="Nombre" DataField="Nombre"></eo:StaticColumn>
                <%--<eo:StaticColumn Width="100" HeaderText="PrimerApellido" DataField="PrimerApellido"></eo:StaticColumn>
                <eo:StaticColumn Width="100" HeaderText="SegundoApellido" DataField="SegundoApellido"></eo:StaticColumn>
                <eo:StaticColumn Width="100" HeaderText="NombreUsuario" DataField="NombreUsuario"></eo:StaticColumn>
                <eo:StaticColumn Width="100" HeaderText="Rol" DataField="Rol"></eo:StaticColumn>--%>
		    </Columns>
		    <ColumnHeaderStyle CssText="background-image:url('00050201');padding-left:8px;padding-top:4px;"></ColumnHeaderStyle>
	    </eo:Grid>
	         <input onclick="removerDato()" type="button" value="Remover Usuario" /> 
	    </div>
    </div>
    </form>
</body>
</html>
