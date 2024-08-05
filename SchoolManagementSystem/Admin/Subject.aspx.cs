﻿//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using static SchoolManagementSystem.Models.CommonFn;

//namespace SchoolManagementSystem.Admin
//{
//    public partial class Subject : System.Web.UI.Page
//    {
//        Commonfnx fn = new Commonfnx();
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (!IsPostBack)
//            {
//                GetClass();
//                GetSubject();
//            }
//        }

//        private void GetClass()
//        {
//            DataTable dt = fn.Fetch("Select * from Class");
//            ddlClass.DataSource = dt;
//            ddlClass.DataTextField = "ClassName";
//            ddlClass.DataValueField = "ClassId";
//            ddlClass.DataBind();
//            ddlClass.Items.Insert(0, "Select Class");
//        }


//        protected void btnEkle_Class(object sender, EventArgs e)
//        {
//            try
//            {
//                string classVal = ddlClass.SelectedItem.Text;
//                DataTable dt = fn.Fetch("Select * from Subject where ClassId='" + ddlClass.SelectedItem.Value +
//                                        "' , SubjectName='"+txtSubject.Text.Trim()+"' ");

//                if (dt.Rows.Count == 0)
//                {
//                    string query = "Insert into Subject values('" + ddlClass.SelectedItem.Value + "','" + txtSubject.Text.Trim() + "')";
//                    fn.Query(query);
//                    lblMsg.Text = "Inserted Succesfully!";
//                    lblMsg.CssClass = "alert alert-success";
//                    ddlClass.SelectedIndex = 0;
//                    txtSubject.Text = string.Empty;
//                    GetSubject();


//                }
//                else
//                {
//                    lblMsg.Text = "Entered Subject already exists for <b> '" + classVal + "'</b>!";
//                    lblMsg.CssClass = "alert alert-danger";
//                }


//            }
//            catch (Exception ex)
//            {
//                Response.Write("<script>alert('" + ex.Message + "')");
//            }
//        }

//        private void GetSubject()
//        {
//            DataTable dt = fn.Fetch(@"Select Row_NUMBER() over(Order by (Select 1)) as [Sr.No],s.Subject,s.ClassId,c.ClassName,
//                                    s.SubjectName from Subject s inner join Class c on c.ClassId= s.ClassId");
//            GridView1.DataSource = dt;
//            GridView1.DataBind();
//        }
//        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
//        {
//            GridView1.PageIndex = e.NewPageIndex;
//            GetSubject();
//        }
//        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
//        {
//            GridView1.EditIndex = -1;
//            GetSubject();
//        }

//        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
//        {
//            GridView1.EditIndex = e.NewEditIndex;
//            GetSubject();
//        }
//        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
//        {
//            try
//            {
//                GridViewRow row = GridView1.Rows[e.RowIndex];
//                int feesId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
//                string feeAmt = (row.FindControl("TextBox1") as TextBox).Text;
//                fn.Query("Update Fees set FeesAmount='" + feeAmt + "' where FeesId='" + feesId + "' ");
//                lblMsg.Text = "Fees Updated Succesfully!";
//                lblMsg.CssClass = "aler alert-success";
//                GridView1.EditIndex = -1;
//                GetSubject();
//            }
//            catch (Exception ex)
//            {
//                Response.Write("<script>alert('" + ex.Message + "');</script>");
//            }
//        }
//    }
//}

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManagementSystem.Models;
using System.Data.SqlClient;

namespace SchoolManagementSystem.Admin
{
    public partial class Subject : System.Web.UI.Page
    {
        CommonFn.Commonfnx fn = new CommonFn.Commonfnx();

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
                string classId = ddlClass.SelectedItem.Value;
                string subjectName = txtSubject.Text.Trim();

                string query = "SELECT * FROM Subject WHERE ClassId = @ClassId AND SubjectName = @SubjectName";
                SqlParameter[] parameters = {
                    new SqlParameter("@ClassId", classId),
                    new SqlParameter("@SubjectName", subjectName)
                };
                DataTable dt = fn.Fetch(query, parameters);

                if (dt.Rows.Count == 0)
                {
                    string insertQuery = "INSERT INTO Subject (ClassId, SubjectName) VALUES (@ClassId, @SubjectName)";
                    fn.Query(insertQuery, parameters);
                    lblMsg.Text = "Inserted Successfully!";
                    lblMsg.CssClass = "alert alert-success";
                    ddlClass.SelectedIndex = 0;
                    txtSubject.Text = string.Empty;
                    GetSubject();
                }
                else
                {
                    lblMsg.Text = "Entered Subject already exists for <b> '" + ddlClass.SelectedItem.Text + "'</b>!";
                    lblMsg.CssClass = "alert alert-danger";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = "Error: " + ex.Message;
                lblMsg.CssClass = "alert alert-danger";
            }
        }

        private void GetSubject()
        {
            string query = @"
                SELECT ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS [Sr.No], s.SubjectName, s.ClassId, c.ClassName
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
                lblMsg.Text = ("Subject Updated Succesfully!");
                lblMsg.CssClass = "alert alert-success";
                GridView1.EditIndex = -1;
                GetSubject() ;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" +ex.Message+"');</script>");
            }
        }
    }
}
