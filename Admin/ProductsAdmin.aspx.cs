using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store_Front.Admin
{
    public partial class ProductsAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetBooleanText(object booleanValue)
        {
            try
            {
                bool isPublished = (bool)booleanValue;
                if (isPublished)
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }
            }
            catch (InvalidCastException e)
            {
                return "N/A";
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("ProductAdminDetails.aspx?ProductID=" + (GridView1.Rows[e.NewEditIndex].Cells[1].Text));
        }

        protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            Response.Redirect("ProductsAdmin.aspx");
        }
    }
}