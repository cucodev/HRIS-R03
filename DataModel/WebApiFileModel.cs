namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    #region unused Class 
    public partial class WebApiFileModel : DbContext
    {

        #region unused
        public WebApiFileModel()
            : base("name=WebApiFileModel")
        {
        }


        
        #endregion
    }
    #endregion

    public partial class FileEntities : DbContext
    {
        public FileEntities()
            : base("FileEntities")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DbContext>(null);
        }
        public DbSet<filePersonImage> filePersonImage { get; set; }
        public DbSet<fileUpload> fileUpload { get; set; }

    }
}
