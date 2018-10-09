using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace fp_stack.core.Models
{
    public class Pergunta
    {
        public int Id { get; set; }
        [Required]
        public string Texto { get; set; }
        public DateTime Data { get; set; }
    }
}
