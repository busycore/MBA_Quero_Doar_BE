using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using source.Models;
using source.Service;
using source.Service.Data;
using source.Service.Interfaces;
using source.Service.Repository;
using System;
using System.Text.Json;

namespace source
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddScoped<INoSql, NoSql>();

            services.AddScoped<DoadorService>();
            services.AddScoped<DoadorRepository>();
            services.AddScoped<IRepository<Doador>, DoadorRepository>();

            services.AddScoped<EmpresaService>();
            services.AddScoped<EmpresaRepository>();
            services.AddScoped<IRepository<Empresa>, EmpresaRepository>();

            services.AddScoped<InstituicaoService>();
            services.AddScoped<InstituicaoRepository>();
            services.AddScoped<IRepository<Instituicao>, InstituicaoRepository>();

            services.AddScoped<PagamentoService>();
            services.AddScoped<PagamentoRepository>();
            services.AddScoped<IRepository<Pagamento>, PagamentoRepository>();

            services.AddScoped<SetorAtuacaoService>();
            services.AddScoped<SetorAtuacaoRepository>();
            services.AddScoped<IRepository<SetorAtuacao>, SetorAtuacaoRepository>();

            services.AddScoped<DoacaoService>();
            services.AddScoped<DoacaoRepository>();
            services.AddScoped<IRepository<Doacao>, DoacaoRepository>();

            services.AddScoped<CupomService>();
            services.AddScoped<CupomRepository>();
            services.AddScoped<IRepository<Cupom>, CupomRepository>();

            services.AddScoped<MeusCuponsRepository>();
            services.AddScoped<IRepository<MeusCupons>, MeusCuponsRepository>();

            services.AddScoped<AuthService>();

            services.AddAutoMapper(typeof(Startup));

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(opt =>
                {
                    opt.RequireHttpsMetadata = false;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String("mlyDaLVs3SA0jQcHOlxZRiTZ0JvYvpGLxHN312KddWPHg8vlNSpXh0Xt61QelkEcz+UGnQ85fhMy/X0/cBmJAQ==")),
                        ValidateIssuer = true,
                        ValidIssuer = "http://localhost:8080",
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddControllers(m =>
            {
                m.Filters.Add(new AuthorizeFilter());
                m.Filters.Add(new ProducesAttribute("application/json"));
            })
            .AddJsonOptions(m =>
            {
                m.JsonSerializerOptions.IgnoreNullValues = true;
                m.JsonSerializerOptions.WriteIndented = false;
                m.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                m.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                m.JsonSerializerOptions.AllowTrailingCommas = true;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "source", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "source v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}