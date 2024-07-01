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

        // construtor
        //public clsFestasContext(DbContextOptions<clsFestasContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            try
            {
                if (!optionsBuilder.IsConfigured)
                {
                    var conexaoStr = ConnMySql.strConnMySql;
                    optionsBuilder.UseMySql(conexaoStr, ServerVersion.AutoDetect(conexaoStr));
                }
            }
            catch (MySqlException ex)
            {
            //    FormMenuMain.ShowMyMessageBox($"Falha na conexão com banco de dados: {ex.Message}\nOnConfiguring", "Falha MySql");
            }
            catch (Exception ex)
            {
            //    FormMenuMain.ShowMyMessageBox($"Erro inesperado: {ex.Message}\nOnConfiguring", "Erro");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definições de relacionamentos
            modelBuilder.Entity<clsFestas>()
                .HasOne(f => f.Cliente)
                .WithMany()
                .HasForeignKey(f => f.fest_cli_id);

            modelBuilder.Entity<clsFestas>()
                .HasOne(f => f.Usuario)
                .WithMany()
                .HasForeignKey(f => f.fest_user_id);
            // Pacotes
            modelBuilder.Entity<clsFestas>()
                .HasOne(f => f.Pacote)
                .WithMany()
                .HasForeignKey(f => f.fest_pct_id);

            modelBuilder.Entity<clsFestasPacotes>()
                .Property(p => p.pct_descricao)
                .HasDefaultValue("Não Especificado");

            modelBuilder.Entity<clsFestasPacotes>()
                .Property(p => p.pct_duracao)
                .HasDefaultValue("Não Especificado");

            modelBuilder.Entity<clsFestasPacotes>()
                .Property(p => p.pct_valor)
                .HasDefaultValue(0);
            // Temas --------------------------------
            modelBuilder.Entity<clsFestas>()
                .HasOne(f => f.Tema)
                .WithMany()
                .HasForeignKey(f => f.fest_tema_id);

            modelBuilder.Entity<clsFestasTemas>()
                .Property(t => t.tema_descricao)
                .HasDefaultValue("Não Especificado");
            //----------------------------------------
            modelBuilder.Entity<clsFestas>()
                .HasOne(f => f.Espaco)
                .WithMany()
                .HasForeignKey(f => f.fest_espc_id);

            modelBuilder.Entity<clsFestas>()
                .HasOne(f => f.Status)
                .WithMany()
                .HasForeignKey(f => f.fest_stt_id);

            modelBuilder.Entity<clsFestas>()
                .HasOne(f => f.TipoEvento)
                .WithMany()
                .HasForeignKey(f => f.fest_tpEv_id);

            // Definições de relacionamentos para clsFestasDetalhes
            modelBuilder.Entity<clsFestasDetalhes>()
                .HasOne(d => d.Festas)
                .WithMany(f => f.Detalhes)
                .HasForeignKey(d => d.detfest_fest_id);
            
            //
            // Definições de relacionamentos para clsFestasAdicionais
            //
            modelBuilder.Entity<clsFestasAdicionais>()
                .HasOne(a => a.Festas)
                .WithMany(f => f.Adicionais)
                .HasForeignKey(a => a.add_fest_id);

            modelBuilder.Entity<clsFestasAdicionais>()
                .Property(a => a.add_qtde)
                .HasDefaultValue(0);

            modelBuilder.Entity<clsFestasAdicionais>()
                .Property(a => a.add_valor)
                .HasDefaultValue(0);
            //-----------------------------------------------
            // FestasItens ----------------------------------
            modelBuilder.Entity<clsFestasAdicionais>()
                .HasOne(a => a.ItensFestas)
                .WithMany()
                .HasForeignKey(a => a.add_itensfest_id);

            modelBuilder.Entity<clsFestasItens>()
                .Property(i => i.itensfest_tipo)
                .HasDefaultValue("Não Especificado");



            modelBuilder.Entity<clsFestasItens>()
                .Property(i => i.itensfest_descricao)
                .HasDefaultValue("Não Especificado");

            modelBuilder.Entity<clsFestasItens>()
                .Property(i => i.itensfest_valor)
                .HasDefaultValue(0);
            //-----------------------------------------------
        }
        //
    } // end class clsFestasContext
} // end namespace FestasApp.Models
