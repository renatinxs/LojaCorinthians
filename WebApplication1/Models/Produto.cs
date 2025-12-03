using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Produto
    {

        [Display(Name = "Código do Produto")]
        public int codProd { get; set; }

        [Display(Name = "Nome do Produto")]
        public string? Prodnome { get; set; }

        [Display(Name = "Descrição do Produto")]
        public string? descricao { get; set; }


        [Display(Name = "Valor do Produto")]
        public double preco { get; set; }

        [Display(Name = "Categoria do Produto")]
        public string? categoria { get; set; }



    }
}
