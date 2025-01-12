﻿namespace ApiEntityFramework.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }

        public required string Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Precio { get; set; }

        public string Imagen { get; set; }
    }
}
