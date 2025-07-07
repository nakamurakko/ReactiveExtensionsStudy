using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;

namespace ReactiveExtensionsStudy.ViewModels;

internal partial class MergeSampleViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "Merge Sample";

    [ObservableProperty]
    private ObservableCollection<string> _users1 = new() { "山田太郎", "田中次郎", "中島三郎" };

    [ObservableProperty]
    private ObservableCollection<string> _users2 = new() { "高橋四郎", "戸田五郎", "市川六郎" };

    [ObservableProperty]
    private ObservableCollection<string> _allUsers = new();

    [RelayCommand]
    private void MergeUsers()
    {
        this.AllUsers.Clear();

        Observable.Start(() => this.Users1)
            .Merge(Observable.Start(() => this.Users2))
            .SelectMany(x => x)
            .Subscribe(x =>
            {
                this.AllUsers.Add(x);
            });
    }
}
