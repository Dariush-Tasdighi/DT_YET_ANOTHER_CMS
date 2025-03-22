using System;

namespace Dtat.Seedwork.Abstractions;

public interface IEntityHasCreatorUserId : IEntityHasInsertDateTime
{
	Guid CreatorUserId { get; }

	void Create(Guid creatorUserId);
}
