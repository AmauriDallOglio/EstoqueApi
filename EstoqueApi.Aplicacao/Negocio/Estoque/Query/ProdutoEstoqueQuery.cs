using EstoqueApi.Dominio.Entidade;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
    public class ProdutoEstoqueQuery : IRequest<Estoque>
    {
        public int IdProduto { get; set; }
    }
}
