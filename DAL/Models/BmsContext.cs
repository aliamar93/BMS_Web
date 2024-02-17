using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class BmsContext : DbContext
{
    public BmsContext()
    {
    }

    public BmsContext(DbContextOptions<BmsContext> options)
        : base(options)
    {
    }

    //public virtual void Update(T entity, params Expression<Func<T, object>>[] updatedProperties)
    //{
    //    //dbEntityEntry.State = EntityState.Modified; --- I cannot do this.

    //    //Ensure only modified fields are updated.
    //    var dbEntityEntry = DbContext.Entry(entity);
    //    if (updatedProperties.Any())
    //    {
    //        //update explicitly mentioned properties
    //        foreach (var property in updatedProperties)
    //        {
    //            dbEntityEntry.Property(property).IsModified = true;
    //        }
    //    }
    //    else
    //    {
    //        //no items mentioned, so find out the updated entries
    //        foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
    //        {
    //            var original = dbEntityEntry.OriginalValues.GetValue<object>(property);
    //            var current = dbEntityEntry.CurrentValues.GetValue<object>(property);
    //            if (original != null && !original.Equals(current))
    //                dbEntityEntry.Property(property).IsModified = true;
    //        }
    //    }
    //}
    public virtual DbSet<AmEntryLog> AmEntryLogs { get; set; }

    public virtual DbSet<AmListPermission> AmListPermissions { get; set; }

    public virtual DbSet<AmPermission> AmPermissions { get; set; }

    public virtual DbSet<AmRole> AmRoles { get; set; }

    public virtual DbSet<AmStamp> AmStamps { get; set; }

    public virtual DbSet<AmStudent> AmStudents { get; set; }

    public virtual DbSet<AmUser> AmUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AMARALI\\SQLEXPRESS;Database=BMS;Trusted_Connection=True;User ID=sa;Password=inter123net;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<AmEntryLog>(entity =>
        {
            entity.ToTable("AM_EntryLog");

            entity.Property(e => e.SUId).HasColumnName("S_U_ID");
            entity.Property(e => e.TimeIn).HasColumnType("datetime");
            entity.Property(e => e.TimeOut).HasColumnType("datetime");
        });

        modelBuilder.Entity<AmListPermission>(entity =>
        {
            entity.ToTable("AM_ListPermission");

            entity.Property(e => e.CanDelete).HasColumnName("Can_Delete");
            entity.Property(e => e.CanInsert).HasColumnName("Can_Insert");
            entity.Property(e => e.CanRead).HasColumnName("Can_Read");
            entity.Property(e => e.CanUpdate).HasColumnName("Can_Update");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AmPermission>(entity =>
        {
            entity.ToTable("AM_Permission");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PagePermission).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AmRole>(entity =>
        {
            entity.ToTable("AM_Role");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RoleName).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AmStamp>(entity =>
        {
            entity.ToTable("AM_Stamp");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.StampTime).HasColumnType("datetime");
            entity.Property(e => e.StdUId).HasColumnName("Std_U_ID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AmStudent>(entity =>
        {
            entity.ToTable("AM_Student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.StdEmail).HasMaxLength(200);
            entity.Property(e => e.StdFirstName).HasMaxLength(250);
            entity.Property(e => e.StdLastName).HasMaxLength(250);
            entity.Property(e => e.StdPersonalNo).HasMaxLength(50);
            entity.Property(e => e.StdPhoneNo).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AmUser>(entity =>
        {
            entity.ToTable("AM_User");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.PhoneNo).HasMaxLength(250);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
}
