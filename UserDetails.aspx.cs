using System;
using SMS.Web.Repository; // Assuming your repository namespace is here

namespace SMS.Web
{
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userId;
                if (int.TryParse(Request.QueryString["id"], out userId))
                {
                    LoadUserDetails(userId);
                }
            }
        }

        private void LoadUserDetails(int userId)
        {
            ADORepository repository = new ADORepository();
            UserModel user = repository.GetUserById(userId); // Assuming you have a method to get user by ID

            if (user != null)
            {
                lblUserId.Text = user.Id.ToString();
                lblFirstName.Text =  user.FirstName;
                lblLastName.Text = user.LastName;
                lblEmail.Text = user.Email;
                lblUserName.Text = user.UserName;
                lblGender.Text = user.Gender;
                lblCreatedOn.Text = user.CreatedOn.ToString();
                lblUpdatedOn.Text = user.UpdatedOn.ToString();
            }
            else
            {
                // Handle the case when the user is not found
            }
        }
    }
}
