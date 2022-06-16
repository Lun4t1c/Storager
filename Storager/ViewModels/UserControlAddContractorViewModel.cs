using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlAddContractorViewModel : Screen
    {
        #region Properties
        private string _selectedName = string.Empty;
        private string _selectedEmail = string.Empty;
        private string _selectedAddress = string.Empty;
        private string _warningMessage = "";

        public string SelectedName
        {
            get { return _selectedName; }
            set { _selectedName = value; NotifyOfPropertyChange(() => SelectedName); }
        }

        public string SelectedEmail
        {
            get { return _selectedEmail; }
            set { _selectedEmail = value; NotifyOfPropertyChange(() => SelectedEmail); }
        }

        public string SelectedAddress
        {
            get { return _selectedAddress; }
            set { _selectedAddress = value; NotifyOfPropertyChange(() => SelectedAddress); }
        }        

        public string WarningMessage
        {
            get { return _warningMessage; }
            set { _warningMessage = value; NotifyOfPropertyChange(() => WarningMessage); }
        }

        #endregion

        #region Constructor
        public UserControlAddContractorViewModel()
        {

        }
        #endregion

        #region Methods
        private void Confirm()
        {
            if (!isFormValid()) return;

            ContractorModel contractor = new ContractorModel()
            {
                Name = SelectedName,
                Email = SelectedEmail,
                Address = SelectedAddress
            };

            DataAcces.InsertContractor(contractor);
        }

        private bool isFormValid()
        {
            bool result = true;
            WarningMessage = "";

            if (!isNameValid()) result = false;
            if (!isAddressValid()) result = false;
            if (!isEmailValid()) result = false;

            return result;
        }

        private bool isNameValid()
        {
            if (string.IsNullOrEmpty(SelectedName))
            {
                WarningMessage += "Name invalid.\n";
                return false;
            }
            return true;
        }

        private bool isEmailValid()
        {
            if (string.IsNullOrEmpty(SelectedEmail) || !SelectedEmail.Contains('@'))
            {
                WarningMessage += "Email invalid.\n";
                return false;
            }
            return true;
        }

        private bool isAddressValid()
        {
            if (string.IsNullOrEmpty(SelectedAddress))
            {
                WarningMessage += "Address invalid.\n";
                return false;
            }
            return true;
        }
        #endregion

        #region Button clicks
        public void ConfirmButton()
        {
            Confirm();
        }
        #endregion
    }
}
