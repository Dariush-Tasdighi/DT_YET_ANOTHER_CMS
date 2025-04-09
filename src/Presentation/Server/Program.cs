using Persistence;
using Services.Features.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args: args);

builder.Services
	.AddRazorPages()
	//.AddRazorRuntimeCompilation()
	;

// **************************************************
var connectionString =
	"Server=.;User ID=sa;Password=1234512345;Database=DT_CMS;MultipleActiveResultSets=true;TrustServerCertificate=True;";

builder.Services
	.AddDbContext<ApplicationDbContext>(optionsAction: options =>
	{
		//options.UseLazyLoadingProxies();
		options.UseSqlServer(connectionString: connectionString);
	});
// **************************************************

// **************************************************
builder.Services
	.AddScoped<ApplicationSettingService>();
// **************************************************

var app = builder.Build();

if (app.Environment.IsDevelopment() == false)
{
	app.UseExceptionHandler(errorHandlingPath: "/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages()
	.WithStaticAssets();

app.Run();
