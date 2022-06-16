using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Storager.ViewModels
{
    public class WindowDocumentInspectorViewModel : Screen
    {
        #region Properties
        public BindableCollection<ContractorModel> AllContractors { get; set; } = DataAcces.GetAllContractors();

        private DocumentBaseModel _document;
        private BindableCollection<StockModel> _stocks = null;
        private BindableCollection<ProductAndAmount> _productsAndAmounts = null;
        private Visibility _passwordPromptVisibility = Visibility.Hidden;
        private SecureString _userPassword;
        private string _passwordResultString = "";
        private bool _isEditingEnabled = false;
        private ContractorModel _selectedContractor;

        public DocumentBaseModel Document
        {
            get { return _document; }
            set { _document = value; NotifyOfPropertyChange(() => Document); }
        }

        public BindableCollection<StockModel> Stocks
        {
            get { return _stocks; }
            set { _stocks = value; NotifyOfPropertyChange(() => Stocks); }
        }        

        public BindableCollection<ProductAndAmount> ProductsAndAmounts
        {
            get { return _productsAndAmounts; }
            set { _productsAndAmounts = value; NotifyOfPropertyChange(() => ProductsAndAmounts); }
        }

        public Visibility PasswordPromptVisibility
        {
            get { return _passwordPromptVisibility; }
            set { _passwordPromptVisibility = value; NotifyOfPropertyChange(() => PasswordPromptVisibility); }
        }

        public SecureString UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; NotifyOfPropertyChange(() => UserPassword); }
        }        

        public string PasswordResultString
        {
            get { return _passwordResultString; }
            set { _passwordResultString = value; NotifyOfPropertyChange(() => PasswordResultString); }
        }        

        public bool isEditingEnabled
        {
            get { return _isEditingEnabled; }
            set { _isEditingEnabled = value; NotifyOfPropertyChange(() => isEditingEnabled); }
        }        

        public ContractorModel SelectedContractor
        {
            get { return _selectedContractor; }
            set { _selectedContractor = value; NotifyOfPropertyChange(() => SelectedContractor); }
        }
        #endregion

        #region Constructor
        public WindowDocumentInspectorViewModel(DocumentBaseModel document)
        {
            Document = document;
            SelectedContractor = FindContractorFromDocument(document);
            LoadStocksOrProducts();
        }
        #endregion

        #region Methods
        private void LoadStocksOrProducts()
        {
            if (Document.GetType() == typeof(DocumentPzModel))
            {
                Console.WriteLine("LOADING STOCKS");
                ProductsAndAmounts = null;
                Stocks = ((DocumentPzModel)Document).Stocks;
            }
            else if (Document.GetType() == typeof(DocumentWzModel))
            {
                Console.WriteLine("LOADING PRODUCTS");
                Stocks = null;
                ProductsAndAmounts = ((DocumentWzModel)Document).ProductsAndAmount;
            }
        }

        private void EnableEdit()
        {
            isEditingEnabled = true;
        }

        private void ConfirmChanges()
        {

            if (Document.GetType() == typeof(DocumentPzModel))
                ((DocumentPzModel)Document).Supplier = SelectedContractor;
            else if (Document.GetType() == typeof(DocumentWzModel))
                ((DocumentWzModel)Document).Recipent = SelectedContractor;
            else
                return;

            DataAcces.UpdateDocument(Document);
        }

        private async void CheckPassword()
        {
            PasswordResultString = "";
            bool isPasswordValid = await Task.Run(() => DataAcces.CheckPassword(Globals.LoggedUser.Login, UserPassword));

            if (isPasswordValid)
            {
                PasswordPromptVisibility = Visibility.Hidden;
                EnableEdit();
            }
            else PasswordResultString = "Invalid password.";
        }

        private ContractorModel FindContractorFromDocument(DocumentBaseModel document)
        {
            if (document.GetType() == typeof(DocumentPzModel))
            {
                ContractorModel contractor = AllContractors.FirstOrDefault(c => c.Name == ((DocumentPzModel)document).Supplier.Name);
                return contractor;
            }
            if (document.GetType() == typeof(DocumentWzModel))
            {
                ContractorModel contractor = AllContractors.FirstOrDefault(c => c.Name == ((DocumentWzModel)document).Recipent.Name);
                return contractor;
            }

            return null;
        }
        #endregion

        #region Button clicks
        public void EnableEditButton()
        {
            PasswordPromptVisibility = Visibility.Visible;
        }

        public void ConfirmChangesButton()
        {
            ConfirmChanges();
        }
        #endregion

        #region Key downs
        public void UserPasswordPreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                CheckPassword();
            }
        }
        #endregion
    }
}
