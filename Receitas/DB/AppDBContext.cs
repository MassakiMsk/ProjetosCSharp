namespace ProjetoM2
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AppDBContext : DbContext
    {
        // Your context has been configured to use a 'AppDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProjetoM2.AppDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AppDB' 
        // connection string in the application configuration file.
        public AppDBContext() : base("name=AppDBContext")
        {
        }

        public System.Data.Entity.DbSet<ProjetoM2.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<ProjetoM2.Models.Receita> Receitas { get; set; }

        public System.Data.Entity.DbSet<ProjetoM2.Models.Pedido> Pedidos { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}