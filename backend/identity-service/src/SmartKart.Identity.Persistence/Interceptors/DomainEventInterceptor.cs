using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SmartKart.Identity.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartKart.Identity.Persistence.Interceptors
{
    public sealed class DomainEventInterceptor
    : SaveChangesInterceptor
    {
        private readonly IPublisher _publisher;

        public DomainEventInterceptor(
            IPublisher publisher)
        {
            _publisher = publisher;
        }

        public override async ValueTask<int> SavedChangesAsync(
            SaveChangesCompletedEventData eventData,
            int result,
            CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;

            if (context is null)
            {
                return await base.SavedChangesAsync(
                    eventData,
                    result,
                    cancellationToken);
            }

            var domainEvents = context
                .ChangeTracker
                .Entries<AggregateRoot>()
                .Select(x => x.Entity)
                .SelectMany(x => x.DomainEvents)
                .ToList();

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(
                    domainEvent,
                    cancellationToken);
            }

            return await base.SavedChangesAsync(
                eventData,
                result,
                cancellationToken);
        }
    }
}
