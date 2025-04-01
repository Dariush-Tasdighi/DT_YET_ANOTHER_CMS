using Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
	.AddRazorPages()
	//.AddRazorRuntimeCompilation()
	;

// **************************************************
builder.Services
	.AddDbContext<ApplicationDbContext>(optionsAction: options =>
	{
		// using Microsoft.EntityFrameworkCore;
		//options.UseLazyLoadingProxies();

		options.UseSqlServer(connectionString: "Server=.;User ID=sa;Password=1234512345;Database=DT_CMS;MultipleActiveResultSets=true;TrustServerCertificate=True;");
	});
// **************************************************

// **************************************************
builder.Services
	.AddScoped<Services.Features.Common.ApplicationSettingService>();
// **************************************************

var app = builder.Build();

if (app.Environment.IsDevelopment() == false)
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages()
	.WithStaticAssets();

app.Run();
