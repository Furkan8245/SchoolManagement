<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="SchoolManagementSystem.Admin.Teacher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div style="background-image:url('..\Image\bc.jpg'); width:100%; height:720px; background-repeat:no-repeat; background-size:cover; background-attachment:fixed;">
     <div class="container p-md-4 p-sm-4">
         <div>
             <asp:Label ID="lblMsg" runat="server"></asp:Label>
         </div>
         <h3 class="text-center">Öğretmen Ekle</h3>
         <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
             <div class="col-md-6">
                 <label for="txtName">İsim</label>
                 <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Name" required>
                 </asp:TextBox>
                 <asp:RegularExpressionValidator runat="server" ErrorMessage="İsim karakterlerden oluşmalıdır." 
                     ForeColor="Red" ValidationExpression="^[A-Za-z]*$" Display="Dynamic" SetFocusError="true" ControlToValidate="txtName" ></asp:RegularExpressionValidator>
             </div>
             <div class="col-md-6">
                 <label for="txtDoB">Doğum Tarihi</label>
                 <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control" TextMode="Date" required></asp:TextBox>
             </div>
         </div>

          <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
     <div class="col-md-6">
         <label for="dllGender">Cinsiyet</label>
         <asp:DropDownList ID="ddlGender" runat="server">
             <asp:ListItem Value="0">Cinsiyet Seç</asp:ListItem>
             <asp:ListItem Value="Erkek">Erkek</asp:ListItem>
             <asp:ListItem Value="Kadın>Kadın</asp:ListItem>
             <asp:ListItem Value="Diğer">Diğer</asp:ListItem>
         </asp:DropDownList>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Cinsiyet gerekli."
             ForeColor="Red" ControlToValidate="ddlGender" Display="Dynamic" SetFocusOnError="true" InitialValue="Cinsiyet Seç"></asp:RequiredFieldValidator>
         
     </div>
     <div class="col-md-6">
         <label for="txtMobile">Mobile</label>
         <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" TextMode="Number" placeholder="10 haneli cep telefonu numarası" required></asp:TextBox>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Geçersiz cep telefonu numarası!" ForeColor="Red" ValidationExpression="^[0-9]{10}" Display="Dynamic" SetFocusOnError="true" ControlToValidate="txtMobile">

    </asp:RegularExpressionValidator>
         
     
     </div>
 </div>
          <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
     <div class="col-md-6">
         <label for="txtEmail">Email</label>
         <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"  TextMode="Email"  required>
         </asp:TextBox>
     </div>
     <div class="col-md-6">
         <label for="txtPassword>Şifre</label>
         <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password" required></asp:TextBox>
     </div>
 </div>

      <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
    <div class="col-md-12">
        <label for="txtAddress">Adres</label>
        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address"  TextMode="MultiLine"  required>
        </asp:TextBox>
    </div>
    
</div>




         <div class="row mb-3 mr-lg-5 ml-lg-5">
             <div class="col-md-3 col-md-offset-2 mb-3">
                 <asp:Button ID="btnEkle" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Subject Ekle"  />
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
