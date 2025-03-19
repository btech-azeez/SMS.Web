using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SMS.Web.Repository
{
    public class ADORepository
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["SMSEntity"].ConnectionString;

        public List<UserModel> GetUsers()
        {
            List<UserModel> userModels = new List<UserModel>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("USP_GetAllUsers", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            UserModel userModel = new UserModel
                            {
                                Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                                FirstName = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("FirstName")) ? null : sqlDataReader.GetString(sqlDataReader.GetOrdinal("FirstName")),
                                LastName = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("LastName")) ? null : sqlDataReader.GetString(sqlDataReader.GetOrdinal("LastName")),
                                Email = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Email")) ? null : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Email")),
                                Password = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Password")) ? null : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Password")),
                                UserName = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("UserName")) ? null : sqlDataReader.GetString(sqlDataReader.GetOrdinal("UserName")),
                                Gender = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Gender")) ? null : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Gender")),
                                CreatedOn = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("CreatedOn")) ? (DateTime?)null : sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("CreatedOn")),
                                UpdatedOn = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("UpdatedOn")) ? (DateTime?)null : sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("UpdatedOn")),
                                IsDeleted = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("IsDeleted")) ? (bool?)null : sqlDataReader.GetBoolean(sqlDataReader.GetOrdinal("IsDeleted"))
                            };
                            userModels.Add(userModel);
                        }
                    }
                }
            }
            return userModels;
        }

        public UserModel GetUserById(int id)    
        {
            UserModel userModel = null;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("USP_GetUserById", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", id);
                    sqlConnection.Open();

                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            userModel = new UserModel
                            {
                                Id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")),
                                FirstName = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("FirstName")) ? null : sqlDataReader.GetString(sqlDataReader.GetOrdinal("FirstName")),
                                LastName = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("LastName")) ? null : sqlDataReader.GetString(sqlDataReader.GetOrdinal("LastName")),
                                Email = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Email")) ? null : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Email")),
                                Password = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Password")) ? null : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Password")),
                                UserName = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("UserName")) ? null : sqlDataReader.GetString(sqlDataReader.GetOrdinal("UserName")),
                                Gender = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Gender")) ? null : sqlDataReader.GetString(sqlDataReader.GetOrdinal("Gender")),
                                CreatedOn = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("CreatedOn")) ? (DateTime?)null : sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("CreatedOn")),
                                UpdatedOn = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("UpdatedOn")) ? (DateTime?)null : sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("UpdatedOn")),
                                IsDeleted = sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("IsDeleted")) ? (bool?)null : sqlDataReader.GetBoolean(sqlDataReader.GetOrdinal("IsDeleted"))
                            };
                        }
                    }
                }
            }

            return userModel;
        }

        public bool CreateUser(UserModel user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("USP_CreateUser", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName ?? (object)DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@LastName", user.LastName ?? (object)DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email ?? (object)DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password ?? (object)DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Gender", user.Gender ?? (object)DBNull.Value);
                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateUser(UserModel user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("USP_UpdateUser", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", user.Id);
                    sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName ?? (object)DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@LastName", user.LastName ?? (object)DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email ?? (object)DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password ?? (object)DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@UserName", user.UserName ?? (object)DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Gender", user.Gender ?? (object)DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@CreatedOn", (object)user.CreatedOn ?? DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@UpdatedOn", (object)user.UpdatedOn ?? DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@IsDeleted", (object)user.IsDeleted ?? DBNull.Value);

                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool DeleteUser(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand("USP_DeleteUser", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Id", id);

                    sqlConnection.Open();
                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

    }

    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Gender { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
