using System;
using System.Collections.Generic;
using System.Text;

namespace fp_stack.core.Models
{
    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Link { get; set; }
        public Autor Autor { get; set; }

    }
}
