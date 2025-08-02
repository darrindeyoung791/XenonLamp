using CommunityToolkit.Mvvm.ComponentModel;

using XenonLamp.Contracts.ViewModels;
using XenonLamp.Core.Contracts.Services;
using XenonLamp.Core.Models;

namespace XenonLamp.ViewModels;

public partial class 内容网格DetailViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    [ObservableProperty]
    private SampleOrder? item;

    public 内容网格DetailViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        if (parameter is long orderID)
        {
            var data = await _sampleDataService.GetContentGridDataAsync();
            Item = data.First(i => i.OrderID == orderID);
        }
    }

    public void OnNavigatedFrom()
    {
    }
}
