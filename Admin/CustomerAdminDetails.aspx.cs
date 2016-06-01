using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store_Front.Admin
{
    public partial class CustomerAdminDetails : System.Web.UI.Page
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
            }catch(InvalidCastException e)
            {
                return "N/A";
            }
        }

        protected void DetailsView1_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            Response.Redirect("CustomersAdmin.aspx");
        }

        protected void DetailsView1_ItemDeleted(object sender, DetailsViewDeletedEventArgs e)
        {
            Response.Redirect("CustomersAdmin.aspx");
        }
    }
}