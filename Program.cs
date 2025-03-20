using jiraApi.Manager;
using jiraApi.Manager.IManager;
using jiraApi.Repository.IRepository;
using jiraApi.Repository;
using jiraApi.HttpService.IHttpService;
using jiraApi.HttpService;
using jiraApi.Utility;

var builder = WebApplication.CreateBuilder(args);
var corsPolicy = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IIssueRepository, IssueRepository>();
builder.Services.AddScoped<IHttpClient, standardHttpClient>();
builder.Services.AddScoped<IGLIssueManager, GLIssueManager>();
builder.Services.AddScoped<IMSMTAIssueManager, MSMTAIssueManager>();
builder.Services.AddScoped<IUtility, Utility>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
	options.AddPolicy(name: corsPolicy,
					  policy =>
					  {
						  policy.AllowAnyOrigin()
								.AllowAnyMethod()
								.AllowAnyHeader();
					  });
	options.AddPolicy("AnotherPolicy",
		policy =>
		{
			policy.AllowAnyOrigin()
								.AllowAnyHeader()
								.AllowAnyMethod();
		});
});
//builder.Services.AddCors(options => options.AddPolicy(name : CorsPolicy,
//				build =>
//				{
//					build
//					.AllowAnyOrigin()
//					.AllowAnyMethod()
//					.AllowAnyHeader();
//				}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors("corsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
