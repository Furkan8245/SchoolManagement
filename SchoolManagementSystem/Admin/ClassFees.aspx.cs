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
    public partial class ClassFees : System.Web.UI.Page
    {
        Commonfnx fn=new Commonfnx();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetClass();
                GetFees();
            }
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


        protected void btnEkle_Class(object sender, EventArgs e)
        {
            try
            {
                string classVal = ddlClass.SelectedItem.Text;
                DataTable dt = fn.Fetch("Select * from Fees where ClassId='" + ddlClass.SelectedItem.Value + "'");
               
                if (dt.Rows.Count == 0)
                {
                    string query = "Insert into Fees values('"+ ddlClass.SelectedItem.Value+"','" + txtFeeAmounts.Text.Trim() + "')";
                    fn.Query(query);
                    lblMsg.Text = "Inserted Succesfully!";
                    lblMsg.CssClass = "alert alert-success";
                    ddlClass.SelectedIndex = 0;
                    txtFeeAmounts.Text=string.Empty;
                    GetFees();


                }
                else
                {
                    lblMsg.Text = "Entered Fees already exists for <b> '"+ classVal+ "'</b>!";
                    lblMsg.CssClass = "alert alert-danger";
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')");
            }
        }

        private void GetFees()
        {
            DataTable dt = fn.Fetch(@"Select Row_NUMBER() oveer(Order by (Select 1)) as [Sr.No],f.FeesId,f.ClassId,c.ClassName,
                                    f.FeesAmount from Fees f inner join Class c on c.ClassId= f.ClassId");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}