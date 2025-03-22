using System;
using Dtat.Seedwork.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Seedwork;

public abstract class Entity : object, IEntity, IEntityHasInsertDateTime
{
	protected Entity() : base()
	{
	}

	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	public Guid Id { get; init; } = Guid.NewGuid();

	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	public DateTimeOffset InsertDateTime { get; init; } = DateTimeOffset.Now;
}
