using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistance;
using MediatR;
using Domain;
using AutoMapper;

namespace Application.Activities
{
    public class Edit
    {
        public class Command: IRequest
        {
            public Activity Activity {get; set;}
        }

        public class Handler: IRequest<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

           public async Task<Unit> Handle (Command request, CancellationToken cancellationToken)
           {
                var activity = await _context.Activities.FindAsync(request.Activity.Id);
                _mapper.Map(request.Activity, activity);
                await _context.SaveChangesAsync();
                return Unit.Value;
           }
    }
    }
}