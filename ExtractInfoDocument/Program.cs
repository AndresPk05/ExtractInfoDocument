using ExtractInfoDocument.BUISNESS_LOGIC.DTOS;
using ExtractInfoDocument.BUISNESS_LOGIC.LOGIC;
using ExtractInfoDocument.BUISNESS_LOGIC.REPOSITORY;
using ExtractInfoDocument.INFRASTRUCTURE.AZURE_AI;
using ExtractInfoDocument.INFRASTRUCTURE.MODEL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ExtractionInfoDocumentContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SQlConnection")));

builder.Services.AddScoped<IDocumentIntelligence, DocumentIntelligence>();
builder.Services.AddScoped<IDocument, ExtractInfoDocument.BUISNESS_LOGIC.LOGIC.Document>();
builder.Services.AddScoped<IProcessDocument, ProcessDocument>();
builder.Services.AddScoped<ExtractInfoDocument.BUISNESS_LOGIC.REPOSITORY.IExtractionPerformed, ExtractInfoDocument.BUISNESS_LOGIC.REPOSITORY.ExtractionPerformed>();
builder.Services.AddScoped<ExtractInfoDocument.BUISNESS_LOGIC.LOGIC.IExtractionPerformed, ExtractInfoDocument.BUISNESS_LOGIC.LOGIC.ExtractionPerformed>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.MapPost("/document/", async (IProcessDocument processDocument, DocumentRequest request) =>
{
    var result = await processDocument.ExtractInfoDocument(request);
    return Results.Ok(result);
}).WithOpenApi();

app.Run();
