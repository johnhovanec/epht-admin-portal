using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace epht_admin_portal.Models;

public partial class MdhephtContext : DbContext
{
    public MdhephtContext()
    {
    }

    public MdhephtContext(DbContextOptions<MdhephtContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsthmaNcdmCensusTract> AsthmaNcdmCensusTracts { get; set; }

    public virtual DbSet<AsthmaNcdmCounty> AsthmaNcdmCounties { get; set; }

    public virtual DbSet<AsthmaNcdmStatewide> AsthmaNcdmStatewides { get; set; }

    public virtual DbSet<AsthmaSihisCounty> AsthmaSihisCounties { get; set; }

    public virtual DbSet<AsthmaSihisStatewide> AsthmaSihisStatewides { get; set; }

    public virtual DbSet<ConfigGeneral> ConfigGenerals { get; set; }

    public virtual DbSet<ConfigTopic> ConfigTopics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("epht");

        modelBuilder.Entity<AsthmaNcdmCensusTract>(entity =>
        {
            entity.HasKey(e => e.AsthmaCensusTractId).HasName("PK__Asthma_C__1FA3824AF8B9C7E3");

            entity.ToTable("Asthma_NCDM_CensusTract");

            entity.HasIndex(e => new { e.TypeId, e.TractCode, e.Year }, "NonClusteredIndex-General");

            entity.Property(e => e.AsthmaCensusTractId).HasColumnName("Asthma_CensusTract_ID");
            entity.Property(e => e.Mdcode)
                .HasMaxLength(3)
                .HasColumnName("MDCode");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 1)");
            entity.Property(e => e.TractCode).HasMaxLength(20);
            entity.Property(e => e.TypeId).HasColumnName("Type_ID");
        });

        modelBuilder.Entity<AsthmaNcdmCounty>(entity =>
        {
            entity.HasKey(e => e.AsthmaCountyId).HasName("PK__Asthma_N__D35B1C153EA0DCB8");

            entity.ToTable("Asthma_NCDM_County");

            entity.HasIndex(e => new { e.TypeId, e.GroupAgeId, e.Year, e.Mdcode }, "NonClusteredIndex-NCDM");

            entity.HasIndex(e => new { e.TypeId, e.Year, e.RaceCode }, "NonClusteredIndex-Trendline");

            entity.Property(e => e.AsthmaCountyId).HasColumnName("Asthma_County_ID");
            entity.Property(e => e.GroupAgeId).HasColumnName("GroupAge_ID");
            entity.Property(e => e.Mdcode)
                .HasMaxLength(3)
                .HasColumnName("MDCode");
            entity.Property(e => e.RaceCode).HasMaxLength(2);
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 1)");
            entity.Property(e => e.TypeId).HasColumnName("Type_ID");
        });

        modelBuilder.Entity<AsthmaNcdmStatewide>(entity =>
        {
            entity.HasKey(e => e.AsthmaStatewideId).HasName("PK__Asthma_N__0D716E655ECBF82B");

            entity.ToTable("Asthma_NCDM_Statewide");

            entity.HasIndex(e => new { e.TypeId, e.GroupAgeId, e.Year, e.Mdcode, e.RaceCode, e.GenderCode }, "NonClusteredIndex-NCDM");

            entity.HasIndex(e => new { e.TypeId, e.Year, e.RaceCode, e.GenderCode }, "NonClusteredIndex-Trendline");

            entity.Property(e => e.AsthmaStatewideId).HasColumnName("Asthma_Statewide_ID");
            entity.Property(e => e.GenderCode).HasMaxLength(2);
            entity.Property(e => e.GroupAgeId).HasColumnName("GroupAge_ID");
            entity.Property(e => e.Mdcode)
                .HasMaxLength(3)
                .HasColumnName("MDCode");
            entity.Property(e => e.RaceCode).HasMaxLength(2);
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 1)");
            entity.Property(e => e.TypeId).HasColumnName("Type_ID");
        });

        modelBuilder.Entity<AsthmaSihisCounty>(entity =>
        {
            entity.HasKey(e => e.AsthmaCountyId);

            entity.ToTable("Asthma_SIHIS_County");

            entity.HasIndex(e => new { e.Mdcode, e.Year, e.TypeId }, "NonClusteredIndex-Trendline");

            entity.Property(e => e.AsthmaCountyId).HasColumnName("Asthma_County_ID");
            entity.Property(e => e.Mdcode)
                .HasMaxLength(3)
                .HasColumnName("MDCode");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 1)");
            entity.Property(e => e.TypeId).HasColumnName("Type_ID");
        });

        modelBuilder.Entity<AsthmaSihisStatewide>(entity =>
        {
            entity.HasKey(e => e.AsthmaStatewideId).HasName("PK__Asthma_S__0D716E65C535EAD4");

            entity.ToTable("Asthma_SIHIS_Statewide");

            entity.HasIndex(e => new { e.Year, e.TypeId, e.RaceCode }, "NonClusteredIndex-Trendline");

            entity.Property(e => e.AsthmaStatewideId).HasColumnName("Asthma_Statewide_ID");
            entity.Property(e => e.Mdcode)
                .HasMaxLength(3)
                .HasColumnName("MDCode");
            entity.Property(e => e.RaceCode).HasMaxLength(2);
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 1)");
            entity.Property(e => e.TypeId).HasColumnName("Type_ID");
        });

        modelBuilder.Entity<ConfigGeneral>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Config_General");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<ConfigTopic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK_Config_Topic_Test_ID");

            entity.ToTable("Config_Topic");

            entity.Property(e => e.TopicId)
                .ValueGeneratedNever()
                .HasColumnName("topic_ID");
            entity.Property(e => e.AboutData)
                .HasMaxLength(4000)
                .HasColumnName("aboutData");
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .HasColumnName("category");
            entity.Property(e => e.CountySuppressionRulePopMin)
                .HasMaxLength(500)
                .HasColumnName("countySuppressionRulePopMin");
            entity.Property(e => e.CountySuppressionRuleRange)
                .HasMaxLength(500)
                .HasColumnName("countySuppressionRuleRange");
            entity.Property(e => e.DefaultThemePath)
                .HasMaxLength(255)
                .HasColumnName("defaultThemePath");
            entity.Property(e => e.IsVisible).HasColumnName("isVisible");
            entity.Property(e => e.OmitNcdmData).HasColumnName("omitNcdmData");
            entity.Property(e => e.Overview)
                .HasMaxLength(4000)
                .HasColumnName("overview");
            entity.Property(e => e.ParentTopic)
                .HasMaxLength(255)
                .HasColumnName("parentTopic");
            entity.Property(e => e.SubCountySuppressionRulePopMin)
                .HasMaxLength(500)
                .HasColumnName("subCountySuppressionRulePopMin");
            entity.Property(e => e.SubCountySuppressionRuleRange)
                .HasMaxLength(500)
                .HasColumnName("subCountySuppressionRuleRange");
            entity.Property(e => e.TopicTitle)
                .HasMaxLength(255)
                .HasColumnName("topicTitle");
            entity.Property(e => e.TopicUrlPath)
                .HasMaxLength(255)
                .HasColumnName("topicUrlPath");
        });
        modelBuilder.HasSequence("SDE_CONNECTION_ID_GENERATOR", "sde")
            .HasMax(2147483647L)
            .IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
