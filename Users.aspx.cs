using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using SMS.Web.Repository; // Assuming your repository namespace is here

namespace SMS.Web
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUsers();
            }
        }

        private void BindUsers()
        {
            ADORepository repository = new ADORepository();
            List<UserModel> users = repository.GetUsers(); // Assuming you have a method to get users
            GridViewUsers.DataSource = users;
            GridViewUsers.DataBind();
        }

        protected void GridViewUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteUser")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int userId = Convert.ToInt32(GridViewUsers.DataKeys[index].Value);

                ADORepository repository = new ADORepository();
                bool isDeleted = repository.DeleteUser(userId); // Assuming you have a method to delete user

                if (isDeleted)
                {
                    BindUsers();
                }
                else
                {
                    // Handle the case when deletion fails
                }
            }
            else if (e.CommandName == "DetailsUser")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int userId = Convert.ToInt32(GridViewUsers.DataKeys[index].Value);

                // Redirect to a details page with the user ID as a query parameter
                Response.Redirect($"UserDetails.aspx?id={userId}");
            }
        }
    }
}
