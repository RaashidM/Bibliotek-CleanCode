using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.UpdateBook
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.BookId)
                .NotEqual(Guid.Empty).WithMessage("Book ID must not be empty.");

            RuleFor(x => x.NewTitle)
                .NotEmpty().WithMessage("Title is required.")
                .Length(2, 200).WithMessage("Title must be between 2 and 200 characters.");

            RuleFor(x => x.NewDescription)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");
        }
    }
}
