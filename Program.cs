var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidatorsFromAssemblyContaining<VaccinValidator>(); //validator toevoegen altijd op de 2de regel
//DTOs 
//services
builder.Services.AddTransient<IVaccinationService, VaccinationService>();
//repos
builder.Services.AddTransient<IVaccinationRegistrationRepository, VaccinationRegistrationRepository>();
builder.Services.AddTransient<IVaccinTypeRepository, VaccinTypeRepository>();
builder.Services.AddTransient<IVaccinationLocationRepository, VaccinationLocationRepository>();
//automapper
builder.Services.AddAutoMapper(typeof(Program));
//app
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//get locations 
app.MapGet("/locations", (IVaccinationService vaccinationService) =>
{
    return Results.Ok(vaccinationService.GetLocations());
});
//retrieve the vaccine types (/vaccines)
app.MapGet("/types", (IVaccinationService vaccinationService) =>
{
    return Results.Ok(vaccinationService.GetVaccins());
});

//retrieve all registrations (/registrations)
// app.MapGet("/registrations", (IVaccinationService vaccinationService) =>
// {
//     return Results.Ok(vaccinationService.GetRegistrations());
// });

//autmapper
app.MapGet("/registrations", (IMapper mapper, IVaccinationService vaccinationService) =>
{
    var mapped = mapper.Map<List<VaccinRegistrationDTO>>(vaccinationService.GetRegistrations(), opts =>
    {
        opts.Items["locations"] = vaccinationService.GetLocations();
        opts.Items["vaccins"] = vaccinationService.GetVaccins();
    });
    return Results.Ok(mapped);
});
//add a new registration (/registration
//zonder validator
app.MapPost("/registrations", (IVaccinationService vaccinationService, VaccinRegistration registration) =>
{
    return Results.Ok(vaccinationService.AddRegistration(registration));
});
//met validator
app.MapPost("/registrations", (IVaccinationService vaccinationService, VaccinRegistration registration) =>
{
    var validator = new VaccinValidator();
    var result = validator.Validate(registration);
    if (result.IsValid)
    {
        return Results.Ok(vaccinationService.AddRegistration(registration));
    }
    else
    {
        return Results.BadRequest(result.Errors);
    }
});



app.Run("http://localhost:5000");

// app.UseExceptionHandler(c => c.Run(async context =>
// {
//     var exception = context.Features
//         .Get<IExceptionHandlerFeature>()
//         ?.Error;
//     if (exception is not null)
//     {
//         var response = new { error = exception.Message };
//         context.Response.StatusCode = 400;

//         await context.Response.WriteAsJsonAsync(response);
//     }
// }));