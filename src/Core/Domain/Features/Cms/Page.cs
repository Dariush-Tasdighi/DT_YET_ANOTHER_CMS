using Dtat;
using System;
using Domain.Seedwork;
using Dtat.Seedwork.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Features.Cms;

public class Page(string name, string title) : Entity,
	IEntityHasIsActive,
	IEntityHasUpdateDateTime
{
	public bool IsActive { get; set; }

	[Required(AllowEmptyStrings = false)]
	[MaxLength(length: Constant.MaxLength.Name)]
	public string Name { get; set; } = name;

	[Required(AllowEmptyStrings = false)]
	[MaxLength(length: 100)]
	public string Title { get; set; } = title;

	/// <summary>
	/// TODO
	/// </summary>
	public string? Body { get; set; }

	/// <summary>
	/// TODO
	/// </summary>
	public string? Copyright { get; set; }

	/// <summary>
	/// TODO
	/// </summary>
	public string? Author { get; set; }

	/// <summary>
	/// TODO
	/// </summary>
	public string? Keywords { get; set; }

	/// <summary>
	/// TODO
	/// </summary>
	public string? Description { get; set; }

	/// <summary>
	/// TODO
	/// </summary>
	public string? Robots { get; set; } = "index,follow";

	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	public DateTimeOffset UpdateDateTime { get; set; }
}
