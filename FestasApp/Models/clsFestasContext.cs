//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 29/06/2024
//   Ultima Alteração: 29/06/2024
//   
//   CLASSE para auxiliar nas relações entre classes-objetos com  ENTITY FRAMEWORK
//
//************************************************************

namespace FestasApp.Models
{
    public class clsFestasContext : DbContext
    {
        // propriedades conjuntos de dados
        public DbSet<clsFestas> Festas { get; set; }
        public DbSet<clsFestasTipoEvento> TipoEvento { get; set; }
        public DbSet<clsClientes> Clientes { get; set; }
        public DbSet<clsUsuarios> Usuarios { get; set; }
        public DbSet<clsFestasPacotes> Pacotes { get; set; }
        public DbSet<clsFestasTemas> Temas { get; set; }
        public DbSet<clsFestasEspacos> Espacos { get; set; }
        public DbSet<clsFestasStatus> Status { get; set; }
        public DbSet<clsFestasDetalhes> Detalhes { get; set; }
        public DbSet<clsFestasAdicionais> Adicionais { get; set; }
        public DbSet<clsFestasItens> ItensFestas { get; set; }
        public DbSet<clsFestasContratos> Contratos { get; set; }

        // construtor
        //public clsFestasContext(DbContextOptions<clsFestasContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            try
            {
                if (!optionsBuilder.IsConfigured)
                {
                    var conexaoStr = myConnMySql.strConnMySql;
                    optionsBuilder.UseMySql(conexaoStr, ServerVersion.AutoDetect(conexaoStr));
                }
            }
            catch (Exception)
            {
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definições de relacionamentos com tblfestas
            modelBuilder.Entity<clsFestas>()
                .HasOne(f => f.Cliente) 
                .WithMany()
                .HasForeignKey(f => f.fest_cli_id); // tblclientes
            
            // Usuarios
            modelBuilder.Entity<clsFestas>()
                .HasOne(f => f.Usuario) 
                .WithMany()
                .HasForeignKey(f => f.fest_user_id); // tblusuarios
            
            // Pacotes
            modelBuilder.Entity<clsFestas>()
                .HasOne(f => f.Pacote)
                .WithMany()
                .HasForeignKey(f => f.fest_pct_id); // tblfestapacotes

            modelBuilder.Entity<clsFestasPacotes>()
                .Property(p => p.pct_descricao)
                .HasDefaultValue("Não Especificado")
                .IsRequired(false); // Propriedade anulável

            modelBuilder.Entity<clsFestasPacotes>()
                .Property(p => p.pct_duracao)
                .HasDefaultValue("Não Especificado")
                .IsRequired(false); // Propriedade anulável

            modelBuilder.Entity<clsFestasPacotes>()
                .Property(p => p.pct_valor)
                    //.HasDefaultValue(0)
                    .IsRequired(false); // Propriedade anulável
           
            // Temas
            modelBuilder.Entity<clsFestas>()
                .HasOne(f => f.Tema)
                .WithMany()
                .HasForeignKey(f => f.fest_tema_id); // tblfestastemas

            modelBuilder.Entity<clsFestasTemas>()
                .Property(t => t.tema_descricao)
                .HasDefaultValue("Não Especificado")
                .IsRequired(false); // Propriedade anulável
            
            // Espacos
            modelBuilder.Entity<clsFestas>()
                .HasOne(f => f.Espaco)
                .WithMany()
                .HasForeignKey(f => f.fest_espc_id); // tblfestasespacos

            // Status
            modelBuilder.Entity<clsFestas>()
                .HasOne(f => f.Status)
                .WithMany()
                .HasForeignKey(f => f.fest_stt_id); // tblfestasstatus

            // TipoEvento
            modelBuilder.Entity<clsFestas>()
                .HasOne(f => f.TipoEvento)
                .WithMany()
                .HasForeignKey(f => f.fest_tpEv_id); // tblfestastipoevento

            // Detalhes
            modelBuilder.Entity<clsFestasDetalhes>()
                .HasOne(d => d.Festas)
                .WithMany(f => f.Detalhes)
                .HasForeignKey(d => d.detfest_fest_id); // tblfestasdetalhes
           
            modelBuilder.Entity<clsFestasDetalhes>()
                .HasOne(c => c.Contratos)
                .WithMany()
                .HasForeignKey(d => d.detfest_ctt_id); // tblfestascontratos

            modelBuilder.Entity<clsFestasDetalhes>()
                .Property(a => a.detfest_iniciohora)
                    //.HasDefaultValue(0)
                    .IsRequired(false); // Propriedade anulável

            modelBuilder.Entity<clsFestasDetalhes>()
                .Property(a => a.detfest_fimhora)
                    //.HasDefaultValue(0)
                    .IsRequired(false); // Propriedade anulável


            // Adicionais
            modelBuilder.Entity<clsFestasAdicionais>()
                .HasOne(a => a.Festas)
                .WithMany(f => f.Adicionais)
                .HasForeignKey(a => a.add_fest_id); // tblfestasadicionais

            modelBuilder.Entity<clsFestasAdicionais>()
                .Property(a => a.add_qtde)
                    //.HasDefaultValue(0)
                    .IsRequired(false); // Propriedade anulável

            modelBuilder.Entity<clsFestasAdicionais>()
                .Property(a => a.add_valor)
                //.HasDefaultValue(0)
                .IsRequired(false); // Propriedade anulável

            // ItensFestas
            modelBuilder.Entity<clsFestasAdicionais>()
                .HasOne(a => a.ItensFestas)
                .WithMany()
                .HasForeignKey(a => a.add_itensfest_id); // tblfestasitens

            modelBuilder.Entity<clsFestasItens>()
                .Property(i => i.itensfest_tipo)
                .HasDefaultValue("Não Especificado")
                .IsRequired(false); // Propriedade anulável

            modelBuilder.Entity<clsFestasItens>()
                .Property(i => i.itensfest_descricao)
                .HasDefaultValue("Não Especificado")
                .IsRequired(false); // Propriedade anulável

            modelBuilder.Entity<clsFestasItens>()
                .Property(i => i.itensfest_valor)
                //.HasDefaultValue(0)
                .IsRequired(false); // Propriedade anulável

        }
        //
    } // end class clsFestasContext
} // end namespace FestasApp.Models
