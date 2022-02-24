namespace API_Desafio_Angular.Model
{
    public class ItemPedidoGetModel
    {
        public int IdItemPedido{ get; set; }
        public int QuantidadeProduto { get; set; }
        public ProdutoGetModel Produto { get; set; }
    }
}