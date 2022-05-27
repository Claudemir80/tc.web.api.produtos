using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TC.WEB.API.PRODUTO.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; }

     
        public string Estoque { get; set; }

        public string DataCadastro { get; set; }

        public int CategoriaId { get; set; }
    }
}
