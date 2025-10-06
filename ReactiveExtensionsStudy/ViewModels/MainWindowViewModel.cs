using CommunityToolkit.Mvvm.ComponentModel;

namespace ReactiveExtensionsStudy.ViewModels;

internal partial class MainWindowViewModel : ObservableObject
{

    [ObservableProperty]
    private string _title = "ReactiveExtensionsStudy";

}
