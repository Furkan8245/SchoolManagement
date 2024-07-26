<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="ClassFees.aspx.cs" Inherits="SchoolManagementSystem.Admin.ClassFees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div class="container-custom">
        <div class="container p-md-4 p-sm-4 form-container">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h3 class="text-center">New Fees </h3>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="ddlClass">Class</label>
                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Class is required." ControlToValidate="ddlClass" 
                        InitialValue="Select Class" Display="Dynamic" SetFocusOnError="True" ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-6">
                    <label for="txtFeeAmounts">Fees(Annual)</label>
                    <asp:TextBox ID="txtFeeAmounts" runat="server" CssClass="form-control" placeholder="Enter Fee Amount" required TextMode="Number" ></asp:TextBox>
                </div>
            </div>
            <div class="row mb-3">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnEkle" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Ekle Class" OnClick="btnEkle_Class" />
                </div>
            </div>
            <div class="row grid-container">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
