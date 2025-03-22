using System;

namespace Dtat.Seedwork.Abstractions;

public interface IEntityHasModifierUserId
{
	Guid? ModifierUserId { get; }

	DateTimeOffset UpdateDateTime { get; }

	void Update(Guid modifierUserId);
}
