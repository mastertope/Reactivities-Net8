using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Details
    {
        public class Query : IRequest<Result<Activity>> { 
            public required string Id {get; set;}
        };

        public class Handler : IRequestHandler<Query, Result<Activity>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;

            }
            public async Task<Result<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Id, cancellationToken);

                return Result<Activity>.Success(activity);
            }
        }
    }
}