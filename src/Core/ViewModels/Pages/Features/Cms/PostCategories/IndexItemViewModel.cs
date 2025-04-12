using Dtat;
using System;

namespace ViewModels.Pages.Features.Cms.PostCategories;

public class IndexItemViewModel : object
{
	public IndexItemViewModel() : base()
	{
		Name = Constant.Format.NullValue;
		Title = Constant.Format.NullValue;
	}

	public Guid Id { get; set; }

	public bool IsActive { get; set; }

	public int Ordering { get; set; }

	public string Name { get; set; }

	public string Title { get; set; }

	public bool DisplayInHomePage { get; set; }

	public int PostCount { get; set; }

	public int InactivePostCount { get; set; }

	public int Hits { get; set; }

	public DateTimeOffset InsertDateTime { get; set; }

	public DateTimeOffset UpdateDateTime { get; set; }
}
