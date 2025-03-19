using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SMS.Web.Repository
{
    public partial class SMSEntity : DbContext
    {
        public SMSEntity()
            : base("name=SMSEntity")
        {
        }

        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<SMS.Web.Models.UserModel> UserModels { get; set; }
        public object Users { get; internal set; }
    }
}
