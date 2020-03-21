using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Churilova02.Tools.Managers;
using Churilova02.Tools.Navigation;
using Churilova02.ViewModels;

namespace Churilova02.Views
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class TableView : UserControl, INavigatable
    {

        public TableView()
        {
            InitializeComponent();
            DataContext = new TableViewModel();
            StationManager.PersonTable = TableGrid;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             
        }
    }
}
