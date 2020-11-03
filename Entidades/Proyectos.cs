using Alvin_P2_API.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Alvin_P2_API.Entidades
{
    public class Proyectos
    {
        [Key]
        public int ProyectoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public int TiempoTotal { get; set; }

        [ForeignKey("ProyectoId")]
        public List<ProyectosDetalle> Detalle { get; set; } = new List<ProyectosDetalle>();
    }
    public class ProyectosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ProyectoId { get; set; }
        public int TareaId { get; set; }
        public int Tiempo { get; set; }
        public string Requerimento { get; set; }
        public ProyectosDetalle(int proyectoId, int tareaId, int tiempo, string requerimento)
        {
            Id = 0;
            ProyectoId = proyectoId;
            TareaId = tareaId;
            Tiempo = tiempo;
            Requerimento = requerimento;
        }

    }
}
