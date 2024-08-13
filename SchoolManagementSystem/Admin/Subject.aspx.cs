using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Models;
using System.Data.SqlClient;
using System.Reflection;
using System.Security.Claims;

namespace SchoolManagementSystem.Admin
{
    public partial class Subject : System.Web.UI.Page
    {
        CommonFn.Commonfnx fn = new CommonFn.Commonfnx();

        public string classVal { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetClass();
                GetSubject();
            }
        }

        private void GetClass()
        {
            DataTable dt = fn.Fetch("SELECT * FROM Class");
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassId";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, new ListItem("Select Class", "0"));
        }

        protected void btnEkle_Class(object sender, EventArgs e)
        {
            try
            {
                string classVal = ddlClass.SelectedItem.Text;
                DataTable dt=fn.Fetch("Select * from Subject where ClassId = '"+ ddlClass.SelectedItem.Value+
                    "' and SubjectName = '"+ txtSubject.Text.Trim()+"' ");

                if (dt.Rows.Count==0)
                {
                    string query = "Insert into Subject values('" + ddlClass.SelectedItem.Value + "','" + txtSubject.Text.Trim() + "')";
                    fn.Query(query);
                    lblMsg.Text = "Inserted Succesfully!";
                    lblMsg.CssClass = "alert alert-success";
                    ddlClass.SelectedIndex = 0;
                    txtSubject.Text=string.Empty;
                    GetSubject();
                }
                else
                {
                    lblMsg.Text = "Entered Subject already exists for <b> '" + classVal + "'</b>!";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                // Hata mesajını ekranda göstermek
                lblMsg.Text = "An error occurred: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
            }

        }

        private void GetSubject()
        {
            string query = @"
        SELECT 
            ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS [Sr.No],
            s.SubjectId,
            s.SubjectName,
            s.ClassId,
            c.ClassName
        FROM Subject s
        INNER JOIN Class c ON c.ClassId = s.ClassId";

            DataTable dt = fn.Fetch(query);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GetSubject();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GetSubject();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GetSubject();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex];
                int subjId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
                string classId = ((DropDownList)GridView1.Rows[e.RowIndex].Cells[2].FindControl("DropDownList1")).SelectedValue;
                string subjName = (row.FindControl("TextBox1") as TextBox).Text;

                fn.Query("Update Subject set ClassId='" + classId + "', SubjectName='" + subjName + "' where SubjectId='" + subjId + "' ");
                lblMsg.Text = "Subject Updated Successfully!";
                lblMsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                GetSubject();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList ddlClass = (DropDownList)e.Row.FindControl("DropDownList1");
                DataTable dt = fn.Fetch("SELECT * FROM Class");
                ddlClass.DataSource = dt;
                ddlClass.DataTextField = "ClassName";
                ddlClass.DataValueField = "ClassId";
                ddlClass.DataBind();

                // Select the class value for the current row
                ddlClass.SelectedValue = DataBinder.Eval(e.Row.DataItem, "ClassId").ToString();
            }
        }
    }
}
