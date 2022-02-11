using AutoMapper;
using Fantastic3D.AppModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Fantastic3D.GUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string ApiBaseUrl = "https://localhost:7164/api/";
        public IMapper Mapper { get; }
        public App()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps(typeof(DtoToModelProfile)));
            Mapper = new Mapper(configuration);
        }

        
    }
}
