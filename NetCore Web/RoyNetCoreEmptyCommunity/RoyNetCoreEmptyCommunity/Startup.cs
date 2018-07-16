using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace RoyNetCoreEmptyCommunity
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler();
      }

      app.UseMvc();

      //NO SE RECOMIENDA PARA WEB API, ES SOLO PARA ENTENDER COMO FUNCIONA
      ////Dentro de los parentesis se asigna y configura el routing. Hay dos tipos POR CONVENCIÓN y ATRIBUTOS, ESTE ES POR CONVENCIÓN
      //app.UseMvc(config =>
      //{
      //  //Indica como va a funcionar el ruteo en MVC
      //  config.MapRoute(
      //    name: "Default",
      //    template: "{ controller}/{ action}/{ Id ?})",
      //    defaults: new
      //    {
      //      controller = "Home",
      //      action = "Index"
      //    });
      //});

      //app.Run(async (context) =>
      //{
      //  await context.Response.WriteAsync("Hello World!");
      //});
    }
  }
}
