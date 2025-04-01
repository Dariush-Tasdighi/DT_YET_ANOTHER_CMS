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

	/// <summary>
	/// نمایش داده می‌شود ولی غیرفعال دیده می‌شود
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.IsDisabled))]
	public bool IsDisabled { get; set; }

	/// <summary>
	/// وضعیت
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.OpenUrlInNewWindow))]
	public bool OpenUrlInNewWindow { get; set; }

	/// <summary>
	/// TODO
	/// </summary>
	public long Ordering { get; set; } = 10_000;

	[Required(AllowEmptyStrings = false)]
	[MaxLength(length: 100)]
	public string Title { get; set; } = title;

	/// <summary>
	/// لینک مقصد
	/// </summary>
	//[System.ComponentModel.DataAnnotations.Display
	//	(ResourceType = typeof(Resources.DataDictionary),
	//	Name = nameof(Resources.DataDictionary.NavigationUrl))]
	public string? NavigationUrl { get; set; }

	/// <summary>
	/// توضیحات
	/// </summary>
	[System.ComponentModel.DataAnnotations.Display
		(ResourceType = typeof(Resources.DataDictionary),
		Name = nameof(Resources.DataDictionary.Description))]
	public string? Description { get; set; }

	[DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.None)]
	public DateTimeOffset UpdateDateTime { get; set; }

	public virtual IList<MenuItem> Children { get; } = [];
}
