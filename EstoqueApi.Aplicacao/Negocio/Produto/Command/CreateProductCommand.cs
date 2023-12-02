using FluentValidation.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace EstoqueApi.Aplicacao.Negocio
{
    public class CreateProductCommand : IRequest<bool>
	{
		private ValidationResult validation;
		public CreateProductCommand(string descricao, int[] idCategorias)
		{
			Descricao = descricao;
			IdCategorias = idCategorias;

			var validator = new CreateProductCommandValidator();
			validation = validator.Validate(this);
		}
		public string Descricao { get; set; }
		public int[] IdCategorias { get; set; }
		[JsonIgnore]
		public ValidationResult Validation => validation;
	}
}
