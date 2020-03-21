using System;
using System.Windows.Controls;
using Churilova02.Tools.Navigation;
using Churilova02.ViewModels;

namespace Churilova02.Views
{
    /// <summary>
    /// Interaction logic for EditingPersonView.xaml
    /// </summary>
    public partial class EditingPersonView : UserControl, INavigatable
    {
        public EditingPersonView()
        {
            InitializeComponent();
            DataContext = new EditPersonViewModel();
        }

   
       
    }
}
