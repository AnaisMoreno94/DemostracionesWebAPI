using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore; //Agregar
using WebApiLibros.Models;
namespace WebApiLibros.Data
{
    public class DBLibrosContext:DbContext
    {
        //Agregar el Constructor siempre
        public DBLibrosContext(DbContextOptions<DBLibrosContext> options): base(options) { }

        public DbSet<Libro> Libros { get; set; }   

        public DbSet<Autor> Autores { get; set; }
    }
}
