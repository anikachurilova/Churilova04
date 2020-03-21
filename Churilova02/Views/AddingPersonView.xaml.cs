using System;
using System.Windows.Controls;
using Churilova02.Tools.Navigation;
using Churilova02.ViewModels;

namespace Churilova02.Views
{
    /// <summary>
    /// Interaction logic for AddingPersonView.xaml
    /// </summary>
    public partial class AddingPersonView : UserControl, INavigatable
    {
        public AddingPersonView()
        {
            InitializeComponent();
            DataContext = new AddPersonViewModel();
        }

    }
}
