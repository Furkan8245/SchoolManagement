using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static SchoolManagementSystem.Models.CommonFn;

namespace SchoolManagementSystem.Admin
{
    public partial class AddClass : System.Web.UI.Page
    {
        readonly Commonfnx fn=new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                GetClass();

            }
        }

        private void GetClass()
        {
            DataTable dt = fn.Fetch("Select Row_NUMBER() over(Order by (Select 1)) as [Sr.No],ClassId,ClassName from Class");
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = fn.Fetch("Select * from Class where ClassName= '"+ txtClass.Text.Trim() +"' ");
                if (dt.Rows.Count==0)
                {
                    string query = "Insert into Class values('" + txtClass.Text.Trim() + "')";
                    fn.Query(query);
                    lblMsg.Text = "Inserted Succesfully!";
                    lblMsg.CssClass = "alert alert-success";
                    txtClass.Text = string.Empty;
                    GetClass();


                }
                else
                {
                    lblMsg.Text = "Entered Class already exists!";
                    lblMsg.CssClass = "alert alert-danger";
                }
                

            }
            catch(Exception ex) 
            { 
              Response.Write("<script>alert('"+ ex.Message+"')");
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
          
        }
        protected void txtClass_TextChanged(object sender, EventArgs e)
        {
            
        }


    }
}