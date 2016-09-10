using Csystems.Aula02.Dominio.Entidades;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Csystems.Aula02.Web.Views.ViewModels
{
    public class ProdutoViewModel
    {

        public int ProdutoId { get; set; }
        [Display(Name = "Produto")]
        public string Descricao { get; set; }
        public int CategoriaId { get; set; }
        [Display(Name = "Categoria")]
        public Categoria Categoria { get; set; }
    }
}