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
    internal partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _title = "ReactiveExtensionsStudy";

        [ObservableProperty]
        public string _greeting = "";

        [ObservableProperty]
        public string _greetingTo = "Everyone";

        [RelayCommand]
        public void ShowGreeting()
        {
            Observable.Start(() => $@"Hello {GreetingTo}.")
                .Delay(TimeSpan.FromSeconds(3))
                .Subscribe(x =>
                {
                    Greeting = "";

                    if (!string.IsNullOrEmpty(x))
                    {
                        Greeting = x;
                    }
                });

            Greeting = "Greetings!";
        }
    }
}
