using Newtonsoft.Json;
using OrderClasses;
using OrderClasses.Converters;
using OrderClasses.DataTransfer;
using System;
using System.IO;
using System.Windows;

namespace UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        private OrderBuro _orderBuro;
        private string jsonFilePath = @"C:\Users\Ivanchik\source\repos\Lab№4_OOP\Lab№4_OOP\bin\Debug\orderBuro.json";
        public MainWindow()
        {
            InitializeComponent();
            _orderBuro = File.Exists(jsonFilePath) ? DeserializeOrderBuroFromJson(jsonFilePath) : new OrderBuro("Бюро_#1");
            RefreshOrderList();
        }
        private void RefreshOrderList()
        {
            OrderListBox.Items.Clear();
            foreach(var order in _orderBuro.Orders)
            {
                OrderListBox.Items.Add(order.ToString());
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SerializeOrderBuroToJson(_orderBuro, jsonFilePath);
        }
        void SerializeOrderBuroToJson(OrderBuro orderBuro, string filePath)
        {
            var dtoObj = OrderBuroConverter.ToDTO(orderBuro);
            var jsonFile = JsonConvert.SerializeObject(dtoObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, jsonFile);
        }
        OrderBuro DeserializeOrderBuroFromJson(string filePath)
        {
            var jsonFile = File.ReadAllText(filePath);
            var dtoObj = JsonConvert.DeserializeObject<OrderBuroDTO>(jsonFile);
            return OrderBuroConverter.FromDTO(dtoObj);
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            var performer = new Performer("Іван", "Латиш", DateTime.Now);
            var order = new Order(performer, new Client(OrderClasses.ServiceType.Window_washing, "вул. Колотушкіна, 2"), DateTime.Now);
            var orderWindow = new OrderWindow(order);
            if (orderWindow.ShowDialog() == true)
            {
                _orderBuro.AddOrder(order);
                RefreshOrderList();
            }
        }
        private void EditOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if(OrderListBox.SelectedItem != null)
            {
                var index = OrderListBox.SelectedIndex;
                var order = _orderBuro.Orders[index];
                var orderWindow = new OrderWindow(order);
                if(orderWindow.ShowDialog() == true)
                {
                    RefreshOrderList();
                }
            }
        }
        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (OrderListBox.SelectedItem != null)
            {
                var index = OrderListBox.SelectedIndex;
                var order = _orderBuro.Orders[index];
                var message = MessageBox.Show("Чи бажаєте видалити замовлення?", "Так", MessageBoxButton.YesNoCancel);
                if (message == MessageBoxResult.Yes)
                {
                    _orderBuro.DeleteOrder(order);
                    RefreshOrderList();
                }
                else if (message == MessageBoxResult.No)
                {
                    return;
                }
                else if (message == MessageBoxResult.Cancel)
                {
                    return;
                }
            }
        }
    }
}