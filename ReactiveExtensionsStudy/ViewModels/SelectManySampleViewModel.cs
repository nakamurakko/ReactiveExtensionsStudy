using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;

namespace ReactiveExtensionsStudy.ViewModels;

internal partial class SelectManySampleViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "SelectMany";

    [ObservableProperty]
    private ObservableCollection<string> _users = new ObservableCollection<string>();

    [RelayCommand]
    public void ShowUsers()
    {
        this.Users.Clear();

        Observable.Start(() => new List<string>() { "山田太郎", "田中次郎", "中島三郎" })
            .SelectMany(x => x)
            .Select(x => x + "さん")
            .Subscribe(x =>
            {
                this.Users.Add(x);
            });
    }
}
