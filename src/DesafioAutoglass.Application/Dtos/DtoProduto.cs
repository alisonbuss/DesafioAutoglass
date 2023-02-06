
using System.ComponentModel.DataAnnotations;

namespace DesafioAutoglass.Application.Dtos
{
    public class DtoProduto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Codigo é requerido")]
        [MinLength(3)]
        [MaxLength(33)]
        public string? Codigo { get; set; }

        [Required(ErrorMessage = "Descrição é requerida")]
        [MinLength(3)]
        [MaxLength(200)]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Situação do produto é requerido")]
        public bool Situacao { get; set; }

        [Required(ErrorMessage = "Data de fabricação é requerido")]
        [DisplayFormat(DataFormatString = "yyyy/MM/dd")]
        public DateTime DataFabricacao { get; set; }

        [Required(ErrorMessage = "Data de validade é requerido")]
        [DisplayFormat(DataFormatString = "yyyy/MM/dd")]
        public DateTime DataValidade { get; set; }

        [Required(ErrorMessage = "Codigo do Fornecedor é requerido")]
        [MinLength(3)]
        [MaxLength(33)]
        public string? CodigoFornecedor { get; set; }

        [Required(ErrorMessage = "Descrição do Fornecedor é requerida")]
        [MinLength(3)]
        [MaxLength(200)]
        public string? DescricaoFornecedor { get; set; }

        [Required(ErrorMessage = "CNPJ do Fornecedor é requerido")]
        [MinLength(14)]
        [MaxLength(14)]
        [RegularExpression(
            @"^[0-9''-'\s]{1,14}$",
            ErrorMessage = "CNPJ Inválido")
        ]
        public string? CNPJFornecedor { get; set; }

    }
}
