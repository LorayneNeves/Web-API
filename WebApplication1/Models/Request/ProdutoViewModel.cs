namespace WebApplication1.Models.Request
{
    public class ProdutoViewModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; }
    }
}
