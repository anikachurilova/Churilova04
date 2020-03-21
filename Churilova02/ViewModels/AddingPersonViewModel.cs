using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using Churilova02.Models;
using Churilova02.Tools;
using Churilova02.Tools.Exceptions;
using Churilova02.Tools.Managers;
using Churilova02.Tools.Navigation;

namespace Churilova02.ViewModels
{
    class AddPersonViewModel : BaseViewModel, INotifyPropertyChanged
    {
        #region Fields

        private Person _person = StationManager.CurrentPerson;

        private RelayCommand<object> _proceedCommand;
        private RelayCommand<object> _cancelCommand;
        #endregion

        public AddPersonViewModel()
        {
        }

        #region Properties
        public Person PersonObj

        {
            get { return _person; }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<Object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(
                           ProceedImplementation, CanExecuteProceed));
            }
        }

        public RelayCommand<Object> CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new RelayCommand<object>(
                           CancelImplementation));
            }
        }

        #endregion

        

        private async void ProceedImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            bool res = await Task.Run(() => {
                try
                {
                    _person.Validate();
                }
                catch (PersonDontExistException e)
                {
                    MessageBox.Show($"Error! {e.Message}");
                    return false;
                }
                catch (PersonTooOldException e)
                {
                    MessageBox.Show($"Error! {e.Message}");
                    return false;
                }
                catch (InvalidEmailException e)
                {
                    MessageBox.Show($"Error! {e.Message}");
                    return false;
                }
                catch (InvalidNameException e)
                {
                    MessageBox.Show($"Error! {e.Message}");
                    return false;
                }
                catch (InvalidSurnameException e)
                {
                    MessageBox.Show($"Error! {e.Message}");
                    return false;
                }
                return true;
            });

            LoaderManager.Instance.HideLoader();
            if (res)
            {
                StationManager.DataStorage.Add(_person);
                _person = new Person("", "", "");
                PersonObj = _person;
                NavigationManager.Instance.Navigate(ViewType.TableView);
            }
        }
        
        private bool CanExecuteProceed(Object obj)
        {
            return !String.IsNullOrWhiteSpace(PersonObj.Email) && !String.IsNullOrWhiteSpace(PersonObj.Name) && !String.IsNullOrWhiteSpace(PersonObj.Surname);
        }

        private void CancelImplementation(object obj)
        {
            StationManager.TablePersonVM.UpdateInfo();
            NavigationManager.Instance.Navigate(ViewType.TableView);
        }
    }
}
