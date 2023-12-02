using FluentValidation;

namespace EstoqueApi.Aplicacao.Negocio
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
