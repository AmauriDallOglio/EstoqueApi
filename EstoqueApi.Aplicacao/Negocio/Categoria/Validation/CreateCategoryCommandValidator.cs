using EstoqueApi.Aplicacao.Negocio.Categoria.Command;
using FluentValidation;

namespace EstoqueApi.Aplicacao.Negocio.Categoria.Validation
{
	public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
	{
		public CreateCategoryCommandValidator()
		{
			RuleFor(x => x.Descricao)
				.NotNull()
				.NotEmpty()
				.MaximumLength(50);
		}
	}
}
