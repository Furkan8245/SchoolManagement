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
    public partial class TeacherSubject : System.Web.UI.Page
    {
        Commonfnx fn=new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void GetClass()
        {
            DataTable dt = fn.Fetch("Select * from Class");
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "ClassName";
            ddlClass.DataValueField = "ClassId";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, "Select Class");
        }
        private void GetSubject()
        {
            DataTable dt = fn.Fetch("Select * from Teacher");
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "Name";
            ddlClass.DataValueField = "TeacherId";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, "Select Teacher");
        }
        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            string classId= ddlClass.SelectedValue;
            DataTable dt = fn.Fetch("Select * from Subject where ClassId='"+classId+"'");
            ddlClass.DataSource = dt;
            ddlClass.DataTextField = "SubjectName";
            ddlClass.DataValueField = "SubjectId";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, "Select Subject");

        }
        protected void btnAdd_Click(object sender,EventArgs e)
        {

        }
    }
}