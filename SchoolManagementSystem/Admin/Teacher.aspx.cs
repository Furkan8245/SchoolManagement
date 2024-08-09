using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.Admin
{

    public partial class Teacher : System.Web.UI.Page
    {
        Commonfnx fn = new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnEkle_Click(object sender,EventArgs e)
        {
            try
            {
                if (ddlGender.SelectedValue!="0")
                {
                    string email = txtEmail.Text.Trim();
                    DataTable dt = fn.Fetch("Select from Teacher where Email='" + email + "' ");
                    if (dt.Rows.Count==0)
                    {
                        string query = "Insert into Teacher values('" + txtName.Text.Trim() + "', '" + txtDoB.Text.Trim() + "','" +
                           ddlGender.SelectedValue + "','" + txtMobile.Text.Trim() + "','" + txtEmail.Text.Trim() + "','" +
                           txtAddress.Text.Trim() + "','" + txtPassword.Text.Trim() + "' ";
                        fn.Query(query);
                        lblMsg.Text = "Inserted Succesfully";
                        lblMsg.CssClass = "alert alert-success";
                        ddlGender.SelectedIndex = 0;
                        txtName.Text=string.Empty;
                        txtDoB.Text=string.Empty;
                        txtMobile.Text=string.Empty;
                        txtEmail.Text=string.Empty;
                        txtAddress.Text=string.Empty;
                        txtPassword.Text=string.Empty;

                    }
                    else 
                    {
                        lblMsg.Text = "Entered <b>'" + email + "' </b> already exists!";
                        lblMsg.CssClass = "alert alert-danger";

                    }
                }
                else
                {
                    lblMsg.Text = "Gender is required";
                    lblMsg.CssClass = "alert alert-danger";
                }

            }
            catch (Exception ex)
            {

               Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
    }
}