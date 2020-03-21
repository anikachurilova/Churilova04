using System.Windows;
using System.Windows.Controls;
using Churilova02.Tools.DataStorage;
using Churilova02.Tools.Managers;
using Churilova02.Tools.Navigation;
using Churilova02.ViewModels;

namespace Churilova02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IContentOwner
    {
       

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

            StationManager.Initialize(new SerializedDataStorage());
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.TableView);

        }
    }
}
