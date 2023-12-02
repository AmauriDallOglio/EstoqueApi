using MediatR;

namespace EstoqueApi.Aplicacao.Negocio
{
	public class CreateCategoryCommand : IRequest<bool>
	{
		public string Descricao { get; set; }

		//[JsonIgnore]
		//public ValidationResult Validation { get; }
		//public CreateCategoryCommand(string descricao)
		//{
		//	Descricao = descricao;
		//	var validator = new CreateCategoryCommandValidator();
		//	Validation = validator.Validate(this).Errors;
		//}

	}
}
