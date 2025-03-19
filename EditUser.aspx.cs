    using SMS.Web.Repository;
    using System;

    namespace SMS.Web
    {
        public partial class EditUser : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    int userId;
                    if (int.TryParse(Request.QueryString["Id"], out userId))
                    {
                        LoadUserData(userId);
                    }
                }
            }

            private void LoadUserData(int userId)
            {
                ADORepository repository = new ADORepository();
                UserModel user = repository.GetUserById(userId);
                if (user != null)
                {
                    hfUserId.Value = user.Id.ToString();
                    txtFirstName.Text = user.FirstName;
                    txtLastName.Text = user.LastName;
                    txtEmail.Text = user.Email;
                    txtPassword.Text = user.Password;
                    txtUserName.Text = user.UserName;
                    txtGender.Text = user.Gender;
                    txtCreatedOn.Text = user.CreatedOn.HasValue ? user.CreatedOn.Value.ToString("yyyy-MM-dd") : "";
                    txtUpdatedOn.Text = user.UpdatedOn.HasValue ? user.UpdatedOn.Value.ToString("yyyy-MM-dd") : "";
                    chkIsDeleted.Checked = user.IsDeleted.HasValue && user.IsDeleted.Value;
                }
            }

            protected void btnSave_Click(object sender, EventArgs e)
            {
                UserModel user = new UserModel
                {
                    Id = int.Parse(hfUserId.Value),
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    UserName = txtUserName.Text,
                    Gender = txtGender.Text,
                    CreatedOn = string.IsNullOrEmpty(txtCreatedOn.Text) ? (DateTime?)null : DateTime.Parse(txtCreatedOn.Text),
                    UpdatedOn = string.IsNullOrEmpty(txtUpdatedOn.Text) ? (DateTime?)null : DateTime.Parse(txtUpdatedOn.Text),
                    IsDeleted = chkIsDeleted.Checked
                };

                ADORepository repository = new ADORepository();
                bool isUpdated = repository.UpdateUser(user);

                if (isUpdated)
                {
                    Response.Redirect("~/Users.aspx");
                }
                else
                {
                    // Handle the error
                }
            }
        }
    }
