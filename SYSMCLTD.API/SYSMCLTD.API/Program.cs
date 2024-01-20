using Microsoft.EntityFrameworkCore;

using SYSMCLTD.API.Data;

       
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //DI DBcontext
            builder.Services.AddDbContext<SYSMCDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SYSMCLTDDBConectionString")));



            builder.Services.AddCors((setup) =>
            {
                setup.AddPolicy("defult", (options) =>
                {
                    options.AllowAnyHeader().AllowAnyOrigin().AllowAnyOrigin();
                });

            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

             app.UseCors("defult");

             app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
    
