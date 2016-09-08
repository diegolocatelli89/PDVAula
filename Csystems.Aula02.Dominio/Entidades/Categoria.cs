using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csystems.Aula02.Dominio.Entidades
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public String Descricao { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
