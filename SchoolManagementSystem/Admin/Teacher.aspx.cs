using System;
using System.Data;
using System.Data.SqlClient;
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
            if (!IsPostBack)
            {
                GetTeachers();
            }
        }

        private void GetTeachers()
        {
            DataTable dt = fn.Fetch("SELECT ROW_NUMBER() OVER(ORDER BY (SELECT 1)) as [Sr.No], TeacherId, [Name], DOB, Gender, Mobile, Email, [Address], [Password] FROM Teacher");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void BtnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlGender.SelectedValue != "0")
                {
                    string email = txtEmail.Text.Trim();
                    DataTable dt = fn.Fetch("SELECT * FROM Teacher WHERE Email = @Email", new SqlParameter[] { new SqlParameter("@Email", email) });

                    if (dt.Rows.Count == 0)
                    {
                        string query = "INSERT INTO Teacher (Name, DOB, Gender, Mobile, Email, [Address], [Password]) VALUES (@Name, @DOB, @Gender, @Mobile, @Email, @Address, @Password)";
                        fn.Query(query, new SqlParameter[]
                        {
                            new SqlParameter("@Name", txtName.Text.Trim()),
                            new SqlParameter("@DOB", txtDoB.Text.Trim()),
                            new SqlParameter("@Gender", ddlGender.SelectedValue),
                            new SqlParameter("@Mobile", txtMobile.Text.Trim()),
                            new SqlParameter("@Email", txtEmail.Text.Trim()),
                            new SqlParameter("@Address", txtAddress.Text.Trim()),
                            new SqlParameter("@Password", txtPassword.Text.Trim())
                        });

                        lblMsg.Text = "Inserted Successfully!";
                        lblMsg.CssClass = "alert alert-success";
                        ddlGender.SelectedIndex = 0;
                        txtName.Text = string.Empty;
                        txtDoB.Text = string.Empty;
                        txtMobile.Text = string.Empty;
                        txtEmail.Text = string.Empty;
                        txtAddress.Text = string.Empty;
                        txtPassword.Text = string.Empty;
                        GetTeachers();
                    }
                    else
                    {
                        lblMsg.Text = $"Entered <b>'{email}'</b> already exists!";
                        lblMsg.CssClass = "alert alert-danger";
                    }
                }
                else
                {
                    lblMsg.Text = "Gender is required";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (SqlException ex)
            {
                lblMsg.Text = "Bir hata oluştu: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
            }

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int teacherId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                fn.Query("DELETE FROM Teacher WHERE TeacherId = @TeacherId", new SqlParameter[] { new SqlParameter("@TeacherId", teacherId) });
                lblMsg.Text = "Teacher Deleted Successfully!";
                lblMsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                GetTeachers();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetTeachers();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetTeachers();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GetTeachers();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int teacherId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string name = (row.FindControl("txtName") as TextBox).Text;
                string mobile = (row.FindControl("txtMobile") as TextBox).Text;
                string password = (row.FindControl("txtPassword") as TextBox).Text;
                string address = (row.FindControl("txtAddress") as TextBox).Text;

                // İsim kontrolü: sadece harfler
                if (!System.Text.RegularExpressions.Regex.IsMatch(name, @"^[a-zA-Z\s]+$"))
                {
                    lblMsg.Text = "İsim sadece harflerden oluşmalıdır!";
                    lblMsg.CssClass = "alert alert-danger";
                    return;
                }

                // SQL sorgusu güncellenmiş haliyle
                fn.Query("UPDATE Teacher SET Name = @Name, Mobile = @Mobile, Address = @Address, Password = @Password WHERE TeacherId = @TeacherId",
                new SqlParameter[]
                {
                    new SqlParameter("@Name", name.Trim()),
                    new SqlParameter("@Mobile", mobile.Trim()),
                    new SqlParameter("@Address", address.Trim()),
                    new SqlParameter("@Password", password.Trim()),
                    new SqlParameter("@TeacherId", teacherId)
                });

                lblMsg.Text = "Öğretmen başarıyla güncellendi!";
                lblMsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                GetTeachers();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }
    }
}
