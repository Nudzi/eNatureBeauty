using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using eNatureBeauty.WebAPI.Database;
using eNatureBeauty.WebAPI.Services;
using eNatureBeauty.Model.Requests;
using Microsoft.AspNetCore.Authentication;
using eNatureBeauty.WebAPI.Security;
using eNatureBeauty.Model.Requests.Inputs;
using eNatureBeauty.Model.Requests.Outputs;
using eNatureBeauty.Model.Requests.Orders;
using eNatureBeauty.Model.Requests.InputProducts;
using eNatureBeauty.Model.Requests.OutputProducts;
using eNatureBeauty.Model.Requests.UserAddresses;
using eNatureBeauty.Model.Requests.ProductsIngredients;

namespace eNatureBeauty.WebAPI
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
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "basic"
                                }
                            },
                            new string[] {}
                        }
                });
            });
            services.AddAuthentication("BasicAuthentication")
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUserTypesService, UserTypesService>();
            services.AddScoped<IIngredientsIngredientTypesService, IngredientsIngredientTypesService>();
            services.AddScoped<IWishlistsService, WishlistsService>();
            services.AddScoped<IReviewsService, ReviewsService>();
            services.AddScoped<IIngredientsService, IngredientsService>();
            services.AddScoped<IStoragesService, StoragesService>();

            services.AddScoped<IService<Model.Units, object>, BaseService<Model.Units, object, Units>>();
            services.AddScoped<IService<Model.ProductTypes, object>, BaseService<Model.ProductTypes, object, ProductTypes>>();
            services.AddScoped<IService<Model.IngredientTypes, object>, BaseService<Model.IngredientTypes, object, IngredientTypes>>();
            services.AddScoped<IService<Model.Units, object>, BaseService<Model.Units, object, Units>>();
            services.AddScoped<ICRUDService<Model.ProductsIngredients, ProductsIngredientsSearchRequest, ProductsIngredientsUpsertRequest, ProductsIngredientsUpsertRequest>, ProductsIngredientsService>();
            services.AddScoped<ICRUDService<Model.Orders, OrdersSearchRequest, OrdersUpsertRequest, OrdersUpsertRequest>, OrdersService>();
            services.AddScoped<ICRUDService<Model.InputProducts, InputProductsSearchRequest, InputProductsUpsertRequest, InputProductsUpsertRequest>, InputProductsService>();
            services.AddScoped<ICRUDService<Model.OutputProducts, OutputProductsSearchRequest, OutputProductsUpsertRequest, OutputProductsUpsertRequest>, OutputProductsService>();
            services.AddScoped<ICRUDService<Model.UserAddresses, UserAddressesSearchRequest, UserAddressesUpsertRequest, UserAddressesUpsertRequest>, UserAddressesService>();
            services.AddScoped<ICRUDService<Model.Products, ProductsSearchRequest, ProductsUpsertRequest, ProductsUpsertRequest>, ProductsService>();
            services.AddScoped<ICRUDService<Model.Inputs, InputsSearchRequest, InputsUpsertRequest, InputsUpsertRequest>, InputsService>();
            services.AddScoped<ICRUDService<Model.Outputs, OutputsSearchRequest, OutputsUpsertRequest, OutputsUpsertRequest>, OutputsService>();
            services.AddScoped<IRecommender, RecommenderService>();
            //var connection = @"Server=.;Database=natureBeauty;Trusted_Connection=True;ConnectRetryCount=0";
            //var connection = "Data Source=.;Initail Catalog=natureBeauty;Integrated Security=True";
            var connection = Configuration.GetConnectionString("eNatureBeauty");
            services.AddDbContext<natureBeautyContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();


            app.UseSwagger();
            app.UseAuthorization();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");

            });

            //app.UseMvc();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
