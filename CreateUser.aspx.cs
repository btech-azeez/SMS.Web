using SMS.Web.Repository;
using System;
using System.Web.UI;

namespace SMS.Web
{
    public partial class CreateUser : Page
    {
        private ADORepository repository = new ADORepository();

        protected void btnSave_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Password = txtPassword.Text,
                Gender = txtGender.Text,
            };

            bool success = repository.CreateUser(user);
            if (success)
            {
                Response.Redirect("Users.aspx");
            }
            else
            {
                // Handle creation failure
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Users.aspx");
        }
    }
}
