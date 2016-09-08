using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Csystems.Aula02.Web.Views.ViewModels
{
    public class ClienteViewModel
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100)]
        public String Nome { get; set; }

        [Required(ErrorMessage = "O campo Fantasia é obrigatório.")]
        [StringLength(100)]
        public String Fantasia { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [StringLength(20)]
        public String CPF { get; set; }
    }
}