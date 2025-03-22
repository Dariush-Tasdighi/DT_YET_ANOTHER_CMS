namespace Dtat.Seedwork.Abstractions;

public interface IAggregateRoot
{
	void ClearDomainEvents();

	void RaiseDomainEvent(IDomainEvent domainEvent);
}
