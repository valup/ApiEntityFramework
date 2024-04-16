﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using ApiEntityFramework.Data;
using ApiEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace ApiEntityFramework.Data.Configurations
{
    public partial class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> entity)
        {
            entity.ToTable("producto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fecha)
            .HasColumnType("datetime")
            .HasColumnName("fecha");
            entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("nombre");
            entity.Property(e => e.Precio)
            .HasColumnType("decimal(18, 2)")
            .HasColumnName("precio");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Producto> entity);
    }
}
