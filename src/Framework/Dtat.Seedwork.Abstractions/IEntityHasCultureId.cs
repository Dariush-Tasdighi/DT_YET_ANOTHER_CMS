using System;

namespace Dtat.Seedwork.Abstractions;

public interface IEntityHasCultureId
{
	Guid CultureId { get; }
}
