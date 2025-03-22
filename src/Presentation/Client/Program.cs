using Persistence;
using Domain.Features.Cms;
using Domain.Features.Identity;

using var applicationDbContext = new ApplicationDbContext();

var userRole = new Role(name: "User", code: 10, title: "کاربر");
applicationDbContext.Add(entity: userRole);

var administratorRole = new Role(name: "Administrator", code: 20, title: "مدیر");
applicationDbContext.Add(entity: administratorRole);

await applicationDbContext.SaveChangesAsync();

var administrator = new User(roleId: administratorRole.Id, username: "dariush", password: "1234512345", emailAddress: "DariushT@Gmail.com");
applicationDbContext.Add(entity: administrator);

var user = new User(roleId: userRole.Id, username: "alirezaalavi", password: "1234512345", emailAddress: "AliRezaAlavi@Gmail.com");
applicationDbContext.Add(entity: user);

await applicationDbContext.SaveChangesAsync();

var subMenuItem = new MenuItem(title: "Pages")
{
	IsVisible = true,
	IsEnabled = true,
};
applicationDbContext.Add(entity: subMenuItem);

var menuItem = new MenuItem(title: "Page 1")
{
	IsVisible = true,
	IsEnabled = true,
	ParentId = subMenuItem.Id,
};
applicationDbContext.Add(entity: menuItem);

await applicationDbContext.SaveChangesAsync();
