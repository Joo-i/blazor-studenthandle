var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://students.innopack.app/") });

builder.Services.AddScoped<IValidator<Student>, StudentValidator>();

await builder.Build().RunAsync();

