﻿using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using Churilova02.Models;
using Churilova02.Tools;
using Churilova02.Tools.Exceptions;
using Churilova02.Tools.Managers;
using Churilova02.Tools.Navigation;

namespace Churilova02.ViewModels
{
    class EditPersonViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public EditPersonViewModel()
        {
            StationManager.EditPersonVM = this;
        }
        #region Fields
        private Person _person = StationManager.CurrentPerson;
        private Person _personToEdit = StationManager.PersonToEdit;

        private RelayCommand<object> _confirmCommand;
        private RelayCommand<object> _cancelCommand;
        #endregion

        #region Properties
        public Person PersonToEdit
        {
            get { return _personToEdit; }
            set
            {
                _personToEdit = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<Object> ConfirmCommand
        {
            get
            {
                return _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(
                           ConfirmImplementation, CanExecuteProceed));
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

        private async void ConfirmImplementation(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            bool res = await Task.Run(() => {
               
                    try
                    {
                        _personToEdit.Validate();
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
                _person.Name = _personToEdit.Name;
                _person.Surname = _personToEdit.Surname;
                _person.Email = _personToEdit.Email;
                _person.Birthday = _personToEdit.Birthday;
                StationManager.PersonToEdit = null;
                StationManager.DataStorage.DoChanges();
                StationManager.TablePersonVM.UpdateInfo();
                NavigationManager.Instance.Navigate(ViewType.TableView);
            }
        }

        private bool CanExecuteProceed(Object obj)
        {
            return !String.IsNullOrWhiteSpace(PersonToEdit.Email) && !String.IsNullOrWhiteSpace(PersonToEdit.Name) && !String.IsNullOrWhiteSpace(PersonToEdit.Surname);
        }

        private async void CancelImplementation(object obj)
        {
            StationManager.PersonToEdit = null;
            NavigationManager.Instance.Navigate(ViewType.TableView);

        }

        public void Update()
        {
            _personToEdit = StationManager.PersonToEdit;
            _person = StationManager.CurrentPerson;
            OnPropertyChanged("PersonToEdit");
        }
    }
}
