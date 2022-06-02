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
        private DocumentBaseModel _document;
        private BindableCollection<StockModel> _stocks = null;
        private BindableCollection<ProductAndAmount> _productsAndAmounts = null;
        private Visibility _passwordPromptVisibility = Visibility.Hidden;
        private SecureString _userPassword;
        private string _passwordResultString = "";


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


        public string RecipentSupplierString
        {
            get 
            {
                if (Document.GetType() == typeof(DocumentPzModel)) return ((DocumentPzModel)Document).Supplier;
                if (Document.GetType() == typeof(DocumentWzModel)) return ((DocumentWzModel)Document).Recipent;
                return null;
            }
        }

        public string RecipentSupplier
        {
            get
            {
                if (Document.GetType() == typeof(DocumentPzModel)) return "Supplier";
                if (Document.GetType() == typeof(DocumentWzModel)) return "Recipent";
                return null;
            }
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
        #endregion

        #region Constructor
        public WindowDocumentInspectorViewModel(DocumentBaseModel document)
        {
            Document = document;
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
        #endregion

        #region Button clicks
        public void EnableEditButton()
        {
            PasswordPromptVisibility = Visibility.Visible;
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
