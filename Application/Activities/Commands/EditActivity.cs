using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Activities.Commands
{
    public class EditActivity
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

        public class Handler(AppDbContext context, IMapper mapper) : IRequestHandler<Command, Result<Unit>>
        {
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync([request.Activity.Id], cancellationToken);

                if (activity == null) return Result<Unit>.Failure("Activity not found");

                mapper.Map(request.Activity, activity);

                var result = await context.SaveChangesAsync(cancellationToken) > 0;

                return !result ? Result<Unit>.Failure("Failed to edit the activity") : Result<Unit>.Success(Unit.Value);
            }
        }
    }
}