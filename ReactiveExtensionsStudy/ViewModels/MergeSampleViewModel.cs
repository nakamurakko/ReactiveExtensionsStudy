using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveExtensionsStudy.ViewModels
{
    internal partial class MergeSampleViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _title = "Merge Sample";

        [ObservableProperty]
        private ObservableCollection<string> _users1 = new ObservableCollection<string>() { "山田太郎", "田中次郎", "中島三郎" };

        [ObservableProperty]
        private ObservableCollection<string> _users2 = new ObservableCollection<string>() { "高橋四郎", "戸田五郎", "市川六郎" };

        [ObservableProperty]
        private ObservableCollection<string> _allUsers = new ObservableCollection<string>();

        [RelayCommand]
        private void MergeUsers()
        {
            AllUsers.Clear();

            Observable.Start(() => Users1)
                .Merge(Observable.Start(() => Users2))
                .SelectMany(x => x)
                .Subscribe(x =>
                {
                    AllUsers.Add(x);
                });
        }
    }
}
