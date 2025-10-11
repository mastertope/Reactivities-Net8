using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Activities.Commands
{
    public class CreateActivity
    {
        public class Command : IRequest<Result<Unit>>
        {
            public required Activity Activity { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
        }

        public class Handler(AppDbContext context) : IRequestHandler<Command, Result<Unit>>
        {
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                context.Activities.Add(request.Activity);

                var result = await context.SaveChangesAsync(cancellationToken) > 0;

                return !result ? Result<Unit>.Failure("Failed to create the activity") : Result<Unit>.Success(Unit.Value);
            }
        }
    }
}