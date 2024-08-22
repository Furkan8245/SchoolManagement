<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="TeacherSubject.aspx.cs" Inherits="SchoolManagementSystem.Admin.TeacherSubject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div style="background-image:url('..\Image\bc.jpg'); width:100%; height:720px; background-repeat:no-repeat; background-size:cover; background-attachment:fixed;">
     <div class="container p-md-4 p-sm-4">
         <div>
             <asp:Label ID="lblMsg" runat="server"></asp:Label>
         </div>
         <h3 class="text-center">Add Teacher Subject</h3>
         <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
             <div class="col-md-6">
                 <label for="txtClass">Class</label>
                 <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Class is required." ControlToValidate="ddlClass"
                     InitialValue="Select Class"
                     Display="Dynamic" SetFocusOnError="True" ForeColor="Red">
                 </asp:RequiredFieldValidator>
             </div>
             <div class="col-md-6">
                 <label for="ddlSubject">Subject</label>
                 <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control"></asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Subject is required." ControlToValidate="ddlSubject"
    InitialValue="Select Subject"
    Display="Dynamic" SetFocusOnError="True" ForeColor="Red">
</asp:RequiredFieldValidator>
             </div>
             <div class="col-md-6">
                 <label for="ddlTeacher">Teacher</label>
                 <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control"></asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Teacher is required." ControlToValidate="ddlTeacher"
    InitialValue="Select Teacher"
    Display="Dynamic" SetFocusOnError="True" ForeColor="Red">
</asp:RequiredFieldValidator>
             </div>
         </div>

         <div class="row mb-3 mr-lg-5 ml-lg-5">
             <div class="col-md-3 col-md-offset-2 mb-3">
                 <asp:Button ID="btnEkle" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Öğretmen Ata" OnClick="btnEkle_Class" />
             </div>
         </div>

         <div class="row mb-3 mr-lg-5 ml-lg-5">
             <div class="col-md-6">
                 <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" EmptyDataText="No record to display!" AutoGenerateColumns="False" AllowPaging="true" 
                     OnPageIndexChanging="GridView1_PageIndexChanging" 
                     OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                     PageSize="4"
                     OnRowEditing="GridView1_RowEditing" 
                     OnRowUpdating="GridView1_RowUpdating"
                     OnRowDataBound="GridView1_RowDataBound" 
                     DataKeyNames="SubjectId">
                     <Columns>
                         <asp:BoundField DataField="Sr.No" HeaderText="Sr.No" ReadOnly="true">
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:BoundField>
                         <asp:TemplateField HeaderText="Class">
                             <EditItemTemplate>
                                 <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                 </asp:DropDownList>
                                 <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SchoolCs %>" SelectCommand="SELECT * FROM [Class]"></asp:SqlDataSource>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label2" runat="server" Text='<%# Eval("ClassName") %>'></asp:Label>
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center"></ItemStyle>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="Subject">
                             <EditItemTemplate>
                                 <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("SubjectName") %>' CssClass="form-control"></asp:TextBox>
                             </EditItemTemplate>
                             <ItemTemplate>
                                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("SubjectName") %>'></asp:Label>
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                         </asp:TemplateField>
                         <asp:CommandField CausesValidation="false" ShowDeleteButton="True" ShowEditButton="True" HeaderText="Operation"> 
                             <ItemStyle HorizontalAlign="Center"></ItemStyle>
                         </asp:CommandField>
                     </Columns>
                 </asp:GridView>
             </div>
         </div>
     </div>
 </div>



</asp:Content>
