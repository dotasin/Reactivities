using MediatR;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await _context.Activities.ToListAsync();

                return activities;
            }

            //private readonly ILogger<List> /*_logger*/;//with cancellation token
            //public Handler(DataContext context, ILogger<List> logger)//add parameter , ILogger<List> logger
            //{
            //    _context = context;
            //    _logger = logger;
            //}
            //this method use with cancellation token
            //public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            //{
            //    try
            //    {
            //        for (int i = 0; i < 10; i++)
            //        {
            //            cancellationToken.ThrowIfCancellationRequested();
            //            await Task.Delay(1000, cancellationToken);
            //            _logger.LogInformation($"Task {i} has completed.");
            //        };
            //    }
            //    catch (Exception ex) when (ex is TaskCanceledException)
            //    {
            //        _logger.LogInformation($"Task was cancelled.");
            //    }
            //    var activities = await _context.Activities.ToListAsync(cancellationToken);

            //    return activities;
            //}
        }
    }
}