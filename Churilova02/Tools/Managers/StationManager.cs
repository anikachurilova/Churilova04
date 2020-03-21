using System;
using System.Windows;
using System.Windows.Controls;
using Churilova02.Models;
using Churilova02.Tools.DataStorage;
using Churilova02.ViewModels;

namespace Churilova02.Tools.Managers
{
    internal static class StationManager
    {
        internal static Person CurrentPerson { get; set; }
        internal static Person PersonToEdit { get; set; }
        internal static DataGrid PersonTable { get; set; }
        internal static EditPersonViewModel EditPersonVM { get; set; }
        internal static TableViewModel TablePersonVM { get; set; }

        private static IDataStorage _dataStorage;

        internal static IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        internal static void Initialize(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        internal static void CloseApp()
        {
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }

    }
}
