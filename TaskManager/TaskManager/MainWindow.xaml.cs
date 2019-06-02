using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskManager
{
    public partial class MainWindow : Window
    {
        int id;

        public MainWindow()
        {
            InitializeComponent();

            var processes = Process.GetProcesses();

            infoProcess.ItemsSource = processes;            
        }

        private void buttonForTakeOffProcessClick(object sender, RoutedEventArgs e)
        {
            var processes = Process.GetProcesses();
            foreach (var i in processes)
            {
                if (i.Id == (infoProcess.SelectedItem as Process).Id)
                {
                    try
                    {
                    i.Kill();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void infoProcessPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = sender as DataGrid;

            id = ((dg.SelectedItem as Process).Id);
        }
    }
}
