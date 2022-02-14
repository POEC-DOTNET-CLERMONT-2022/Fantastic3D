using AutoMapper;
using Fantastic3D.AppModels;
using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using Fantastic3D.GUI.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace Fantastic3D.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Utilities.IServiceProvider Services { get; }
        public App()
        {
            Services = new ServiceProvider();
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7164/api/");
            Services.RegisterService<HttpClient>(client);

            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(DtoToModelProfile)));
            var mapper = new Mapper(configuration);
            Services.RegisterService<IMapper>(mapper);

            Services.RegisterService<IDataManager<User, UserDto>>(new ApiDataManager<User, UserDto>(client, mapper));
            Services.RegisterService<IDataManager<Asset, AssetDto>>(new ApiDataManager<Asset, AssetDto>(client, mapper));
            
            // Services.RegisterService<IDataManager<Order, OrderDto>>(new ApiDataManager<Order, OrderDto>(client, mapper));
            // Services.RegisterService<IDataManager<Review, ReviewDto>>(new ApiDataManager<Review, ReviewDto>(client, mapper));

        }

        
    }
}
