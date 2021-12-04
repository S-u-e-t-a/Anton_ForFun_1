using Autofac;
using HomeLibrary.Models;
using HomeLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HomeLibrary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Book>().As<IBook>();
            builder.RegisterType<HomeLibraryService>().As<ILibraryBookService>();
            //builder.RegisterType<VisitorRepository>().As<IVisitorRepository>();
            builder.RegisterType<MainViewModel>().AsSelf();
            var container = builder.Build();
            var model = container.Resolve<MainViewModel>();
            var view = new MainWindow { DataContext = model };
            view.Show();
        }
    }
}
