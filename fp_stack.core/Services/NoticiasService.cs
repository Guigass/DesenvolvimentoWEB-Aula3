using fp_stack.core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace fp_stack.core.Services
{
    public class NoticiasService
    {
        public IEnumerable<Noticia> GetItens(int total)
        {
            for (int i = 0; i < total; i++)
            {
                yield return new Noticia() { Id = i + 1, Titulo = $"Noticia sobre {i}" };
            }
        }
    }
}
