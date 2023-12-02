using EstoqueApi.Dominio.Entidade;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
    public class EstoqueCommand : IRequest<bool>
    {
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public UnidadeMedidaEnum UnidadeMedida { get; set; }
        public decimal PrecoUnidade { get; set; }
    }
}
