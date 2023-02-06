
namespace DesafioAutoglass.Domain.Entities
{
    public class Produto : EntityBase
    {
        public Produto(Guid id) : base(id) { }

        public Produto(string codigo, string descricao)
        {
            this.Codigo = codigo;
            this.Descricao = descricao;
        }

        public Produto(Guid id, string codigo, string descricao) : this(codigo, descricao)
        {
            this.Id = id;
        }

        // Empty constructor for EF
        protected Produto() { }

        public string Codigo { get; set; } = "";
        public string Descricao { get; set; } = "";
        public bool Situacao { get; set; } = true;
        public DateTime? DataFabricacao { get; set; } = null;
        public DateTime? DataValidade { get; set; } = null;
        public string CodigoFornecedor { get; set; } = "";
        public string DescricaoFornecedor { get; set; } = "";
        public string CNPJFornecedor { get; set; } = "";
    }
}
