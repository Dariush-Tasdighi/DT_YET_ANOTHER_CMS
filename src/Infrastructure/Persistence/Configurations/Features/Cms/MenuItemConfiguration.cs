using Domain.Features.Cms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations.Features.Cms;

internal sealed class MenuItemConfiguration : object, IEntityTypeConfiguration<MenuItem>
{
	public void Configure(EntityTypeBuilder<MenuItem> builder)
	{
		// **************************************************
		builder
			.HasKey(current => current.Id)
			.IsClustered(clustered: false)
			;
		// **************************************************

		// **************************************************
		builder
			.HasMany(current => current.Children)
			.WithOne(other => other.Parent)
			.IsRequired(required: false)
			.HasForeignKey(other => other.ParentId)
			.OnDelete(deleteBehavior: DeleteBehavior.NoAction)
			;
		// **************************************************
	}
}
