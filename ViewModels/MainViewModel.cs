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
        [ObservableProperty] private DateTime _newTransactionDate = DateTime.Today;
        [ObservableProperty] private string? _newTransactionDescription;
        [ObservableProperty] private decimal _newTransactionAmount;
        [ObservableProperty] private TransactionType _selectedTransactionType = TransactionType.Expense; // Default

        public string FormattedBalance => $"Balance: {Balance:C}"; // Format as Currency

        // -- Commands --
        public ICommand AddTransactionCommand { get; }

        // -- Constructor --
        public MainViewModel()
        {
            // Initialize command (using Community.Toolkit.Mvvm RelayCommand)
            AddTransactionCommand = new RelayCommand(AddTransaction, CanAddTransaction);

            // Load initial/saved data (implement later)
            LoadTransactions();
            CalculateBalance();
        }

        // -- Methods --
        private void AddTransactions()
        {
            var newTransaction = new Transaction(
                NewTransactionDate,
                NewTransactionDescription ?? "No description", // Handle potential null
                NewTransactionAmount,
                SelectedTransactionType
                // Add Category handling here later
            );

            Transactions.Add(newTransaction); // Add to the collection
            CalculateBalance(); // Recalculate balance

            // Clear input fields
            NewTransactionDescription = string.Empty;
            NewTransactionAmount = 0;
            NewTransactionDate = DateTime.Today;

            // Save data (implement later)
            SaveTransactions();
        }

        // Example validation: Can only add if amount > 0 and description is not empty
        private bool CanAddTransaction()
        {
            return NewTransactionAmount > 0 && !string.IsNullOrWhiteSpace(NewTransactionDescription);
        }

        // Need to re-evaluate CanAddTransaction when input properties change
        // CommunityToolkit.Mvvm handles this automatically if you update the command pattern slightly,
        // or you can manually call ((RelayCommand)AddTransactionCommand).NotifyCanExecuteChanged();
        // For simplicity here, we'll rely on manual calls or property change notifications if needed.
        // Or, simpler: Just always enable the button and do validation inside AddTransaction().

        partial void OnNewTransactionAmountChanged(decimal value)
        {

        }
    }
}
