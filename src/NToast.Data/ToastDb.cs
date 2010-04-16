﻿
namespace NToast.Data {

#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



public partial class ToastDb : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertMeta(Meta instance);
  partial void UpdateMeta(Meta instance);
  partial void DeleteMeta(Meta instance);
  partial void InsertUser(User instance);
  partial void UpdateUser(User instance);
  partial void DeleteUser(User instance);
  #endregion
	
	public ToastDb(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public ToastDb(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public ToastDb(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public ToastDb(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<Meta> Metas
	{
		get
		{
			return this.GetTable<Meta>();
		}
	}
	
	public System.Data.Linq.Table<User> Users
	{
		get
		{
			return this.GetTable<User>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute()]
public partial class Meta : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private string _Key;
	
	private string _Value;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnKeyChanging(string value);
    partial void OnKeyChanged();
    partial void OnValueChanging(string value);
    partial void OnValueChanged();
    #endregion
	
	public Meta()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Key", DbType="NVarChar(100) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
	public string Key
	{
		get
		{
			return this._Key;
		}
		set
		{
			if ((this._Key != value))
			{
				this.OnKeyChanging(value);
				this.SendPropertyChanging();
				this._Key = value;
				this.SendPropertyChanged("Key");
				this.OnKeyChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value", DbType="NText", UpdateCheck=UpdateCheck.Never)]
	public string Value
	{
		get
		{
			return this._Value;
		}
		set
		{
			if ((this._Value != value))
			{
				this.OnValueChanging(value);
				this.SendPropertyChanging();
				this._Value = value;
				this.SendPropertyChanged("Value");
				this.OnValueChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="Users")]
public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private System.Guid _UserId;
	
	private string _Username;
	
	private string _PasswordHash;
	
	private string _Source;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(System.Guid value);
    partial void OnUserIdChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordHashChanging(string value);
    partial void OnPasswordHashChanged();
    partial void OnSourceChanging(string value);
    partial void OnSourceChanged();
    #endregion
	
	public User()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
	public System.Guid UserId
	{
		get
		{
			return this._UserId;
		}
		set
		{
			if ((this._UserId != value))
			{
				this.OnUserIdChanging(value);
				this.SendPropertyChanging();
				this._UserId = value;
				this.SendPropertyChanged("UserId");
				this.OnUserIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
	public string Username
	{
		get
		{
			return this._Username;
		}
		set
		{
			if ((this._Username != value))
			{
				this.OnUsernameChanging(value);
				this.SendPropertyChanging();
				this._Username = value;
				this.SendPropertyChanged("Username");
				this.OnUsernameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PasswordHash", DbType="NVarChar(100)")]
	public string PasswordHash
	{
		get
		{
			return this._PasswordHash;
		}
		set
		{
			if ((this._PasswordHash != value))
			{
				this.OnPasswordHashChanging(value);
				this.SendPropertyChanging();
				this._PasswordHash = value;
				this.SendPropertyChanged("PasswordHash");
				this.OnPasswordHashChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Source", DbType="NVarChar(100)")]
	public string Source
	{
		get
		{
			return this._Source;
		}
		set
		{
			if ((this._Source != value))
			{
				this.OnSourceChanging(value);
				this.SendPropertyChanging();
				this._Source = value;
				this.SendPropertyChanged("Source");
				this.OnSourceChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
#pragma warning restore 1591


}