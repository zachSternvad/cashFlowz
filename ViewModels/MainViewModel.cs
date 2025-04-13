using System;
using System.Collections.ObjectModel; // Crucial for UI updates on collection changes
using System.ComponentModel;
using System.Linq;
using System.Windows.Input; // For ICommand
using cashFlowz.Models;
using CommunityToolkit.Mvvm.ComponentModel; // From NuGet package
using CommunityToolkit.Mvvm.Input; // For RelayCommand
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace cashFlowz.ViewModels
{
    public partial class MainViewModel : ObservableObject // Inherit from ObservableObject
    {
        // -- Properties for Data Binding --

        // ObservableCollection automatically notifies the UI when items are added/removed
        [ObservableProperty] // Generates property boilerplate
        private ObservableCollection<Transaction> _transactions = new ObservableCollection<Transaction>();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(FormattedBalance))] // Update FormattedBalance when balance changes
        private decimal _balance;

        // Properties for the input form
        [ObservableProperty]
        [ObservableProperty]
        [ObservableProperty]
        [ObservableProperty]

        public string FormattedBalance => $"Balance: {Balance:C}";
    }
}
