using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace NetCoreEmptyDemo
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      //Pone a disponibilidad servicio MVC
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
      app.UseStatusCodePages();

      //Creando el midelwork MVC Model, View, Controller. Recibe peticiones http y responde a solicitud
      app.UseMvc();

      //app.Run(async (context) =>
      //{
      //  //La web no levanta y aparece mensajede excepcion amigable
      //  throw new Exception("Probando...");
      //});

      //app.Run(async (context) =>
      //{
      //    await context.Response.WriteAsync("Hello World!");
      //});

      //Para los mildwere suelen empezar en los siguientes prefijos
      //app.Use...
      //app.run...
      //app.map...
    }
  }
}
