using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SanGuseppeNuovoSito.Models
{
    public partial class SanGiuseppeNuovoSitoContext : DbContext
    {
        public SanGiuseppeNuovoSitoContext()
        {
        }

        public SanGiuseppeNuovoSitoContext(DbContextOptions<SanGiuseppeNuovoSitoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anagrafica> Anagraficas { get; set; }
        public virtual DbSet<AnagraficaPrimaDelleModifiche> AnagraficaPrimaDelleModifiches { get; set; }
        public virtual DbSet<AnagraficaRuoli> AnagraficaRuolis { get; set; }
        public virtual DbSet<AnagraficaSospesi> AnagraficaSospesis { get; set; }
        public virtual DbSet<AnagraficaStorico> AnagraficaStoricos { get; set; }
        public virtual DbSet<Avvisi> Avvisis { get; set; }
        public virtual DbSet<CapiGruppetto> CapiGruppettos { get; set; }
        public virtual DbSet<FondoComune> FondoComunes { get; set; }
        public virtual DbSet<FondoComuneSospesi> FondoComuneSospesis { get; set; }
        public virtual DbSet<FondoComuneStorico> FondoComuneStoricos { get; set; }
        public virtual DbSet<Help> Helps { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<RegistroAccessi> RegistroAccessis { get; set; }
        public virtual DbSet<SpedizioneEmailSito> SpedizioneEmailSitos { get; set; }
        public virtual DbSet<TabellaCittum> TabellaCitta { get; set; }
        public virtual DbSet<TabellaCodiciRuolo> TabellaCodiciRuolos { get; set; }
        public virtual DbSet<TabellaGruppetti> TabellaGruppettis { get; set; }
        public virtual DbSet<TabellaGruppi> TabellaGruppis { get; set; }
        public virtual DbSet<TabellaGruppiAccesso> TabellaGruppiAccessos { get; set; }
        public virtual DbSet<TabellaLingue> TabellaLingues { get; set; }
        public virtual DbSet<TabellaNazioni> TabellaNazionis { get; set; }
        public virtual DbSet<TabellaParametri> TabellaParametris { get; set; }
        public virtual DbSet<TabellaProfessioni> TabellaProfessionis { get; set; }
        public virtual DbSet<TabellaRegioni> TabellaRegionis { get; set; }
        public virtual DbSet<TabellaValute> TabellaValutes { get; set; }
        public virtual DbSet<TabellaZone> TabellaZones { get; set; }
        public virtual DbSet<Traduzioni> Traduzionis { get; set; }
        public virtual DbSet<Utenti> Utentis { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.0.13;Database=SanGiuseppeNuovoSito;User=sangtest;password=!vadoalmare");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Anagrafica>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Anagrafica");

                entity.Property(e => e.Camera).HasMaxLength(50);

                entity.Property(e => e.CapDomicilio).HasMaxLength(50);

                entity.Property(e => e.CapResidenza).HasMaxLength(50);

                entity.Property(e => e.Cellulare).HasMaxLength(50);

                entity.Property(e => e.Cittadinanza).HasMaxLength(50);

                entity.Property(e => e.CittàDomicilio).HasMaxLength(50);

                entity.Property(e => e.CittàResidenza).HasMaxLength(50);

                entity.Property(e => e.Codfisc)
                    .HasMaxLength(16)
                    .HasColumnName("codfisc");

                entity.Property(e => e.Cognome).HasMaxLength(50);

                entity.Property(e => e.DataInizio).HasColumnType("datetime");

                entity.Property(e => e.DataLettera).HasMaxLength(50);

                entity.Property(e => e.DatadiNascita).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gruppo).HasMaxLength(50);

                entity.Property(e => e.Idsocio).HasColumnName("IDSocio");

                entity.Property(e => e.IndirizzoDomicilio).HasMaxLength(50);

                entity.Property(e => e.IndirizzoResidenza).HasMaxLength(50);

                entity.Property(e => e.Lingua).HasMaxLength(50);

                entity.Property(e => e.LuogodiNascita).HasMaxLength(50);

                entity.Property(e => e.Nazione).HasMaxLength(50);

                entity.Property(e => e.NazioneDomicilio).HasMaxLength(50);

                entity.Property(e => e.NazioneResidenza).HasMaxLength(50);

                entity.Property(e => e.Nome).HasMaxLength(50);

                entity.Property(e => e.NumeroIscrizioneFraternità).HasMaxLength(50);

                entity.Property(e => e.PartecipaRitiroData).HasColumnType("datetime");

                entity.Property(e => e.Professione).HasMaxLength(50);

                entity.Property(e => e.Provincia).HasMaxLength(50);

                entity.Property(e => e.ProvinciaDomicilio).HasMaxLength(50);

                entity.Property(e => e.ProvinciaResidenza).HasMaxLength(50);

                entity.Property(e => e.RitiroPagamentoCro)
                    .HasMaxLength(50)
                    .HasColumnName("RitiroPagamentoCRO");

                entity.Property(e => e.RitiroPagamentoData).HasColumnType("datetime");

                entity.Property(e => e.RitiroPagamentoIdtransazione)
                    .HasMaxLength(50)
                    .HasColumnName("RitiroPagamentoIDTransazione");

                entity.Property(e => e.Sesso).HasMaxLength(1);

                entity.Property(e => e.Telefono1).HasMaxLength(50);

                entity.Property(e => e.Telefono2).HasMaxLength(50);

                entity.Property(e => e.TipoPagamento).HasMaxLength(50);

                entity.Property(e => e.Zona).HasMaxLength(50);
            });

            modelBuilder.Entity<AnagraficaPrimaDelleModifiche>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AnagraficaPrimaDelleModifiche");

                entity.Property(e => e.CapDomicilio).HasMaxLength(50);

                entity.Property(e => e.CapResidenza).HasMaxLength(50);

                entity.Property(e => e.Cellulare)
                    .HasMaxLength(50)
                    .HasColumnName("cellulare");

                entity.Property(e => e.Cittadinanza)
                    .HasMaxLength(50)
                    .HasColumnName("cittadinanza");

                entity.Property(e => e.CittàDomicilio).HasMaxLength(50);

                entity.Property(e => e.CittàResidenza).HasMaxLength(50);

                entity.Property(e => e.Codfisc)
                    .HasMaxLength(16)
                    .HasColumnName("codfisc");

                entity.Property(e => e.Cognome).HasMaxLength(50);

                entity.Property(e => e.DatadiNascita).HasColumnType("datetime");

                entity.Property(e => e.DescrizioneProfessione).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idsocio).HasColumnName("IDSocio");

                entity.Property(e => e.IndirizzoDomicilio).HasMaxLength(50);

                entity.Property(e => e.IndirizzoResidenza).HasMaxLength(50);

                entity.Property(e => e.LuogoDiLavoro).HasMaxLength(100);

                entity.Property(e => e.LuogodiNascita).HasMaxLength(50);

                entity.Property(e => e.Nazione)
                    .HasMaxLength(50)
                    .HasColumnName("nazione");

                entity.Property(e => e.NazioneDomicilio).HasMaxLength(50);

                entity.Property(e => e.NazioneResidenza).HasMaxLength(50);

                entity.Property(e => e.Nome).HasMaxLength(50);

                entity.Property(e => e.NumeroIscrizioneFraternità).HasMaxLength(50);

                entity.Property(e => e.Professione).HasMaxLength(50);

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .HasColumnName("provincia");

                entity.Property(e => e.ProvinciaDomicilio).HasMaxLength(50);

                entity.Property(e => e.ProvinciaResidenza).HasMaxLength(50);

                entity.Property(e => e.Sesso).HasMaxLength(1);

                entity.Property(e => e.Telefono1)
                    .HasMaxLength(50)
                    .HasColumnName("telefono1");

                entity.Property(e => e.Telefono2)
                    .HasMaxLength(50)
                    .HasColumnName("telefono2");

                entity.Property(e => e.TipoPagamento).HasMaxLength(50);
            });

            modelBuilder.Entity<AnagraficaRuoli>(entity =>
            {
                entity.HasKey(e => e.IdanafraficaIncarico);

                entity.ToTable("AnagraficaRuoli");

                entity.Property(e => e.IdanafraficaIncarico).HasColumnName("IDAnafraficaIncarico");

                entity.Property(e => e.CodiceRuolo).HasMaxLength(50);

                entity.Property(e => e.DataInizio).HasColumnType("date");

                entity.Property(e => e.Idanagrafica).HasColumnName("IDAnagrafica");

                entity.Property(e => e.Scadenza).HasColumnType("date");
            });

            modelBuilder.Entity<AnagraficaSospesi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AnagraficaSospesi");

                entity.Property(e => e.Camera).HasMaxLength(50);

                entity.Property(e => e.CapDomicilio).HasMaxLength(50);

                entity.Property(e => e.CapResidenza).HasMaxLength(50);

                entity.Property(e => e.Cellulare)
                    .HasMaxLength(50)
                    .HasColumnName("cellulare");

                entity.Property(e => e.Cittadinanza)
                    .HasMaxLength(50)
                    .HasColumnName("cittadinanza");

                entity.Property(e => e.CittàDomicilio).HasMaxLength(50);

                entity.Property(e => e.CittàResidenza).HasMaxLength(50);

                entity.Property(e => e.Codfisc)
                    .HasMaxLength(16)
                    .HasColumnName("codfisc");

                entity.Property(e => e.Cognome).HasMaxLength(50);

                entity.Property(e => e.DataInizio).HasColumnType("datetime");

                entity.Property(e => e.DataLettera).HasMaxLength(50);

                entity.Property(e => e.DatadiNascita).HasMaxLength(10);

                entity.Property(e => e.DescrizioneProfessione).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Gruppo).HasMaxLength(50);

                entity.Property(e => e.Idsocio).HasColumnName("IDSocio");

                entity.Property(e => e.IndirizzoDomicilio).HasMaxLength(50);

                entity.Property(e => e.IndirizzoResidenza).HasMaxLength(50);

                entity.Property(e => e.LuogoDiLavoro).HasMaxLength(100);

                entity.Property(e => e.LuogodiNascita).HasMaxLength(50);

                entity.Property(e => e.Nazione)
                    .HasMaxLength(50)
                    .HasColumnName("nazione");

                entity.Property(e => e.NazioneDomicilio).HasMaxLength(50);

                entity.Property(e => e.NazioneResidenza).HasMaxLength(50);

                entity.Property(e => e.Nome).HasMaxLength(50);

                entity.Property(e => e.NumeroIscrizioneFraternità).HasMaxLength(50);

                entity.Property(e => e.PartecipaRitiroData).HasColumnType("datetime");

                entity.Property(e => e.Professione).HasMaxLength(50);

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .HasColumnName("provincia");

                entity.Property(e => e.ProvinciaDomicilio).HasMaxLength(50);

                entity.Property(e => e.ProvinciaResidenza).HasMaxLength(50);

                entity.Property(e => e.RitiroPagamentoCro)
                    .HasMaxLength(50)
                    .HasColumnName("RitiroPagamentoCRO");

                entity.Property(e => e.RitiroPagamentoData).HasColumnType("datetime");

                entity.Property(e => e.RitiroPagamentoIdtransazione)
                    .HasMaxLength(50)
                    .HasColumnName("RitiroPagamentoIDTransazione");

                entity.Property(e => e.Sesso).HasMaxLength(1);

                entity.Property(e => e.Telefono1)
                    .HasMaxLength(50)
                    .HasColumnName("telefono1");

                entity.Property(e => e.Telefono2)
                    .HasMaxLength(50)
                    .HasColumnName("telefono2");

                entity.Property(e => e.TipoPagamento).HasMaxLength(50);

                entity.Property(e => e.Zona).HasMaxLength(50);
            });

            modelBuilder.Entity<AnagraficaStorico>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AnagraficaStorico");

                entity.Property(e => e.Camera).HasMaxLength(50);

                entity.Property(e => e.CapDomicilio).HasMaxLength(50);

                entity.Property(e => e.CapResidenza).HasMaxLength(50);

                entity.Property(e => e.Cellulare)
                    .HasMaxLength(50)
                    .HasColumnName("cellulare");

                entity.Property(e => e.Cittadinanza)
                    .HasMaxLength(50)
                    .HasColumnName("cittadinanza");

                entity.Property(e => e.CittàDomicilio).HasMaxLength(50);

                entity.Property(e => e.CittàResidenza).HasMaxLength(50);

                entity.Property(e => e.Codfisc)
                    .HasMaxLength(16)
                    .HasColumnName("codfisc");

                entity.Property(e => e.Cognome).HasMaxLength(50);

                entity.Property(e => e.DataInizio).HasColumnType("datetime");

                entity.Property(e => e.DataLettera).HasMaxLength(50);

                entity.Property(e => e.DatadiNascita).HasMaxLength(10);

                entity.Property(e => e.DescrizioneProfessione).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Gruppo).HasMaxLength(50);

                entity.Property(e => e.Idsocio).HasColumnName("IDSocio");

                entity.Property(e => e.IndirizzoDomicilio).HasMaxLength(50);

                entity.Property(e => e.IndirizzoResidenza).HasMaxLength(50);

                entity.Property(e => e.LuogoDiLavoro).HasMaxLength(100);

                entity.Property(e => e.LuogodiNascita).HasMaxLength(50);

                entity.Property(e => e.Nazione)
                    .HasMaxLength(50)
                    .HasColumnName("nazione");

                entity.Property(e => e.NazioneDomicilio).HasMaxLength(50);

                entity.Property(e => e.NazioneResidenza).HasMaxLength(50);

                entity.Property(e => e.Nome).HasMaxLength(50);

                entity.Property(e => e.NumeroIscrizioneFraternità).HasMaxLength(50);

                entity.Property(e => e.PartecipaRitiroData).HasColumnType("datetime");

                entity.Property(e => e.Professione).HasMaxLength(50);

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .HasColumnName("provincia");

                entity.Property(e => e.ProvinciaDomicilio).HasMaxLength(50);

                entity.Property(e => e.ProvinciaResidenza).HasMaxLength(50);

                entity.Property(e => e.RitiroPagamentoCro)
                    .HasMaxLength(50)
                    .HasColumnName("RitiroPagamentoCRO");

                entity.Property(e => e.RitiroPagamentoData).HasColumnType("datetime");

                entity.Property(e => e.RitiroPagamentoIdtransazione)
                    .HasMaxLength(50)
                    .HasColumnName("RitiroPagamentoIDTransazione");

                entity.Property(e => e.Sesso).HasMaxLength(1);

                entity.Property(e => e.Telefono1)
                    .HasMaxLength(50)
                    .HasColumnName("telefono1");

                entity.Property(e => e.Telefono2)
                    .HasMaxLength(50)
                    .HasColumnName("telefono2");

                entity.Property(e => e.TipoPagamento).HasMaxLength(50);

                entity.Property(e => e.Zona).HasMaxLength(50);
            });

            modelBuilder.Entity<Avvisi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Avvisi");

                entity.Property(e => e.Categoria).HasMaxLength(50);

                entity.Property(e => e.Contenuto).HasMaxLength(4000);

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Idavviso).HasColumnName("IDAvviso");

                entity.Property(e => e.Link).HasColumnType("ntext");

                entity.Property(e => e.Titolo).HasMaxLength(255);

                entity.Property(e => e.Zona).HasMaxLength(50);
            });

            modelBuilder.Entity<CapiGruppetto>(entity =>
            {
                entity.HasKey(e => e.IdcapoGruppetto);

                entity.ToTable("CapiGruppetto");

                entity.Property(e => e.IdcapoGruppetto)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCapoGruppetto");

                entity.Property(e => e.DataInizio).HasColumnType("date");

                entity.Property(e => e.Idanagrafica).HasColumnName("IDAnagrafica");

                entity.Property(e => e.Idgruppetto).HasColumnName("IDGruppetto");

                entity.Property(e => e.Scadenza).HasColumnType("date");
            });

            modelBuilder.Entity<FondoComune>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FondoComune");

                entity.Property(e => e.DataPagamento01).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento02).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento03).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento04).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento05).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento06).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento07).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento08).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento09).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento10).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento11).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento12).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idsocio).HasColumnName("IDsocio");

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.TipoPagamento01).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento02).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento03).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento04).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento05).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento06).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento07).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento08).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento09).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento10).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento11).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento12).HasMaxLength(20);

                entity.Property(e => e.Valuta01).HasMaxLength(3);

                entity.Property(e => e.Valuta02).HasMaxLength(3);

                entity.Property(e => e.Valuta03).HasMaxLength(3);

                entity.Property(e => e.Valuta04).HasMaxLength(3);

                entity.Property(e => e.Valuta05).HasMaxLength(3);

                entity.Property(e => e.Valuta06).HasMaxLength(3);

                entity.Property(e => e.Valuta07).HasMaxLength(3);

                entity.Property(e => e.Valuta08).HasMaxLength(3);

                entity.Property(e => e.Valuta09).HasMaxLength(3);

                entity.Property(e => e.Valuta10).HasMaxLength(3);

                entity.Property(e => e.Valuta11).HasMaxLength(3);

                entity.Property(e => e.Valuta12).HasMaxLength(3);
            });

            modelBuilder.Entity<FondoComuneSospesi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FondoComuneSospesi");

                entity.Property(e => e.DataPagamento01).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento02).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento03).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento04).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento05).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento06).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento07).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento08).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento09).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento10).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento11).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento12).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idsocio).HasColumnName("IDsocio");

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.TipoPagamento01).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento02).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento03).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento04).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento05).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento06).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento07).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento08).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento09).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento10).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento11).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento12).HasMaxLength(20);

                entity.Property(e => e.Valuta01).HasMaxLength(3);

                entity.Property(e => e.Valuta02).HasMaxLength(3);

                entity.Property(e => e.Valuta03).HasMaxLength(3);

                entity.Property(e => e.Valuta04).HasMaxLength(3);

                entity.Property(e => e.Valuta05).HasMaxLength(3);

                entity.Property(e => e.Valuta06).HasMaxLength(3);

                entity.Property(e => e.Valuta07).HasMaxLength(3);

                entity.Property(e => e.Valuta08).HasMaxLength(3);

                entity.Property(e => e.Valuta09).HasMaxLength(3);

                entity.Property(e => e.Valuta10).HasMaxLength(3);

                entity.Property(e => e.Valuta11).HasMaxLength(3);

                entity.Property(e => e.Valuta12).HasMaxLength(3);
            });

            modelBuilder.Entity<FondoComuneStorico>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FondoComuneStorico");

                entity.Property(e => e.DataPagamento01).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento02).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento03).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento04).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento05).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento06).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento07).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento08).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento09).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento10).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento11).HasColumnType("datetime");

                entity.Property(e => e.DataPagamento12).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idsocio).HasColumnName("IDsocio");

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.TipoPagamento01).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento02).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento03).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento04).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento05).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento06).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento07).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento08).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento09).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento10).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento11).HasMaxLength(20);

                entity.Property(e => e.TipoPagamento12).HasMaxLength(20);

                entity.Property(e => e.Valuta01).HasMaxLength(3);

                entity.Property(e => e.Valuta02).HasMaxLength(3);

                entity.Property(e => e.Valuta03).HasMaxLength(3);

                entity.Property(e => e.Valuta04).HasMaxLength(3);

                entity.Property(e => e.Valuta05).HasMaxLength(3);

                entity.Property(e => e.Valuta06).HasMaxLength(3);

                entity.Property(e => e.Valuta07).HasMaxLength(3);

                entity.Property(e => e.Valuta08).HasMaxLength(3);

                entity.Property(e => e.Valuta09).HasMaxLength(3);

                entity.Property(e => e.Valuta10).HasMaxLength(3);

                entity.Property(e => e.Valuta11).HasMaxLength(3);

                entity.Property(e => e.Valuta12).HasMaxLength(3);
            });

            modelBuilder.Entity<Help>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Help");

                entity.Property(e => e.NomeCampo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NomePagina)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TestoAiuto).HasColumnType("ntext");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Menu");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GruppoAccesso).HasMaxLength(50);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Link).HasMaxLength(255);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RegistroAccessi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RegistroAccessi");

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ip)
                    .HasMaxLength(255)
                    .HasColumnName("IP");

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.Pagina).HasMaxLength(255);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<SpedizioneEmailSito>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SpedizioneEmailSito");

                entity.Property(e => e.Camera).HasMaxLength(50);

                entity.Property(e => e.CapDomicilio).HasMaxLength(50);

                entity.Property(e => e.CapResidenza).HasMaxLength(50);

                entity.Property(e => e.Cellulare)
                    .HasMaxLength(50)
                    .HasColumnName("cellulare");

                entity.Property(e => e.Cittadinanza)
                    .HasMaxLength(50)
                    .HasColumnName("cittadinanza");

                entity.Property(e => e.CittàDomicilio).HasMaxLength(50);

                entity.Property(e => e.CittàResidenza).HasMaxLength(50);

                entity.Property(e => e.Codfisc)
                    .HasMaxLength(16)
                    .HasColumnName("codfisc");

                entity.Property(e => e.Cognome).HasMaxLength(50);

                entity.Property(e => e.DataInizio).HasColumnType("datetime");

                entity.Property(e => e.DatadiNascita).HasMaxLength(10);

                entity.Property(e => e.DescrizioneProfessione).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Expr2).HasMaxLength(50);

                entity.Property(e => e.Gruppo).HasMaxLength(50);

                entity.Property(e => e.Idsocio).HasColumnName("IDSocio");

                entity.Property(e => e.IndirizzoDomicilio).HasMaxLength(50);

                entity.Property(e => e.IndirizzoResidenza).HasMaxLength(50);

                entity.Property(e => e.LuogoDiLavoro).HasMaxLength(100);

                entity.Property(e => e.LuogodiNascita).HasMaxLength(50);

                entity.Property(e => e.Nazione)
                    .HasMaxLength(50)
                    .HasColumnName("nazione");

                entity.Property(e => e.NazioneDomicilio).HasMaxLength(50);

                entity.Property(e => e.NazioneResidenza).HasMaxLength(50);

                entity.Property(e => e.Nome).HasMaxLength(50);

                entity.Property(e => e.NumeroIscrizioneFraternità).HasMaxLength(50);

                entity.Property(e => e.PartecipaRitiroData).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Professione).HasMaxLength(50);

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .HasColumnName("provincia");

                entity.Property(e => e.ProvinciaDomicilio).HasMaxLength(50);

                entity.Property(e => e.ProvinciaResidenza).HasMaxLength(50);

                entity.Property(e => e.RitiroPagamentoCro)
                    .HasMaxLength(50)
                    .HasColumnName("RitiroPagamentoCRO");

                entity.Property(e => e.RitiroPagamentoData).HasColumnType("datetime");

                entity.Property(e => e.RitiroPagamentoIdtransazione)
                    .HasMaxLength(50)
                    .HasColumnName("RitiroPagamentoIDTransazione");

                entity.Property(e => e.Sesso).HasMaxLength(1);

                entity.Property(e => e.Telefono1)
                    .HasMaxLength(50)
                    .HasColumnName("telefono1");

                entity.Property(e => e.Telefono2)
                    .HasMaxLength(50)
                    .HasColumnName("telefono2");

                entity.Property(e => e.TipoPagamento).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.Property(e => e.Zona).HasMaxLength(50);
            });

            modelBuilder.Entity<TabellaCittum>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Cap).HasMaxLength(10);

                entity.Property(e => e.Citta).HasMaxLength(50);

                entity.Property(e => e.Idcitta).HasColumnName("IDCitta");

                entity.Property(e => e.Nazione).HasMaxLength(3);

                entity.Property(e => e.PrefissoTelefonico).HasMaxLength(10);

                entity.Property(e => e.Provincia).HasMaxLength(4);

                entity.Property(e => e.Regione).HasMaxLength(3);
            });

            modelBuilder.Entity<TabellaCodiciRuolo>(entity =>
            {
                entity.HasKey(e => e.CodiceRuolo)
                    .HasName("PK_TabellaCodiciIncarico");

                entity.ToTable("TabellaCodiciRuolo");

                entity.Property(e => e.CodiceRuolo).HasMaxLength(50);

                entity.Property(e => e.Descrizione).HasMaxLength(50);
            });

            modelBuilder.Entity<TabellaGruppetti>(entity =>
            {
                entity.ToTable("TabellaGruppetti");

                entity.HasIndex(e => e.Gruppetto, "IX_Table_Gruppetto");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gruppetto)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TabellaGruppi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TabellaGruppi");

                entity.Property(e => e.Gruppo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("gruppo");
            });

            modelBuilder.Entity<TabellaGruppiAccesso>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TabellaGruppiAccesso");

                entity.Property(e => e.Descrizione).HasMaxLength(50);
            });

            modelBuilder.Entity<TabellaLingue>(entity =>
            {
                entity.HasKey(e => e.Lingua);

                entity.ToTable("TabellaLingue");

                entity.Property(e => e.Lingua).HasMaxLength(50);
            });

            modelBuilder.Entity<TabellaNazioni>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TabellaNazioni");

                entity.Property(e => e.CodiceValuta).HasMaxLength(10);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nazione).HasMaxLength(50);

                entity.Property(e => e.NazioneEsp)
                    .HasMaxLength(50)
                    .HasColumnName("NazioneESP");

                entity.Property(e => e.NazionePor)
                    .HasMaxLength(50)
                    .HasColumnName("NazionePOR");

                entity.Property(e => e.NazioneUk)
                    .HasMaxLength(50)
                    .HasColumnName("NazioneUK");

                entity.Property(e => e.PrefissoInternazionale).HasMaxLength(10);

                entity.Property(e => e.SiglaNazione)
                    .IsRequired()
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<TabellaParametri>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TabellaParametri");

                entity.Property(e => e.Contenuto).HasMaxLength(255);

                entity.Property(e => e.ContenutoHtml)
                    .HasColumnType("ntext")
                    .HasColumnName("ContenutoHTML");

                entity.Property(e => e.NomeParametro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TabellaProfessioni>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TabellaProfessioni");

                entity.Property(e => e.Professione)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TabellaRegioni>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TabellaRegioni");

                entity.Property(e => e.CodiceNazione)
                    .HasMaxLength(3)
                    .HasColumnName("codice nazione");

                entity.Property(e => e.CodiceRegione)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("codice regione");

                entity.Property(e => e.CodiceRegionePastorale)
                    .HasMaxLength(3)
                    .HasColumnName("codice regione pastorale");

                entity.Property(e => e.Regione)
                    .HasMaxLength(50)
                    .HasColumnName("regione");
            });

            modelBuilder.Entity<TabellaValute>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TabellaValute");

                entity.Property(e => e.CodiceValuta)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.DescrizioneValuta).HasMaxLength(50);
            });

            modelBuilder.Entity<TabellaZone>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TabellaZone");

                entity.Property(e => e.Zona)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Traduzioni>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Traduzioni");

                entity.Property(e => e.Chiave).HasMaxLength(255);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Lingua)
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.Pagina).HasMaxLength(50);

                entity.Property(e => e.Traduzione).HasMaxLength(4000);
            });

            modelBuilder.Entity<Utenti>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Utenti");

                entity.Property(e => e.DataultimaModificaPassword).HasColumnType("date");

                entity.Property(e => e.Gruppo).HasMaxLength(1);

                entity.Property(e => e.Idanagrafica).HasColumnName("IDAnagrafica");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.HasKey(e => e.Idvisitor);

                entity.ToTable("Visitor");

                entity.Property(e => e.Idvisitor).HasColumnName("IDVisitor");

                entity.Property(e => e.DataInizio).HasColumnType("date");

                entity.Property(e => e.Idanagrafica).HasColumnName("IDAnagrafica");

                entity.Property(e => e.Scadenza).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
