namespace WebApplication1.Models.Request
{
    public class NovoProdutoViewModel
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; }
    }
}
