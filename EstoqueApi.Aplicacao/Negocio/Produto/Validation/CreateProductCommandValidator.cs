using FluentValidation;

namespace EstoqueApi.Aplicacao.Negocio
{
    internal class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
	{
		public CreateProductCommandValidator()
		{
			RuleFor(x => x.Descricao)
				.NotNull()
				.NotEmpty()
				.MaximumLength(300);


			RuleFor(x => x.IdCategorias)
				.Cascade(CascadeMode.Stop)
				.NotNull()
				.NotEmpty()
				.Must(x => x.Length > 0);
		}
	}
}
