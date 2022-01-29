using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UltimateGiftShop.Extensions
{
    public static class ServiceCollectionExtensions
    {
    //    public static T AddConfigSectionFromAppSettings<T>(this IServiceCollection serviceCollection,
    //        string configSection) where T : class
    //    {
    //        IConfigurationSection section = ConfigurationManager.AppSettings[""];
    //        serviceCollection.Configure<T>(section);
    //        T sectionConfig = section.Get<T>();
    //        serviceCollection.AddSingleton(sectionConfig);
    //        return sectionConfig;
    //    }
    }
}
