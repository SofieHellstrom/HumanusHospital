using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HumanusHospital.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Required]
        [Display(Name = "User ID")]
        public string UserID { get; set; }

        [Required]
        public string Password { get; set; }
        public virtual Patient Patient { get; set; } //not currently in use
        //public virtual Staff Staff { get; set; } //not created yet and not in use

        [Display(Name = "Remember on this computer")]
        public bool RememberMe { get; set; }

        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="_username">User name</param>
        /// <param name="_password">User password</param>
        /// <returns>True if user exist and password is correct</returns>
        public bool IsValid(string _username, string _password)
        {
            using (var cn = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=HumanusHospital1;Integrated Security=SSPI;"))
            {
                string _sql = @"SELECT [UserID] FROM [dbo].[User] " +
                       @"WHERE [UserID] = @u AND [Password] = @p";
                var cmd = new SqlCommand(_sql, cn);
                cmd.Parameters
                    .Add(new SqlParameter("@u", SqlDbType.NVarChar))
                    .Value = _username;
                cmd.Parameters
                    .Add(new SqlParameter("@p", SqlDbType.NVarChar))
                    .Value = _password;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
            }

        }
    }
}