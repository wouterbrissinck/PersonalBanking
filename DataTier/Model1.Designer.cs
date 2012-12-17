﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("BankTestModel", "FK_Transact_Categories", "Categories", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(DataTier.Categories), "Transact", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(DataTier.Transact), true)]

#endregion

namespace DataTier
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class BankTestEntities1 : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new BankTestEntities1 object using the connection string found in the 'BankTestEntities1' section of the application configuration file.
        /// </summary>
        public BankTestEntities1() : base("name=BankTestEntities1", "BankTestEntities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BankTestEntities1 object.
        /// </summary>
        public BankTestEntities1(string connectionString) : base(connectionString, "BankTestEntities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BankTestEntities1 object.
        /// </summary>
        public BankTestEntities1(EntityConnection connection) : base(connection, "BankTestEntities1")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Categories> Categories
        {
            get
            {
                if ((_Categories == null))
                {
                    _Categories = base.CreateObjectSet<Categories>("Categories");
                }
                return _Categories;
            }
        }
        private ObjectSet<Categories> _Categories;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<sysdiagrams> sysdiagrams
        {
            get
            {
                if ((_sysdiagrams == null))
                {
                    _sysdiagrams = base.CreateObjectSet<sysdiagrams>("sysdiagrams");
                }
                return _sysdiagrams;
            }
        }
        private ObjectSet<sysdiagrams> _sysdiagrams;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Transact> Transact
        {
            get
            {
                if ((_Transact == null))
                {
                    _Transact = base.CreateObjectSet<Transact>("Transact");
                }
                return _Transact;
            }
        }
        private ObjectSet<Transact> _Transact;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TransactionsSelectorView> TransactionsSelectorView
        {
            get
            {
                if ((_TransactionsSelectorView == null))
                {
                    _TransactionsSelectorView = base.CreateObjectSet<TransactionsSelectorView>("TransactionsSelectorView");
                }
                return _TransactionsSelectorView;
            }
        }
        private ObjectSet<TransactionsSelectorView> _TransactionsSelectorView;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<ViewCategoriesEditor> ViewCategoriesEditor
        {
            get
            {
                if ((_ViewCategoriesEditor == null))
                {
                    _ViewCategoriesEditor = base.CreateObjectSet<ViewCategoriesEditor>("ViewCategoriesEditor");
                }
                return _ViewCategoriesEditor;
            }
        }
        private ObjectSet<ViewCategoriesEditor> _ViewCategoriesEditor;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Categories EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCategories(Categories categories)
        {
            base.AddObject("Categories", categories);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the sysdiagrams EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTosysdiagrams(sysdiagrams sysdiagrams)
        {
            base.AddObject("sysdiagrams", sysdiagrams);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Transact EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTransact(Transact transact)
        {
            base.AddObject("Transact", transact);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the TransactionsSelectorView EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTransactionsSelectorView(TransactionsSelectorView transactionsSelectorView)
        {
            base.AddObject("TransactionsSelectorView", transactionsSelectorView);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the ViewCategoriesEditor EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToViewCategoriesEditor(ViewCategoriesEditor viewCategoriesEditor)
        {
            base.AddObject("ViewCategoriesEditor", viewCategoriesEditor);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BankTestModel", Name="Categories")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Categories : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Categories object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        public static Categories CreateCategories(global::System.Int32 id)
        {
            Categories categories = new Categories();
            categories.ID = id;
            return categories;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ID
        {
            get
            {
                return _ID;
            }
            set
            {
                if (_ID != value)
                {
                    OnIDChanging(value);
                    ReportPropertyChanging("ID");
                    _ID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        private global::System.Int32 _ID;
        partial void OnIDChanging(global::System.Int32 value);
        partial void OnIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Color
        {
            get
            {
                return _Color;
            }
            set
            {
                OnColorChanging(value);
                ReportPropertyChanging("Color");
                _Color = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Color");
                OnColorChanged();
            }
        }
        private global::System.String _Color;
        partial void OnColorChanging(global::System.String value);
        partial void OnColorChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BankTestModel", "FK_Transact_Categories", "Transact")]
        public EntityCollection<Transact> Transact
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Transact>("BankTestModel.FK_Transact_Categories", "Transact");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Transact>("BankTestModel.FK_Transact_Categories", "Transact", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BankTestModel", Name="sysdiagrams")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class sysdiagrams : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new sysdiagrams object.
        /// </summary>
        /// <param name="name">Initial value of the name property.</param>
        /// <param name="principal_id">Initial value of the principal_id property.</param>
        /// <param name="diagram_id">Initial value of the diagram_id property.</param>
        public static sysdiagrams Createsysdiagrams(global::System.String name, global::System.Int32 principal_id, global::System.Int32 diagram_id)
        {
            sysdiagrams sysdiagrams = new sysdiagrams();
            sysdiagrams.name = name;
            sysdiagrams.principal_id = principal_id;
            sysdiagrams.diagram_id = diagram_id;
            return sysdiagrams;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
                OnnameChanging(value);
                ReportPropertyChanging("name");
                _name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 principal_id
        {
            get
            {
                return _principal_id;
            }
            set
            {
                Onprincipal_idChanging(value);
                ReportPropertyChanging("principal_id");
                _principal_id = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("principal_id");
                Onprincipal_idChanged();
            }
        }
        private global::System.Int32 _principal_id;
        partial void Onprincipal_idChanging(global::System.Int32 value);
        partial void Onprincipal_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 diagram_id
        {
            get
            {
                return _diagram_id;
            }
            set
            {
                if (_diagram_id != value)
                {
                    Ondiagram_idChanging(value);
                    ReportPropertyChanging("diagram_id");
                    _diagram_id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("diagram_id");
                    Ondiagram_idChanged();
                }
            }
        }
        private global::System.Int32 _diagram_id;
        partial void Ondiagram_idChanging(global::System.Int32 value);
        partial void Ondiagram_idChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> version
        {
            get
            {
                return _version;
            }
            set
            {
                OnversionChanging(value);
                ReportPropertyChanging("version");
                _version = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("version");
                OnversionChanged();
            }
        }
        private Nullable<global::System.Int32> _version;
        partial void OnversionChanging(Nullable<global::System.Int32> value);
        partial void OnversionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.Byte[] definition
        {
            get
            {
                return StructuralObject.GetValidValue(_definition);
            }
            set
            {
                OndefinitionChanging(value);
                ReportPropertyChanging("definition");
                _definition = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("definition");
                OndefinitionChanged();
            }
        }
        private global::System.Byte[] _definition;
        partial void OndefinitionChanging(global::System.Byte[] value);
        partial void OndefinitionChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BankTestModel", Name="Transact")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Transact : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Transact object.
        /// </summary>
        /// <param name="reference">Initial value of the Reference property.</param>
        /// <param name="account">Initial value of the Account property.</param>
        /// <param name="amount">Initial value of the Amount property.</param>
        public static Transact CreateTransact(global::System.String reference, global::System.String account, global::System.Decimal amount)
        {
            Transact transact = new Transact();
            transact.Reference = reference;
            transact.Account = account;
            transact.Amount = amount;
            return transact;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Reference
        {
            get
            {
                return _Reference;
            }
            set
            {
                if (_Reference != value)
                {
                    OnReferenceChanging(value);
                    ReportPropertyChanging("Reference");
                    _Reference = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Reference");
                    OnReferenceChanged();
                }
            }
        }
        private global::System.String _Reference;
        partial void OnReferenceChanging(global::System.String value);
        partial void OnReferenceChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Account
        {
            get
            {
                return _Account;
            }
            set
            {
                if (_Account != value)
                {
                    OnAccountChanging(value);
                    ReportPropertyChanging("Account");
                    _Account = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Account");
                    OnAccountChanged();
                }
            }
        }
        private global::System.String _Account;
        partial void OnAccountChanging(global::System.String value);
        partial void OnAccountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                OnAmountChanging(value);
                ReportPropertyChanging("Amount");
                _Amount = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Amount");
                OnAmountChanged();
            }
        }
        private global::System.Decimal _Amount;
        partial void OnAmountChanging(global::System.Decimal value);
        partial void OnAmountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Destinations
        {
            get
            {
                return _Destinations;
            }
            set
            {
                OnDestinationsChanging(value);
                ReportPropertyChanging("Destinations");
                _Destinations = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Destinations");
                OnDestinationsChanged();
            }
        }
        private global::System.String _Destinations;
        partial void OnDestinationsChanging(global::System.String value);
        partial void OnDestinationsChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Category
        {
            get
            {
                return _Category;
            }
            set
            {
                OnCategoryChanging(value);
                ReportPropertyChanging("Category");
                _Category = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Category");
                OnCategoryChanged();
            }
        }
        private Nullable<global::System.Int32> _Category;
        partial void OnCategoryChanging(Nullable<global::System.Int32> value);
        partial void OnCategoryChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> Date
        {
            get
            {
                return _Date;
            }
            set
            {
                OnDateChanging(value);
                ReportPropertyChanging("Date");
                _Date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Date");
                OnDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _Date;
        partial void OnDateChanging(Nullable<global::System.DateTime> value);
        partial void OnDateChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("BankTestModel", "FK_Transact_Categories", "Categories")]
        public Categories Categories
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Categories>("BankTestModel.FK_Transact_Categories", "Categories").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Categories>("BankTestModel.FK_Transact_Categories", "Categories").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Categories> CategoriesReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Categories>("BankTestModel.FK_Transact_Categories", "Categories");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Categories>("BankTestModel.FK_Transact_Categories", "Categories", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BankTestModel", Name="TransactionsSelectorView")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TransactionsSelectorView : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new TransactionsSelectorView object.
        /// </summary>
        /// <param name="reference">Initial value of the Reference property.</param>
        /// <param name="amount">Initial value of the Amount property.</param>
        /// <param name="account">Initial value of the Account property.</param>
        public static TransactionsSelectorView CreateTransactionsSelectorView(global::System.String reference, global::System.Decimal amount, global::System.String account)
        {
            TransactionsSelectorView transactionsSelectorView = new TransactionsSelectorView();
            transactionsSelectorView.Reference = reference;
            transactionsSelectorView.Amount = amount;
            transactionsSelectorView.Account = account;
            return transactionsSelectorView;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Reference
        {
            get
            {
                return _Reference;
            }
            set
            {
                if (_Reference != value)
                {
                    OnReferenceChanging(value);
                    ReportPropertyChanging("Reference");
                    _Reference = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Reference");
                    OnReferenceChanged();
                }
            }
        }
        private global::System.String _Reference;
        partial void OnReferenceChanging(global::System.String value);
        partial void OnReferenceChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                OnAmountChanging(value);
                ReportPropertyChanging("Amount");
                _Amount = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Amount");
                OnAmountChanged();
            }
        }
        private global::System.Decimal _Amount;
        partial void OnAmountChanging(global::System.Decimal value);
        partial void OnAmountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Destinations
        {
            get
            {
                return _Destinations;
            }
            set
            {
                OnDestinationsChanging(value);
                ReportPropertyChanging("Destinations");
                _Destinations = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Destinations");
                OnDestinationsChanged();
            }
        }
        private global::System.String _Destinations;
        partial void OnDestinationsChanging(global::System.String value);
        partial void OnDestinationsChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> Date
        {
            get
            {
                return _Date;
            }
            set
            {
                OnDateChanging(value);
                ReportPropertyChanging("Date");
                _Date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Date");
                OnDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _Date;
        partial void OnDateChanging(Nullable<global::System.DateTime> value);
        partial void OnDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Account
        {
            get
            {
                return _Account;
            }
            set
            {
                if (_Account != value)
                {
                    OnAccountChanging(value);
                    ReportPropertyChanging("Account");
                    _Account = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Account");
                    OnAccountChanged();
                }
            }
        }
        private global::System.String _Account;
        partial void OnAccountChanging(global::System.String value);
        partial void OnAccountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Category
        {
            get
            {
                return _Category;
            }
            set
            {
                OnCategoryChanging(value);
                ReportPropertyChanging("Category");
                _Category = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Category");
                OnCategoryChanged();
            }
        }
        private Nullable<global::System.Int32> _Category;
        partial void OnCategoryChanging(Nullable<global::System.Int32> value);
        partial void OnCategoryChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Color
        {
            get
            {
                return _Color;
            }
            set
            {
                OnColorChanging(value);
                ReportPropertyChanging("Color");
                _Color = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Color");
                OnColorChanged();
            }
        }
        private global::System.String _Color;
        partial void OnColorChanging(global::System.String value);
        partial void OnColorChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BankTestModel", Name="ViewCategoriesEditor")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class ViewCategoriesEditor : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new ViewCategoriesEditor object.
        /// </summary>
        /// <param name="name">Initial value of the Name property.</param>
        public static ViewCategoriesEditor CreateViewCategoriesEditor(global::System.String name)
        {
            ViewCategoriesEditor viewCategoriesEditor = new ViewCategoriesEditor();
            viewCategoriesEditor.Name = name;
            return viewCategoriesEditor;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (_Name != value)
                {
                    OnNameChanging(value);
                    ReportPropertyChanging("Name");
                    _Name = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("Name");
                    OnNameChanged();
                }
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Color
        {
            get
            {
                return _Color;
            }
            set
            {
                OnColorChanging(value);
                ReportPropertyChanging("Color");
                _Color = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Color");
                OnColorChanged();
            }
        }
        private global::System.String _Color;
        partial void OnColorChanging(global::System.String value);
        partial void OnColorChanged();

        #endregion
    
    }

    #endregion
    
}
