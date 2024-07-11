﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
#region Метаданные связи EDM

[assembly: EdmRelationshipAttribute("ModelFirst", "UserComments", "User", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(Lab9_test.User), "Comments", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(Lab9_test.Comments))]

#endregion

namespace Lab9_test
{
    #region Контексты
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    public partial class ModelFirstContainer : ObjectContext
    {
        #region Конструкторы
    
        /// <summary>
        /// Инициализирует новый объект ModelFirstContainer, используя строку соединения из раздела "ModelFirstContainer" файла конфигурации приложения.
        /// </summary>
        public ModelFirstContainer() : base("name=ModelFirstContainer", "ModelFirstContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта ModelFirstContainer.
        /// </summary>
        public ModelFirstContainer(string connectionString) : base(connectionString, "ModelFirstContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Инициализация нового объекта ModelFirstContainer.
        /// </summary>
        public ModelFirstContainer(EntityConnection connection) : base(connection, "ModelFirstContainer")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Разделяемые методы
    
        partial void OnContextCreated();
    
        #endregion
    
        #region Свойства ObjectSet
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        public ObjectSet<User> UserSet
        {
            get
            {
                if ((_UserSet == null))
                {
                    _UserSet = base.CreateObjectSet<User>("UserSet");
                }
                return _UserSet;
            }
        }
        private ObjectSet<User> _UserSet;
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        public ObjectSet<Comments> CommentsSet
        {
            get
            {
                if ((_CommentsSet == null))
                {
                    _CommentsSet = base.CreateObjectSet<Comments>("CommentsSet");
                }
                return _CommentsSet;
            }
        }
        private ObjectSet<Comments> _CommentsSet;

        #endregion

        #region Методы AddTo
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet UserSet. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToUserSet(User user)
        {
            base.AddObject("UserSet", user);
        }
    
        /// <summary>
        /// Устаревший метод для добавления новых объектов в набор EntitySet CommentsSet. Взамен можно использовать метод .Add связанного свойства ObjectSet&lt;T&gt;.
        /// </summary>
        public void AddToCommentsSet(Comments comments)
        {
            base.AddObject("CommentsSet", comments);
        }

        #endregion

    }

    #endregion

    #region Сущности
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ModelFirst", Name="Comments")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Comments : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта Comments.
        /// </summary>
        /// <param name="id">Исходное значение свойства Id.</param>
        /// <param name="text">Исходное значение свойства Text.</param>
        /// <param name="dateTime">Исходное значение свойства DateTime.</param>
        /// <param name="userId">Исходное значение свойства UserId.</param>
        public static Comments CreateComments(global::System.Int32 id, global::System.String text, global::System.DateTime dateTime, global::System.Int32 userId)
        {
            Comments comments = new Comments();
            comments.Id = id;
            comments.Text = text;
            comments.DateTime = dateTime;
            comments.UserId = userId;
            return comments;
        }

        #endregion

        #region Простые свойства
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value, "Id");
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Text
        {
            get
            {
                return _Text;
            }
            set
            {
                OnTextChanging(value);
                ReportPropertyChanging("Text");
                _Text = StructuralObject.SetValidValue(value, false, "Text");
                ReportPropertyChanged("Text");
                OnTextChanged();
            }
        }
        private global::System.String _Text;
        partial void OnTextChanging(global::System.String value);
        partial void OnTextChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DateTime
        {
            get
            {
                return _DateTime;
            }
            set
            {
                OnDateTimeChanging(value);
                ReportPropertyChanging("DateTime");
                _DateTime = StructuralObject.SetValidValue(value, "DateTime");
                ReportPropertyChanged("DateTime");
                OnDateTimeChanged();
            }
        }
        private global::System.DateTime _DateTime;
        partial void OnDateTimeChanging(global::System.DateTime value);
        partial void OnDateTimeChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                OnUserIdChanging(value);
                ReportPropertyChanging("UserId");
                _UserId = StructuralObject.SetValidValue(value, "UserId");
                ReportPropertyChanged("UserId");
                OnUserIdChanged();
            }
        }
        private global::System.Int32 _UserId;
        partial void OnUserIdChanging(global::System.Int32 value);
        partial void OnUserIdChanged();

        #endregion

        #region Свойства навигации
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ModelFirst", "UserComments", "User")]
        public User User
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("ModelFirst.UserComments", "User").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("ModelFirst.UserComments", "User").Value = value;
            }
        }
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<User> UserReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<User>("ModelFirst.UserComments", "User");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<User>("ModelFirst.UserComments", "User", value);
                }
            }
        }

        #endregion

    }
    
    /// <summary>
    /// Нет доступной документации по метаданным.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="ModelFirst", Name="User")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class User : EntityObject
    {
        #region Фабричный метод
    
        /// <summary>
        /// Создание нового объекта User.
        /// </summary>
        /// <param name="id">Исходное значение свойства Id.</param>
        /// <param name="login">Исходное значение свойства Login.</param>
        /// <param name="password">Исходное значение свойства Password.</param>
        public static User CreateUser(global::System.Int32 id, global::System.String login, global::System.String password)
        {
            User user = new User();
            user.Id = id;
            user.Login = login;
            user.Password = password;
            return user;
        }

        #endregion

        #region Простые свойства
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value, "Id");
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Login
        {
            get
            {
                return _Login;
            }
            set
            {
                OnLoginChanging(value);
                ReportPropertyChanging("Login");
                _Login = StructuralObject.SetValidValue(value, false, "Login");
                ReportPropertyChanged("Login");
                OnLoginChanged();
            }
        }
        private global::System.String _Login;
        partial void OnLoginChanging(global::System.String value);
        partial void OnLoginChanged();
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                OnPasswordChanging(value);
                ReportPropertyChanging("Password");
                _Password = StructuralObject.SetValidValue(value, false, "Password");
                ReportPropertyChanged("Password");
                OnPasswordChanged();
            }
        }
        private global::System.String _Password;
        partial void OnPasswordChanging(global::System.String value);
        partial void OnPasswordChanged();

        #endregion

        #region Свойства навигации
    
        /// <summary>
        /// Нет доступной документации по метаданным.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("ModelFirst", "UserComments", "Comments")]
        public EntityCollection<Comments> Comments
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Comments>("ModelFirst.UserComments", "Comments");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Comments>("ModelFirst.UserComments", "Comments", value);
                }
            }
        }

        #endregion

    }

    #endregion

}