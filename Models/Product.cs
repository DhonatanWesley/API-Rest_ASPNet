using System.ComponentModel.DataAnnotations;

namespace testeef.Models{
    public class Product {

        [Key]
        public int      id          { get; set; }

        [Required (    ErrorMessage = "Este campo é obrigatório"                      )]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3,  ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string   title       { get; set; }

        [MaxLength(1024, ErrorMessage = "Este campo deve conter no máximo 1024 caracteres")]
        public string   description { get; set; }

        [Required(                 ErrorMessage = "Este campo é obrigatório"    )]
        [Range   (1, int.MaxValue, ErrorMessage = "O preço deve ser maior que 0")]
        public decimal  Price       { get; set; }
        public int      CategoryId  { get; set; }
        public Category Category   { get; set; }

    }
}