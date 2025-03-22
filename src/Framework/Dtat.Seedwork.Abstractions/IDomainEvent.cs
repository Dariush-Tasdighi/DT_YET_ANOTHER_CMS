using System;
using Mediator;

namespace Dtat.Seedwork.Abstractions;

public interface IDomainEvent : INotification
{
	Guid Id { get; }

	DateTimeOffset OccurredOn { get; }
}
