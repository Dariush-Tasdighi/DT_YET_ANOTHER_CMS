using System;
using Domain.Seedwork;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dtat.Seedwork.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Features.Cms;

public class MenuItem(string title) : Entity,
	IEntityHasOrdering,
	IEntityHasUpdateDateTime
{
	public Guid? ParentId { get; set; }

	public virtual MenuItem? Parent { get; set; }

	public bool IsVisible { get; set; }

	public bool IsEnabled { get; set; }

	// TODO
	public long Ordering { get; set; } = 10_000;

	[Required(AllowEmptyStrings = false)]
	[MaxLength(length: 100)]
	public string Title { get; set; } = title;

	public string? Url { get; set; }

	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	public DateTimeOffset UpdateDateTime { get; set; }

	public virtual IList<MenuItem> Children { get; } = [];
}
