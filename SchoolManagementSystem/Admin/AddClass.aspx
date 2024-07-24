<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="AddClass.aspx.cs" Inherits="SchoolManagementSystem.Admin.AddClass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container-custom {
            background-image: url('C:\Users\furka\source\repos\SchoolManagementSystem\SchoolManagementSystem\Image\bc.jpg');
            width: 100%;
            height: 720px;
            background-repeat: no-repeat;
            background-size: cover;
            background-attachment: fixed;
            padding: 20px;
        }
        .form-container {
            background-color: rgba(255, 255, 255, 0.8);
            padding: 20px;
            border-radius: 10px;
        }
        .grid-container {
            margin-top: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-custom">
        <div class="container p-md-4 p-sm-4 form-container">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h3 class="text-center">New Class </h3>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txtClass">Class Name</label>
                    <asp:TextBox ID="txtClass" runat="server" CssClass="form-control" placeholder="Enter Class Name" required OnTextChanged="txtClass_TextChanged"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-3">
                    <asp:Button ID="btnEkle" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Ekle Class" OnClick="btnEkle_Click" />
                </div>
            </div>
            <div class="row grid-container">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" DataKeyNames="ClassId" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView_RowEditing" OnRowUpdating="GridView1_RowUpdating" EmptyDataText="No Record to Display!" AllowPaging="true" PageSize="4">
                        <Columns>
                            <asp:BoundField DataField="Sr.No" HeaderText="Sr.No" ReadOnly="True">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Class">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtClassEdit" runat="server" Text='<%# Eval("ClassName") %>' CssClass="form-control "></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblClassName" runat="server" Text='<%#Eval("ClassName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:CommandField CausesValidation="false" HeaderText="Operation" ShowEditButton ="true" />
                        </Columns>
                        <HeaderStyle BackColor="#5558C9" ForeColor="White"  />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


<%--<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="AddClass.aspx.cs" Inherits="SchoolManagementSystem.Admin.AddClass" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image:url('C:\Users\furka\source\repos\SchoolManagementSystem\SchoolManagementSystem\Image\bc.jpg');width:100%; height:720px; background-repeat: no-repeat; background-size:cover; background-attachment:fixed">
        <div class="container p-md-4 p-sm-4 ">
            <div>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </div>
            <h3 class="text-center">New Class </h3>
            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5 ">
                <div class="col-md-6">
                    <label for="txtClass">Class Name</label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter Class Name" required OnTextChanged="txtClass_TextChanged"></asp:TextBox>

                </div>
            </div>
            <div class="row mb-3 mr-lg-5 ml-lg-5 ">

                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-block " BackColor="#5558C9" Text="Ekle Class" OnClick="btnEkle_Click" />
                </div>
            </div>
            <div class="row mb-3 mr-lg-5 ml-lg-5  ">
    <div class="col-md-6">
        <selection-overlay style="color: rgb(33, 37, 41); font-family: Montserrat; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: 1px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(231, 241, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
           <blocked-overlay>
                <div class="blockedOverlayWrapper" style="position: absolute; top: 0px; left: 0px; width: 1144px; height: 770px; pointer-events: none;">
                    <blocked-overlay-rect height="50" width="1144" top="0" left="0">
                        <br class="Apple-interchange-newline">
                        <div class="blockedOverlayRect" style="position: absolute; cursor: not-allowed; background-color: rgba(0, 0, 0, 0.3); pointer-events: auto; top: 0px; left: 0px; width: 1144px; height: 50px;"></div>
                    </blocked-overlay-rect>
                    <blocked-overlay-rect height="720" width="250" top="50" left="0">
                        <div class="blockedOverlayRect" style="position: absolute; cursor: not-allowed; background-color: rgba(0, 0, 0, 0.3); pointer-events: auto; top: 50px; left: 0px; width: 250px; height: 720px;"></div>
                    </blocked-overlay-rect>
                </div>
            </blocked-overlay>
            <selector-parent-decorator></selector-parent-decorator>
            <selector-insertion-decorator></selector-insertion-decorator>
            <selector-decorator draggable="true" taglocation="Top">
                <div id="elementOutline" style="position: fixed; border-style: solid; border-width: 1px; border-color: var(--wlp-selection-color); outline-style: none; height: 58.8px; width: 347px; top: 227.2px; left: 335px;">
                    <div class="selectionTag" tabindex="0" role="alert" aria-label="Selected Element " style="background-color: var(--wlp-selection-color); display: flex; position: absolute; font-weight: bold; white-space: nowrap; align-items: center; padding: 3px 10px; border-radius: 3px; box-sizing: border-box; box-shadow: var(--wlp-box-shadow); color: var(--wlp-tag-text-color); font-family: var(--body-font); font-size: var(--type-ramp-base-font-size); cursor: default; pointer-events: all; top: calc(-1 * var(--wlp-status-bar-height)); left: 0px;">asp:gridview#GridView1</div>
                </div>
            </selector-decorator>
            <secondary-selections style="pointer-events: none;"></secondary-selections>
            <drag-and-drop-insertion-point mousex="-1" mousey="-1"></drag-and-drop-insertion-point>
        </selection-overlay>
        <span style="color: rgb(33, 37, 41); font-family: Montserrat; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: 1px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(231, 241, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;"></span>
        <blocked-resources-toast class="blocked-resources-toast" rooturl="http://localhost:62964/1e41fae0ac324b00844103c0536e2f2c/" style="font-family: Montserrat; font-size: 14px; line-height: var(--type-ramp-base-line-height); z-index: var(--wlp-alert-zIndex); color: rgb(33, 37, 41); position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: 1px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(231, 241, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;"></blocked-resources-toast>
        <span style="color: rgb(33, 37, 41); font-family: Montserrat; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: 1px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; background-color: rgb(231, 241, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;"></span>
        <wlp-status-bar style="display: grid; grid-template-columns: minmax(0px, 1fr) max-content; position: fixed; box-shadow: var(--wlp-box-shadow); height: var(--wlp-status-bar-height); width: 1144px; bottom: 0px; left: 0px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-variant-numeric: ; font-variant-east-asian: ; font-variant-alternates: ; font-variant-position: ; font-weight: 400; font-stretch: ; font-size: 14px; line-height: ; font-family: Montserrat; font-optical-sizing: ; font-kerning: ; font-feature-settings: ; font-variation-settings: ; background-color: rgb(231, 241, 255); color: rgb(33, 37, 41); letter-spacing: 1px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; white-space: normal; text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial;">
            <wlp-tag-navigator overflow-direction="both" style="max-height: var(--wlp-status-bar-height); display: grid; grid-template-columns: max-content minmax(0px, max-content) max-content;">
                <div id="leftScroller" aria-label="Left Scroller" role="button" class="tagNavBar_scroller" style="user-select: none; display: inline-block; padding: var(--wlp-status-bar-padding); font-family: var(--body-font); font-size: var(--type-ramp-base-font-size); margin-top: 2px; margin-right: 2px; height: 14px; color: inherit; cursor: pointer; font-weight: 500;">&lt;</div>
                <div class="tagNavBar_container" style="max-height: var(--wlp-status-bar-height); white-space: nowrap; overflow-x: hidden;">
                    <div class="tagNavBar_contents" style="display: inline-block;">
                        <div class="tagNavBar_tagItem" tabindex="0" role="button" aria-label="Root" data-selected="false" data-outlined="false" data-inactive="" title="Root" style="cursor: pointer; user-select: none; display: inline-block; padding: var(--wlp-status-bar-padding); font-family: var(--body-font); font-size: var(--type-ramp-base-font-size); margin-top: 2px; margin-right: 2px; height: 14px;">Root</div>
                    </div>
                </div>
            </wlp-tag-navigator>
        </wlp-status-bar>
        <br class="Apple-interchange-newline">
        <asp:GridView ID="GridView2" runat="server" CssClass="table table-hover table-bordered" DataKeyNames="ClassId" AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView_RowEditing" OnRowUpdating="GridView1_RowUpdating" EmptyDataText="No Record to Display!" >
            
            <Columns>
                <asp:BoundField DataField="Sr.No" HeaderText="Sr.No" ReadOnly="True">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderText="Class">
                    <EditItemTemplate>
                        <asp:TextBox ID="txtClassEdit" runat="server" Text='<%# Eval("ClassName") %>' CssClass="form-control "></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblClassName" runat="server" Text='<%#Eval("ClassName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
            </div>
        </div>
    </div>

</asp:Content>--%>
