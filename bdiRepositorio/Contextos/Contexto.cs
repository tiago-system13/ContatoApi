using bdiEntidades.Entidades;
using bdiNegocios.Interfaces;
using bdiRepositorio.Mapiamentos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace bdiRepositorio.Contextos
{
    public class Contexto : DbContext
    {
        public DbSet<Contato> Contatos { get; set; }

        public Contexto()
           : base()
        {
        }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMapeamento());


            // Aqui estou obtendo todas as classes de configuração das entidades.
            // através da interface IEntityConfig, criada única e exclusivamente para isto.
            // Sendo assim, não precisamos lembrar de, ao criar a configuração de alguma entidade, colocar mais uma linha de código neste trecho.
            var typesToRegister = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IEntityConfig).IsAssignableFrom(x) && !x.IsAbstract).ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

        }

       



    }

}
