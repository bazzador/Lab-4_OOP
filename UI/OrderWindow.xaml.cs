using OrderClasses;
using System;
using System.Windows;
using System.Windows.Controls;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public Order _newOrder;
        public Order _incomingOrder;
        public OrderWindow(Order incomingOrder)
        {
            InitializeComponent();
            _newOrder = incomingOrder;
            _incomingOrder = (Order)incomingOrder.Clone();
            ServiceTypeComboBox.ItemsSource = Enum.GetValues(typeof(OrderClasses.ServiceType));
            LoadOrder();
        }
        public void LoadOrder()
        {
            ServiceTypeComboBox.SelectedItem = _newOrder.Client_.ServiceType_;
            AddressTextBox.Text = _newOrder.Client_.Address;
            LastNameTextBox.Text = _newOrder.Performer_.LastName;
            FirstNameTextBox.Text = _newOrder.Performer_.FirstName;
            DateOfBirthDatePicker.SelectedDate = _newOrder.Performer_.DateOfBirth;
            DateDatePicker.SelectedDate = _newOrder.Date;

            AddressTextBox.TextChanged += AddressTextBox_TextChanged;
            LastNameTextBox.TextChanged += LastNameTextBox_TextChanged;
            FirstNameTextBox.TextChanged += FirstNameTextBox_TextChanged;
            DateOfBirthDatePicker.SelectedDateChanged += DateOfBirthDatePicker_SelectedDateChanged;
            DateDatePicker.SelectedDateChanged += DateDatePicker_SelectedDateChanged;
        }

        private void AddressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AddressTextBox.Text))
            {
                _newOrder.Client_.Address = AddressTextBox.Text; 
            }
        }

        private void LastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LastNameTextBox.Text))
            {
                _newOrder.Performer_.LastName = LastNameTextBox.Text;
            }
        }

        private void FirstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                _newOrder.Performer_.FirstName = FirstNameTextBox.Text;
            }
        }

        private void DateOfBirthDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DateOfBirthDatePicker.SelectedDate.HasValue)
            {
                _newOrder.Performer_.DateOfBirth = DateOfBirthDatePicker.SelectedDate.Value;
            }
        }

        private void DateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DateDatePicker.SelectedDate.HasValue)
            {
                _newOrder.Date = DateDatePicker.SelectedDate.Value;
            }
        }
        
        private void SaveAndCloseButton_Click(object sender, RoutedEventArgs e)
        {
            if(AreFieldsFilled())
            {
                MessageBox.Show("Не всі поля заповнені!");
                return;
            }
            SaveOrder();
            DialogResult = true;
            Close();
        }
        private void RejectAndCloseButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        private bool AreFieldsFilled()
        {
            return string.IsNullOrWhiteSpace(AddressTextBox.Text) &&
                string.IsNullOrWhiteSpace(LastNameTextBox.Text) &&
                string.IsNullOrWhiteSpace(FirstNameTextBox.Text) &&
                DateOfBirthDatePicker.SelectedDate.HasValue &&
                DateDatePicker.SelectedDate.HasValue;
        }
        private void SaveOrder()
        {
            var createdClient = new Client((ServiceType)ServiceTypeComboBox.SelectedItem, AddressTextBox.Text);
            var createdPerformer = new Performer(FirstNameTextBox.Text, LastNameTextBox.Text, (DateTime)DateOfBirthDatePicker.SelectedDate);
            _newOrder.Performer_ = createdPerformer;
            _newOrder.Client_ = createdClient;
            _newOrder.Date = (DateTime)DateDatePicker.SelectedDate;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DialogResult != true)
            {
                if (!_newOrder.Equals(_incomingOrder))
                {
                    var message = MessageBox.Show("Чи бажаєте зберегти зміни?", "Так", MessageBoxButton.YesNoCancel);
                    if (message == MessageBoxResult.Yes)
                    {
                        SaveOrder();
                        DialogResult = true;
                    }
                    else if (message == MessageBoxResult.No)
                    {
                        _newOrder = (Order)_incomingOrder.Clone();
                        DialogResult = false;
                    }
                    else if (message == MessageBoxResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
            
        }
    }
}