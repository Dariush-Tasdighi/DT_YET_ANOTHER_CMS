using Persistence;
using Domain.Features.Cms;
using Domain.Features.Identity;

using var applicationDbContext = new ApplicationDbContext();

// **************************************************
var userRole = new Role(name: "User", code: 10, title: "کاربر");
applicationDbContext.Add(entity: userRole);

var administratorRole = new Role(name: "Administrator", code: 20, title: "مدیر");
applicationDbContext.Add(entity: administratorRole);

await applicationDbContext.SaveChangesAsync();
// **************************************************

// **************************************************
var user = new User(roleId: userRole.Id, username: "alirezaalavi", password: "1234512345", emailAddress: "AliRezaAlavi@Gmail.com");
applicationDbContext.Add(entity: user);

var administrator = new User(roleId: administratorRole.Id, username: "dariush", password: "1234512345", emailAddress: "DariushT@Gmail.com");
applicationDbContext.Add(entity: administrator);

await applicationDbContext.SaveChangesAsync();
// **************************************************

// **************************************************
var subMenuItem1 = new MenuItem(title: "منوی اصلی ۱")
{
	Ordering = 90,
	IsVisible = false,
	IsDisabled = false,
	NavigationUrl = "/site_1",
	OpenUrlInNewWindow = false,
};
applicationDbContext.Add(entity: subMenuItem1);

var subMenuItem2 = new MenuItem(title: "منوی اصلی 2")
{
	Ordering = 80,
	IsVisible = false,
	IsDisabled = true,
	NavigationUrl = "/site_2",
	OpenUrlInNewWindow = false,
};
applicationDbContext.Add(entity: subMenuItem2);

var subMenuItem3 = new MenuItem(title: "منوی اصلی 3")
{
	Ordering = 70,
	IsVisible = true,
	IsDisabled = true,
	NavigationUrl = "/site_3",
	OpenUrlInNewWindow = false,
};
applicationDbContext.Add(entity: subMenuItem3);

var subMenuItem4 = new MenuItem(title: "منوی اصلی 4")
{
	Ordering = 60,
	IsVisible = true,
	IsDisabled = false,
	NavigationUrl = "/site_4",
	OpenUrlInNewWindow = true,
};
applicationDbContext.Add(entity: subMenuItem4);

var subMenuItem5 = new MenuItem(title: "منوی اصلی 5")
{
	Ordering = 50,
	IsVisible = true,
	IsDisabled = false,
	NavigationUrl = "/site_5",
	OpenUrlInNewWindow = false,
};
applicationDbContext.Add(entity: subMenuItem5);



var menuItem1 = new MenuItem(title: "گزینه 1")
{
	Ordering = 10,
	IsVisible = false,
	IsDisabled = false,
	ParentId = subMenuItem5.Id,
	NavigationUrl = "/site_5_1",
};
applicationDbContext.Add(entity: menuItem1);

var menuItem2 = new MenuItem(title: "گزینه 2")
{
	Ordering = 20,
	IsVisible = false,
	IsDisabled = true,
	ParentId = subMenuItem5.Id,
	NavigationUrl = "/site_5_2",
};
applicationDbContext.Add(entity: menuItem2);

var menuItem3 = new MenuItem(title: "گزینه 3")
{
	Ordering = 30,
	IsVisible = true,
	IsDisabled = false,
	ParentId = subMenuItem5.Id,
	NavigationUrl = "/site_5_3",
};
applicationDbContext.Add(entity: menuItem3);

var menuItem4 = new MenuItem(title: "گزینه 4")
{
	Ordering = 40,
	IsVisible = true,
	IsDisabled = true,
	ParentId = subMenuItem5.Id,
	NavigationUrl = "/site_5_4",
};
applicationDbContext.Add(entity: menuItem4);

var menuItem5 = new MenuItem(title: "   -    ")
{
	Ordering = 50,
	IsVisible = true,
	IsDisabled = false,
	ParentId = subMenuItem5.Id,
	NavigationUrl = "/site_5_5",
};
applicationDbContext.Add(entity: menuItem5);

var menuItem6 = new MenuItem(title: "گزینه 6")
{
	Ordering = 60,
	IsVisible = true,
	IsDisabled = false,
	ParentId = subMenuItem5.Id,
	NavigationUrl = "/site_5_6",
};
applicationDbContext.Add(entity: menuItem6);

await applicationDbContext.SaveChangesAsync();
// **************************************************
