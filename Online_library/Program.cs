using LibraryDream.StartupExtensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting(); //Identifying action method based on route
app.UseAuthentication(); //Reading Identity cookie
app.UseAuthorization(); //Validates access permissions of the user
app.MapControllers(); //Execute the filter pipeline (action + filters)

app.Run();

//TODO implement clean architecture
//TODO implement book rating
//TODO add new ViewModels/DTO instead of getting full entity from view
//TODO add antiforgerytoken check
//TODO add Logging (Serilog)
//TODO add unit tests (Moq)
//TODO add XML comments to interfaces
//TODO add DateOnly validation to entities/models/DTO VIA FLUENT VALIDATION (https://docs.fluentvalidation.net/en/latest/aspnet.html) (https://github.com/SharpGrip/FluentValidation.AutoValidation)
//TODO implement client-side validation
//TODO fix authorization system, implement login via email, add unique email constraint
//TODO add old bookCheckouts to viewAllCheckouts page, separate actual from old checkouts
//TODO implement book quantity system, one type of book can have multiple exemplars (add quantity counter to book)
//TODO add deleteBook functional 
//TODO add updateBook functional