﻿using Caliburn.Micro;
using Storager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storager.ViewModels
{
    public class UserControlWarehouseDocumentsViewModel : Screen
    {
        #region Properties
        private BindableCollection<DocumentTypeModel> _documentTypes;

        public BindableCollection<DocumentTypeModel> DocumentTypes
        {
            get { return _documentTypes; }
            set { _documentTypes = value; NotifyOfPropertyChange(() => DocumentTypes); }
        }

        #endregion

        #region Constructor
        public UserControlWarehouseDocumentsViewModel()
        {
            DocumentTypes = dummydata.GetDocuments();
        }
        #endregion

        #region Methods

        #endregion

    }
}
