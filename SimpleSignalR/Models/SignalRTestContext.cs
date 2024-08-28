using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SimpleSignalR.Models;

public partial class SignalRTestContext : DbContext
{
    public SignalRTestContext()
    {
    }

    public SignalRTestContext(DbContextOptions<SignalRTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chat> Chats { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.User);

            entity.ToTable("chat");

            entity.Property(e => e.User)
                .HasMaxLength(50)
                .HasColumnName("user");
            entity.Property(e => e.Message)
                .HasMaxLength(250)
                .HasColumnName("message");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
