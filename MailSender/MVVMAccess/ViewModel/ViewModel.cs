using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMAccess.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Публичное свойство для привязки Account
        public Model.Account Account { get; set; } = new Model.Account("None", "None");

        public int AttemptCount 
        { 
            get
            {
                return Model.AccessToApp.Attempt;
            } 
        }

        public bool Authorized
        {
            get
            {
                return Model.AccessToApp.Access;
            }
        }
        #endregion


        private void Execute(object obj)
        {
            //Проверяем есть ли такой аккаунт в базе данных
            MVVMAccess.Model.AccessToApp.Checks(Account);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("AttemptCount"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Authorized"));
        }

        private void ClearExecute(object obj)
        {
            //Проверяем есть ли такой аккаунт в базе данных
            Account.ClearLogin();
            MVVMAccess.Model.AccessToApp.Checks(Account);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Account"));
        }

        private bool CanExecute(object obj)
        {
            return MVVMAccess.Model.AccessToApp.Attempt < 3;
        }

        public ICommand ClickAccess
        {
            get
            {
                return new DelegateCommand(Execute, CanExecute);
            }
        }

        public ICommand ClickClearLogin
        {
            get
            {
                return new DelegateCommand(ClearExecute, CanExecute);
            }
        }
    }
}
