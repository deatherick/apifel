using System.ServiceModel;
using APIFel.Controllers;
using APIFel.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using SoapCore;

namespace APIFel
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
            services.AddSoapCore();
            services.TryAddSingleton<PingController>();
            services.TryAddSingleton<LoginController>();
            services.TryAddSingleton<GeneraXmlController>();
            services.TryAddSingleton<CertificarDocumentoController>();
            services.AddMvc();

            services.AddControllers();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints => {
                endpoints.UseSoapEndpoint<PingController>("/ApiFel.asmx", new BasicHttpBinding());
                endpoints.UseSoapEndpoint<LoginController>("/ApiFel/Login.asmx", new BasicHttpBinding());
                endpoints.UseSoapEndpoint<GeneraXmlController>("/ApiFel/GeneraXML.asmx", new BasicHttpBinding());
                endpoints.UseSoapEndpoint<CertificarDocumentoController>("/ApiFel/CertificarDocumento.asmx", new BasicHttpBinding());
            });
        }
    }
}
