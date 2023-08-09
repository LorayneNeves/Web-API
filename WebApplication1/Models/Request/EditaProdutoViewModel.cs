namespace WebApplication1.Models.Request
{
    public class EditaProdutoViewModel
    {
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; }
    }
}
