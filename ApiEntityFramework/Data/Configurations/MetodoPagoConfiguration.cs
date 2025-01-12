﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using ApiEntityFramework.Data;
using ApiEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace ApiEntityFramework.Data.Configurations
{
    public partial class MetodoPagoConfiguration : IEntityTypeConfiguration<MetodoPago>
    {
        public void Configure(EntityTypeBuilder<MetodoPago> entity)
        {
            entity.ToTable("metodoPago");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("nombre");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<MetodoPago> entity);
    }
}
