using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities.Queries
{
    public class GetActivityList
    {
        public class Query : IRequest<Result<List<Activity>>> { };

        public class Handler(AppDbContext context) : IRequestHandler<Query, Result<List<Activity>>>
        {
            private readonly AppDbContext _context = context;

            public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<Activity>>.Success(await _context.Activities.ToListAsync(cancellationToken));
            }
        }
    }
}
