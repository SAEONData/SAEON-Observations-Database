﻿<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Site.aspx.cs" Inherits="Admin_Site" %>

<asp:Content ID="Head" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../JS/Site.js"></script>
    <script type="text/javascript" src="../JS/generic.js"></script>
    <script type="text/javascript">
        var submitValue = function (format) {
            GridData.setValue(Ext.encode(ContentPlaceHolder1_GridFilters1.buildQuery(ContentPlaceHolder1_GridFilters1.getFilterData())));
            //VisCols.setValue(Ext.encode(ContentPlaceHolder1_SiteGrid.getRowsValues({ visibleOnly: true, excludeId: true })[0]));
            var viscolsNew = makenewJsonForExport(ContentPlaceHolder1_SiteGrid.getColumnModel().getColumnsBy(function (column, colIndex) { return !this.isHidden(colIndex); }))
            VisCols.setValue(viscolsNew);
            FormatType.setValue(format);
            SortInfo.setValue(ContentPlaceHolder1_GridFilters1.store.sortInfo.field + "|" + ContentPlaceHolder1_GridFilters1.store.sortInfo.direction);

            ContentPlaceHolder1_SiteGrid.submitData(false);
        };
    </script>
</asp:Content>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <ext:Hidden ID="GridData" runat="server" ClientIDMode="Static" />
    <ext:Hidden ID="VisCols" runat="server" ClientIDMode="Static" />
    <ext:Hidden ID="FormatType" runat="server" ClientIDMode="Static" />
    <ext:Hidden ID="SortInfo" runat="server" ClientIDMode="Static" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
        <Items>
            <ext:Panel ID="Panel1" runat="server" Title="Sites" Layout="FitLayout" Hidden="false">
                <TopBar>
                    <ext:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <ext:Button ID="Button1" runat="server" Icon="Add" Text="Add Site">
                                <ToolTips>
                                    <ext:ToolTip ID="ToolTip1" runat="server" Html="Add" />
                                </ToolTips>
                                <Listeners>
                                    <Click Fn="New" />
                                </Listeners>
                            </ext:Button>
                            <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                            <ext:Button ID="Button2" runat="server" Text="To Excel"
                                Icon="PageExcel">
                                <Listeners>
                                    <Click Handler="submitValue('exc');" />
                                </Listeners>

                            </ext:Button>
                            <ext:Button ID="Button3" runat="server" Text="To CSV"
                                Icon="PageAttach">
                                <Listeners>
                                    <Click Handler="submitValue('csv');" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    <ext:GridPanel ID="SiteGrid" runat="server" Border="false">
                        <Store>
                            <ext:Store ID="Store2" runat="server" RemoteSort="true" OnRefreshData="SiteStore_RefreshData" OnSubmitData="SiteStore_Submit">
                                <Proxy>
                                    <ext:PageProxy />
                                </Proxy>
                                <Reader>
                                    <ext:JsonReader IDProperty="Id">
                                        <Fields>
                                            <ext:RecordField Name="Id" Type="Auto" />
                                            <ext:RecordField Name="Code" Type="String" />
                                            <ext:RecordField Name="Name" Type="String" />
                                            <ext:RecordField Name="Description" Type="String" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                                <BaseParams>
                                    <ext:Parameter Name="start" Value="0" Mode="Raw" />
                                    <ext:Parameter Name="limit" Value="25" Mode="Raw" />
                                    <ext:Parameter Name="sort" Value="" />
                                    <ext:Parameter Name="dir" Value="" />
                                </BaseParams>
                                <SortInfo Field="Name" Direction="ASC" />
                                <DirectEventConfig IsUpload="true" />
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:Column Header="Code" DataIndex="Code" Width="200" />
                                <ext:Column Header="Name" DataIndex="Name" Width="200" />
                                <ext:Column Header="Description" DataIndex="Description" Width="200" />
                                <ext:CommandColumn Width="50">
                                    <Commands>
                                        <ext:GridCommand Icon="NoteEdit" CommandName="Edit" Text="" ToolTip-Text="Edit" />
                                    </Commands>
                                </ext:CommandColumn>
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
                        </SelectionModel>
                        <LoadMask ShowMask="true" />
                        <Plugins>
                            <ext:GridFilters runat="server" ID="GridFilters1">
                                <Filters>
                                    <ext:StringFilter DataIndex="ID" />
                                    <ext:StringFilter DataIndex="Code" />
                                    <ext:StringFilter DataIndex="Name" />
                                    <ext:StringFilter DataIndex="Description" />
                                </Filters>
                            </ext:GridFilters>
                        </Plugins>
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="25" EmptyMsg="No data found" />
                        </BottomBar>
                        <Listeners>
                            <Command Fn="onCommand" />
                        </Listeners>
                    </ext:GridPanel>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
    <ext:Window ID="DetailWindow" runat="server" Width="450" Height="400" Closable="true"
        Hidden="true" Collapsible="false" Title="Site Detail"
        Maximizable="false" Layout="Fit" ClientIDMode="Static">
        <Content>
            <ext:FormPanel ID="DetailsFormPanel" runat="server" Title="" MonitorPoll="500" MonitorValid="true"
                MonitorResize="true" Padding="10" Width="440" Height="370" ButtonAlign="Right"
                Layout="RowLayout" ClientIDMode="Static">
                <LoadMask ShowMask="true" />
                <Items>
                    <ext:Hidden ID="tfID" DataIndex="Id" runat="server" ClientIDMode="Static">
                    </ext:Hidden>
                    <ext:Panel ID="Panel2" runat="server" Border="false" Header="false" Layout="Form"
                        LabelAlign="Top">
                        <Defaults>
                            <ext:Parameter Name="AllowBlank" Value="false" Mode="Value" />
                            <ext:Parameter Name="blankText" Value="Code is a required" Mode="Value" />
                            <ext:Parameter Name="MsgTarget" Value="side" />
                        </Defaults>
                        <Items>
                            <ext:TextField ID="tfCode" DataIndex="Code" IsRemoteValidation="true" MaxLength="50"
                                runat="server" FieldLabel="Code" AnchorHorizontal="95%" ClientIDMode="Static">
                                <RemoteValidation OnValidation="ValidateField">
                                    <ExtraParams>
                                        <ext:Parameter Name="id" Value="1" Mode="Raw" />
                                    </ExtraParams>
                                </RemoteValidation>
                            </ext:TextField>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel3" runat="server" Border="false" Header="false" Layout="Form"
                        LabelAlign="Top">
                        <Defaults>
                            <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                            <ext:Parameter Name="blankText" Value="Name is a required" Mode="Value" />
                            <ext:Parameter Name="MsgTarget" Value="side" />
                        </Defaults>
                        <Items>
                            <ext:TextField ID="tfName" DataIndex="Name" MaxLength="150" IsRemoteValidation="true"
                                runat="server" FieldLabel="Name" AnchorHorizontal="95%" ClientIDMode="Static">
                                <RemoteValidation OnValidation="ValidateField" />
                            </ext:TextField>
                        </Items>
                    </ext:Panel>
                    <ext:Panel ID="Panel4" runat="server" Border="false" Header="false" Layout="Form"
                        LabelAlign="Top">
                        <Defaults>
                            <ext:Parameter Name="AllowBlank" Value="false" Mode="Raw" />
                            <ext:Parameter Name="blankText" Value="Description is required" Mode="Value" />
                            <ext:Parameter Name="MsgTarget" Value="side" />
                        </Defaults>
                        <Items>
                            <ext:TextArea ID="tfDescription" DataIndex="Description" MaxLength="150" runat="server"
                                FieldLabel="Description" AnchorHorizontal="95%">
                            </ext:TextArea>
                        </Items>
                    </ext:Panel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnSave" runat="server" Text="Save" FormBind="true">
                        <DirectEvents>
                            <Click OnEvent="Save" Method="POST">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
                <BottomBar>
                    <ext:StatusBar ID="StatusBar1" runat="server" Height="25" />
                </BottomBar>
                <Listeners>
                    <ClientValidation Handler="this.getBottomToolbar().setStatus({text : valid ? 'Form is valid' : 'Form is invalid', iconCls: valid ? 'icon-accept1' : 'icon-exclamation'});" />
                </Listeners>
            </ext:FormPanel>
        </Content>
    </ext:Window>
</asp:Content>

