using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Alvin_P2_API.Entidades
{
    public class TiposTareas
    {
        [Key]
        public int TareaId { get; set; }
        public string Descripcion { get; set; }
    }
}
