using System.Windows.Controls;

using WineLabeller.ViewModels;

namespace WineLabeller.Views;

public partial class MainPage : Page
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
