using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Activities
{
    public class Details //provide the details about some activity
    {
        public class Query: IRequest<Activity>
        {
            public Guid Id {get; set;}
        }
        public class Handler: IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Activity> Handle (Query request, CancellationToken token)
            {
                return await _context.Activities.FindAsync(request.Id);
            }
        }
    }
}