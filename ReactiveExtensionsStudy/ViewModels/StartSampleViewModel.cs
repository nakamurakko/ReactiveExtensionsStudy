using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Reactive.Linq;

namespace ReactiveExtensionsStudy.ViewModels;

internal partial class StartSampleViewModel : ObservableObject
{
    [ObservableProperty]
    public string _title = "StartSample";

    [ObservableProperty]
    public string _message = "";

    [RelayCommand]
    public void HelloWorld()
    {
        this.Message = "";

        Observable.Start(() =>
        {
            return "Hello world.";
        })
            .Subscribe(x =>
            {
                this.Message = x;
            });
    }

    [RelayCommand]
    public void HelloWorldWithDelay()
    {
        this.Message = "";

        Observable.Start(() =>
        {
            return "Hello world with Delay.";
        })
            .Delay(TimeSpan.FromSeconds(3))
            .Subscribe(x =>
            {
                this.Message = x;
            });
    }
}
