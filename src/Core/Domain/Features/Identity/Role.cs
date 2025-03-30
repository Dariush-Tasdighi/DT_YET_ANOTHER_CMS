using Dtat;
using System;
using Domain.Seedwork;
using Dtat.Seedwork.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Features.Identity;

public class Role(string name, long code, string title) : Entity,
	IEntityHasCode,
	IEntityHasIsActive,
	IEntityHasOrdering,
	IEntityHasUpdateDateTime
{
	public bool IsActive { get; set; }

	/// <summary>
	/// TODO
	/// </summary>
	public long Code { get; set; } = code;

	/// <summary>
	/// TODO
	/// </summary>
	public long Ordering { get; set; } = 10_000;

	/// <summary>
	/// TODO
	/// </summary>
	[Required(AllowEmptyStrings = false)]
	[MaxLength(length: Constant.MaxLength.Name)]
	public string Name { get; set; } = name;

	[Required(AllowEmptyStrings = false)]
	[MaxLength(length: Constant.MaxLength.Title)]
	public string Title { get; set; } = title;

	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	public DateTimeOffset UpdateDateTime { get; set; }

	public virtual IList<User> Users { get; } = [];
}
