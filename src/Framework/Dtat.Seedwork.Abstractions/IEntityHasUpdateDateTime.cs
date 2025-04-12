using System;

namespace Dtat.Seedwork.Abstractions;

public interface IEntityHasUpdateDateTime
{
	DateTimeOffset UpdateDateTime { get; }

	//void SetUpdateDateTime();
}
