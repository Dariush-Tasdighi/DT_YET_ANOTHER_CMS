using System;

namespace Dtat.Seedwork.Abstractions;

public interface IEntityHasIsDeleted
{
	bool IsDeleted { get; }

	Guid? RemoverUserId { get; }

	DateTimeOffset? DeleteDateTime { get; }

	void Delete(Guid removerUserId);

	void Undelete(Guid removerUserId);
}
