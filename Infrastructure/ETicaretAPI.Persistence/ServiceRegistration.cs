using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Persistence.Concretes;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration
    {
        //Bu sınıf içerisinde extention fonksiyonlar tanımlanacak.
        //Presentation katmanındaki IoC containera bu katmandaki servisleri tanıtmamızı sağlayacak.

        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddSingleton<IProductService, ProductService>();
        }
    }
}
