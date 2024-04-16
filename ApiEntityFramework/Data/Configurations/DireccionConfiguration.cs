﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using ApiEntityFramework.Data;
using ApiEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace ApiEntityFramework.Data.Configurations
{
    public partial class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> entity)
        {
            entity.ToTable("direccion");

            entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
            entity.Property(e => e.Calle)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("calle");
            entity.Property(e => e.Ciudad)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("ciudad");
            entity.Property(e => e.CodigoPostal)
            .IsRequired()
            .HasMaxLength(10)
            .IsUnicode(false)
            .HasColumnName("codigoPostal");
            entity.Property(e => e.Estado)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("estado");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Opcional)
            .HasMaxLength(200)
            .IsUnicode(false)
            .HasColumnName("opcional");
            entity.Property(e => e.Pais)
            .IsRequired()
            .HasMaxLength(20)
            .IsUnicode(false)
            .HasColumnName("pais");
            entity.Property(e => e.Telefono)
            .IsRequired()
            .HasMaxLength(20)
            .IsUnicode(false)
            .HasColumnName("telefono");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Direccions)
            .HasForeignKey(d => d.IdUsuario)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_direccion_usuario");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Direccion> entity);
    }
}
