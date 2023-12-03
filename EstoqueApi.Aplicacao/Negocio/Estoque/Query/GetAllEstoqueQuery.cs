using EstoqueApi.Dominio.Entidade;
using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
    public class GetAllEstoqueQuery : IRequest<IEnumerable<Estoque>>
    {
        public int IdProduto { get; set; }
    }
}
