using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExtensionsStudy.ViewModels
{
    internal partial class StartSampleViewModel : ObservableObject
    {
        [ObservableProperty]
        public string _title = "StartSample";

        [ObservableProperty]
        public string _message = "";

        [RelayCommand]
        public void HelloWorld()
        {
            Message = "";

            Observable.Start(() =>
            {
                return "Hello world.";
            })
                .Subscribe(x =>
                {
                    Message = x;
                });
        }

        [RelayCommand]
        public void HelloWorldWithDelay()
        {
            Message = "";

            Observable.Start(() =>
            {
                return "Hello world with Delay.";
            })
                .Delay(TimeSpan.FromSeconds(3))
                .Subscribe(x =>
                {
                    Message = x;
                });
        }
    }
}
