using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Reactive.Linq;

namespace ReactiveExtensionsStudy.ViewModels;

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
        Observable.Start(() => $@"Hello {this.GreetingTo}.")
            .Delay(TimeSpan.FromSeconds(3))
            .Subscribe(x =>
            {
                this.Greeting = "";

                if (!string.IsNullOrEmpty(x))
                {
                    this.Greeting = x;
                }
            });

        this.Greeting = "Greetings!";
    }
}
