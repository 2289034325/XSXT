﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tool
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="JCSJ")]
	public partial class JCSJDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 可扩展性方法定义
    partial void OnCreated();
    partial void InsertTUser(TUser instance);
    partial void UpdateTUser(TUser instance);
    partial void DeleteTUser(TUser instance);
    partial void InsertTTiaoma(TTiaoma instance);
    partial void UpdateTTiaoma(TTiaoma instance);
    partial void DeleteTTiaoma(TTiaoma instance);
    partial void InsertTKuanhao(TKuanhao instance);
    partial void UpdateTKuanhao(TKuanhao instance);
    partial void DeleteTKuanhao(TKuanhao instance);
    partial void InsertTGongyingshang(TGongyingshang instance);
    partial void UpdateTGongyingshang(TGongyingshang instance);
    partial void DeleteTGongyingshang(TGongyingshang instance);
    #endregion
		
		public JCSJDataContext() : 
				base(global::Tool.Properties.Settings.Default.JCSJConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public JCSJDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public JCSJDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public JCSJDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public JCSJDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TUser> TUser
		{
			get
			{
				return this.GetTable<TUser>();
			}
		}
		
		public System.Data.Linq.Table<TTiaoma> TTiaoma
		{
			get
			{
				return this.GetTable<TTiaoma>();
			}
		}
		
		public System.Data.Linq.Table<TKuanhao> TKuanhao
		{
			get
			{
				return this.GetTable<TKuanhao>();
			}
		}
		
		public System.Data.Linq.Table<TGongyingshang> TGongyingshang
		{
			get
			{
				return this.GetTable<TGongyingshang>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TUser")]
	public partial class TUser : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _dengluming;
		
		private string _mima;
		
		private string _yonghuming;
		
		private byte _juese;
		
		private string _beizhu;
		
		private string _zhuangtai;
		
		private System.DateTime _charushijian;
		
		private System.DateTime _xiugaishijian;
		
		private EntitySet<TTiaoma> _TTiaoma;
		
		private EntitySet<TKuanhao> _TKuanhao;
		
		private EntitySet<TGongyingshang> _TGongyingshang;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OndenglumingChanging(string value);
    partial void OndenglumingChanged();
    partial void OnmimaChanging(string value);
    partial void OnmimaChanged();
    partial void OnyonghumingChanging(string value);
    partial void OnyonghumingChanged();
    partial void OnjueseChanging(byte value);
    partial void OnjueseChanged();
    partial void OnbeizhuChanging(string value);
    partial void OnbeizhuChanged();
    partial void OnzhuangtaiChanging(string value);
    partial void OnzhuangtaiChanged();
    partial void OncharushijianChanging(System.DateTime value);
    partial void OncharushijianChanged();
    partial void OnxiugaishijianChanging(System.DateTime value);
    partial void OnxiugaishijianChanged();
    #endregion
		
		public TUser()
		{
			this._TTiaoma = new EntitySet<TTiaoma>(new Action<TTiaoma>(this.attach_TTiaoma), new Action<TTiaoma>(this.detach_TTiaoma));
			this._TKuanhao = new EntitySet<TKuanhao>(new Action<TKuanhao>(this.attach_TKuanhao), new Action<TKuanhao>(this.detach_TKuanhao));
			this._TGongyingshang = new EntitySet<TGongyingshang>(new Action<TGongyingshang>(this.attach_TGongyingshang), new Action<TGongyingshang>(this.detach_TGongyingshang));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dengluming", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string dengluming
		{
			get
			{
				return this._dengluming;
			}
			set
			{
				if ((this._dengluming != value))
				{
					this.OndenglumingChanging(value);
					this.SendPropertyChanging();
					this._dengluming = value;
					this.SendPropertyChanged("dengluming");
					this.OndenglumingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mima", DbType="VarChar(16) NOT NULL", CanBeNull=false)]
		public string mima
		{
			get
			{
				return this._mima;
			}
			set
			{
				if ((this._mima != value))
				{
					this.OnmimaChanging(value);
					this.SendPropertyChanging();
					this._mima = value;
					this.SendPropertyChanged("mima");
					this.OnmimaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_yonghuming", DbType="NVarChar(5) NOT NULL", CanBeNull=false)]
		public string yonghuming
		{
			get
			{
				return this._yonghuming;
			}
			set
			{
				if ((this._yonghuming != value))
				{
					this.OnyonghumingChanging(value);
					this.SendPropertyChanging();
					this._yonghuming = value;
					this.SendPropertyChanged("yonghuming");
					this.OnyonghumingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_juese", DbType="TinyInt NOT NULL")]
		public byte juese
		{
			get
			{
				return this._juese;
			}
			set
			{
				if ((this._juese != value))
				{
					this.OnjueseChanging(value);
					this.SendPropertyChanging();
					this._juese = value;
					this.SendPropertyChanged("juese");
					this.OnjueseChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_beizhu", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string beizhu
		{
			get
			{
				return this._beizhu;
			}
			set
			{
				if ((this._beizhu != value))
				{
					this.OnbeizhuChanging(value);
					this.SendPropertyChanging();
					this._beizhu = value;
					this.SendPropertyChanged("beizhu");
					this.OnbeizhuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_zhuangtai", DbType="NChar(10) NOT NULL", CanBeNull=false)]
		public string zhuangtai
		{
			get
			{
				return this._zhuangtai;
			}
			set
			{
				if ((this._zhuangtai != value))
				{
					this.OnzhuangtaiChanging(value);
					this.SendPropertyChanging();
					this._zhuangtai = value;
					this.SendPropertyChanged("zhuangtai");
					this.OnzhuangtaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_charushijian", DbType="DateTime NOT NULL")]
		public System.DateTime charushijian
		{
			get
			{
				return this._charushijian;
			}
			set
			{
				if ((this._charushijian != value))
				{
					this.OncharushijianChanging(value);
					this.SendPropertyChanging();
					this._charushijian = value;
					this.SendPropertyChanged("charushijian");
					this.OncharushijianChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_xiugaishijian", DbType="DateTime NOT NULL")]
		public System.DateTime xiugaishijian
		{
			get
			{
				return this._xiugaishijian;
			}
			set
			{
				if ((this._xiugaishijian != value))
				{
					this.OnxiugaishijianChanging(value);
					this.SendPropertyChanging();
					this._xiugaishijian = value;
					this.SendPropertyChanged("xiugaishijian");
					this.OnxiugaishijianChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TUser_TTiaoma", Storage="_TTiaoma", ThisKey="id", OtherKey="caozuorenid")]
		public EntitySet<TTiaoma> TTiaoma
		{
			get
			{
				return this._TTiaoma;
			}
			set
			{
				this._TTiaoma.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TUser_TKuanhao", Storage="_TKuanhao", ThisKey="id", OtherKey="caozuorenid")]
		public EntitySet<TKuanhao> TKuanhao
		{
			get
			{
				return this._TKuanhao;
			}
			set
			{
				this._TKuanhao.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TUser_TGongyingshang", Storage="_TGongyingshang", ThisKey="id", OtherKey="caozuorenid")]
		public EntitySet<TGongyingshang> TGongyingshang
		{
			get
			{
				return this._TGongyingshang;
			}
			set
			{
				this._TGongyingshang.Assign(value);
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
		
		private void attach_TTiaoma(TTiaoma entity)
		{
			this.SendPropertyChanging();
			entity.TUser = this;
		}
		
		private void detach_TTiaoma(TTiaoma entity)
		{
			this.SendPropertyChanging();
			entity.TUser = null;
		}
		
		private void attach_TKuanhao(TKuanhao entity)
		{
			this.SendPropertyChanging();
			entity.TUser = this;
		}
		
		private void detach_TKuanhao(TKuanhao entity)
		{
			this.SendPropertyChanging();
			entity.TUser = null;
		}
		
		private void attach_TGongyingshang(TGongyingshang entity)
		{
			this.SendPropertyChanging();
			entity.TUser = this;
		}
		
		private void detach_TGongyingshang(TGongyingshang entity)
		{
			this.SendPropertyChanging();
			entity.TUser = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TTiaoma")]
	public partial class TTiaoma : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _tiaoma;
		
		private string _yanse;
		
		private string _chima;
		
		private decimal _jinjia;
		
		private decimal _shoujia;
		
		private int _kuanhaoid;
		
		private int _gysid;
		
		private string _gyskuanhao;
		
		private string _maishou;
		
		private int _caozuorenid;
		
		private System.DateTime _charushijian;
		
		private System.DateTime _xiugaishijian;
		
		private EntityRef<TUser> _TUser;
		
		private EntityRef<TKuanhao> _TKuanhao;
		
		private EntityRef<TGongyingshang> _TGongyingshang;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OntiaomaChanging(string value);
    partial void OntiaomaChanged();
    partial void OnyanseChanging(string value);
    partial void OnyanseChanged();
    partial void OnchimaChanging(string value);
    partial void OnchimaChanged();
    partial void OnjinjiaChanging(decimal value);
    partial void OnjinjiaChanged();
    partial void OnshoujiaChanging(decimal value);
    partial void OnshoujiaChanged();
    partial void OnkuanhaoidChanging(int value);
    partial void OnkuanhaoidChanged();
    partial void OngysidChanging(int value);
    partial void OngysidChanged();
    partial void OngyskuanhaoChanging(string value);
    partial void OngyskuanhaoChanged();
    partial void OnmaishouChanging(string value);
    partial void OnmaishouChanged();
    partial void OncaozuorenidChanging(int value);
    partial void OncaozuorenidChanged();
    partial void OncharushijianChanging(System.DateTime value);
    partial void OncharushijianChanged();
    partial void OnxiugaishijianChanging(System.DateTime value);
    partial void OnxiugaishijianChanged();
    #endregion
		
		public TTiaoma()
		{
			this._TUser = default(EntityRef<TUser>);
			this._TKuanhao = default(EntityRef<TKuanhao>);
			this._TGongyingshang = default(EntityRef<TGongyingshang>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tiaoma", DbType="VarChar(13) NOT NULL", CanBeNull=false)]
		public string tiaoma
		{
			get
			{
				return this._tiaoma;
			}
			set
			{
				if ((this._tiaoma != value))
				{
					this.OntiaomaChanging(value);
					this.SendPropertyChanging();
					this._tiaoma = value;
					this.SendPropertyChanged("tiaoma");
					this.OntiaomaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_yanse", DbType="NVarChar(5) NOT NULL", CanBeNull=false)]
		public string yanse
		{
			get
			{
				return this._yanse;
			}
			set
			{
				if ((this._yanse != value))
				{
					this.OnyanseChanging(value);
					this.SendPropertyChanging();
					this._yanse = value;
					this.SendPropertyChanged("yanse");
					this.OnyanseChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_chima", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string chima
		{
			get
			{
				return this._chima;
			}
			set
			{
				if ((this._chima != value))
				{
					this.OnchimaChanging(value);
					this.SendPropertyChanging();
					this._chima = value;
					this.SendPropertyChanged("chima");
					this.OnchimaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_jinjia", DbType="Decimal(6,2) NOT NULL")]
		public decimal jinjia
		{
			get
			{
				return this._jinjia;
			}
			set
			{
				if ((this._jinjia != value))
				{
					this.OnjinjiaChanging(value);
					this.SendPropertyChanging();
					this._jinjia = value;
					this.SendPropertyChanged("jinjia");
					this.OnjinjiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_shoujia", DbType="Decimal(6,2) NOT NULL")]
		public decimal shoujia
		{
			get
			{
				return this._shoujia;
			}
			set
			{
				if ((this._shoujia != value))
				{
					this.OnshoujiaChanging(value);
					this.SendPropertyChanging();
					this._shoujia = value;
					this.SendPropertyChanged("shoujia");
					this.OnshoujiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kuanhaoid", DbType="Int NOT NULL")]
		public int kuanhaoid
		{
			get
			{
				return this._kuanhaoid;
			}
			set
			{
				if ((this._kuanhaoid != value))
				{
					if (this._TKuanhao.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnkuanhaoidChanging(value);
					this.SendPropertyChanging();
					this._kuanhaoid = value;
					this.SendPropertyChanged("kuanhaoid");
					this.OnkuanhaoidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gysid", DbType="Int NOT NULL")]
		public int gysid
		{
			get
			{
				return this._gysid;
			}
			set
			{
				if ((this._gysid != value))
				{
					if (this._TGongyingshang.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OngysidChanging(value);
					this.SendPropertyChanging();
					this._gysid = value;
					this.SendPropertyChanged("gysid");
					this.OngysidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gyskuanhao", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string gyskuanhao
		{
			get
			{
				return this._gyskuanhao;
			}
			set
			{
				if ((this._gyskuanhao != value))
				{
					this.OngyskuanhaoChanging(value);
					this.SendPropertyChanging();
					this._gyskuanhao = value;
					this.SendPropertyChanged("gyskuanhao");
					this.OngyskuanhaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maishou", DbType="NVarChar(5) NOT NULL", CanBeNull=false)]
		public string maishou
		{
			get
			{
				return this._maishou;
			}
			set
			{
				if ((this._maishou != value))
				{
					this.OnmaishouChanging(value);
					this.SendPropertyChanging();
					this._maishou = value;
					this.SendPropertyChanged("maishou");
					this.OnmaishouChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_caozuorenid", DbType="Int NOT NULL")]
		public int caozuorenid
		{
			get
			{
				return this._caozuorenid;
			}
			set
			{
				if ((this._caozuorenid != value))
				{
					if (this._TUser.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OncaozuorenidChanging(value);
					this.SendPropertyChanging();
					this._caozuorenid = value;
					this.SendPropertyChanged("caozuorenid");
					this.OncaozuorenidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_charushijian", DbType="DateTime NOT NULL")]
		public System.DateTime charushijian
		{
			get
			{
				return this._charushijian;
			}
			set
			{
				if ((this._charushijian != value))
				{
					this.OncharushijianChanging(value);
					this.SendPropertyChanging();
					this._charushijian = value;
					this.SendPropertyChanged("charushijian");
					this.OncharushijianChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_xiugaishijian", DbType="DateTime NOT NULL")]
		public System.DateTime xiugaishijian
		{
			get
			{
				return this._xiugaishijian;
			}
			set
			{
				if ((this._xiugaishijian != value))
				{
					this.OnxiugaishijianChanging(value);
					this.SendPropertyChanging();
					this._xiugaishijian = value;
					this.SendPropertyChanged("xiugaishijian");
					this.OnxiugaishijianChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TUser_TTiaoma", Storage="_TUser", ThisKey="caozuorenid", OtherKey="id", IsForeignKey=true)]
		public TUser TUser
		{
			get
			{
				return this._TUser.Entity;
			}
			set
			{
				TUser previousValue = this._TUser.Entity;
				if (((previousValue != value) 
							|| (this._TUser.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TUser.Entity = null;
						previousValue.TTiaoma.Remove(this);
					}
					this._TUser.Entity = value;
					if ((value != null))
					{
						value.TTiaoma.Add(this);
						this._caozuorenid = value.id;
					}
					else
					{
						this._caozuorenid = default(int);
					}
					this.SendPropertyChanged("TUser");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TKuanhao_TTiaoma", Storage="_TKuanhao", ThisKey="kuanhaoid", OtherKey="id", IsForeignKey=true)]
		public TKuanhao TKuanhao
		{
			get
			{
				return this._TKuanhao.Entity;
			}
			set
			{
				TKuanhao previousValue = this._TKuanhao.Entity;
				if (((previousValue != value) 
							|| (this._TKuanhao.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TKuanhao.Entity = null;
						previousValue.TTiaoma.Remove(this);
					}
					this._TKuanhao.Entity = value;
					if ((value != null))
					{
						value.TTiaoma.Add(this);
						this._kuanhaoid = value.id;
					}
					else
					{
						this._kuanhaoid = default(int);
					}
					this.SendPropertyChanged("TKuanhao");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TGongyingshang_TTiaoma", Storage="_TGongyingshang", ThisKey="gysid", OtherKey="id", IsForeignKey=true)]
		public TGongyingshang TGongyingshang
		{
			get
			{
				return this._TGongyingshang.Entity;
			}
			set
			{
				TGongyingshang previousValue = this._TGongyingshang.Entity;
				if (((previousValue != value) 
							|| (this._TGongyingshang.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TGongyingshang.Entity = null;
						previousValue.TTiaoma.Remove(this);
					}
					this._TGongyingshang.Entity = value;
					if ((value != null))
					{
						value.TTiaoma.Add(this);
						this._gysid = value.id;
					}
					else
					{
						this._gysid = default(int);
					}
					this.SendPropertyChanged("TGongyingshang");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TKuanhao")]
	public partial class TKuanhao : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _kuanhao;
		
		private byte _leixing;
		
		private string _pinming;
		
		private string _beizhu;
		
		private int _caozuorenid;
		
		private System.DateTime _charushijian;
		
		private System.DateTime _xiugaishijian;
		
		private EntitySet<TTiaoma> _TTiaoma;
		
		private EntityRef<TUser> _TUser;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnkuanhaoChanging(string value);
    partial void OnkuanhaoChanged();
    partial void OnleixingChanging(byte value);
    partial void OnleixingChanged();
    partial void OnpinmingChanging(string value);
    partial void OnpinmingChanged();
    partial void OnbeizhuChanging(string value);
    partial void OnbeizhuChanged();
    partial void OncaozuorenidChanging(int value);
    partial void OncaozuorenidChanged();
    partial void OncharushijianChanging(System.DateTime value);
    partial void OncharushijianChanged();
    partial void OnxiugaishijianChanging(System.DateTime value);
    partial void OnxiugaishijianChanged();
    #endregion
		
		public TKuanhao()
		{
			this._TTiaoma = new EntitySet<TTiaoma>(new Action<TTiaoma>(this.attach_TTiaoma), new Action<TTiaoma>(this.detach_TTiaoma));
			this._TUser = default(EntityRef<TUser>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kuanhao", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string kuanhao
		{
			get
			{
				return this._kuanhao;
			}
			set
			{
				if ((this._kuanhao != value))
				{
					this.OnkuanhaoChanging(value);
					this.SendPropertyChanging();
					this._kuanhao = value;
					this.SendPropertyChanged("kuanhao");
					this.OnkuanhaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_leixing", DbType="TinyInt NOT NULL")]
		public byte leixing
		{
			get
			{
				return this._leixing;
			}
			set
			{
				if ((this._leixing != value))
				{
					this.OnleixingChanging(value);
					this.SendPropertyChanging();
					this._leixing = value;
					this.SendPropertyChanged("leixing");
					this.OnleixingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pinming", DbType="NVarChar(6) NOT NULL", CanBeNull=false)]
		public string pinming
		{
			get
			{
				return this._pinming;
			}
			set
			{
				if ((this._pinming != value))
				{
					this.OnpinmingChanging(value);
					this.SendPropertyChanging();
					this._pinming = value;
					this.SendPropertyChanged("pinming");
					this.OnpinmingChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_beizhu", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string beizhu
		{
			get
			{
				return this._beizhu;
			}
			set
			{
				if ((this._beizhu != value))
				{
					this.OnbeizhuChanging(value);
					this.SendPropertyChanging();
					this._beizhu = value;
					this.SendPropertyChanged("beizhu");
					this.OnbeizhuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_caozuorenid", DbType="Int NOT NULL")]
		public int caozuorenid
		{
			get
			{
				return this._caozuorenid;
			}
			set
			{
				if ((this._caozuorenid != value))
				{
					if (this._TUser.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OncaozuorenidChanging(value);
					this.SendPropertyChanging();
					this._caozuorenid = value;
					this.SendPropertyChanged("caozuorenid");
					this.OncaozuorenidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_charushijian", DbType="DateTime NOT NULL")]
		public System.DateTime charushijian
		{
			get
			{
				return this._charushijian;
			}
			set
			{
				if ((this._charushijian != value))
				{
					this.OncharushijianChanging(value);
					this.SendPropertyChanging();
					this._charushijian = value;
					this.SendPropertyChanged("charushijian");
					this.OncharushijianChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_xiugaishijian", DbType="DateTime NOT NULL")]
		public System.DateTime xiugaishijian
		{
			get
			{
				return this._xiugaishijian;
			}
			set
			{
				if ((this._xiugaishijian != value))
				{
					this.OnxiugaishijianChanging(value);
					this.SendPropertyChanging();
					this._xiugaishijian = value;
					this.SendPropertyChanged("xiugaishijian");
					this.OnxiugaishijianChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TKuanhao_TTiaoma", Storage="_TTiaoma", ThisKey="id", OtherKey="kuanhaoid")]
		public EntitySet<TTiaoma> TTiaoma
		{
			get
			{
				return this._TTiaoma;
			}
			set
			{
				this._TTiaoma.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TUser_TKuanhao", Storage="_TUser", ThisKey="caozuorenid", OtherKey="id", IsForeignKey=true)]
		public TUser TUser
		{
			get
			{
				return this._TUser.Entity;
			}
			set
			{
				TUser previousValue = this._TUser.Entity;
				if (((previousValue != value) 
							|| (this._TUser.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TUser.Entity = null;
						previousValue.TKuanhao.Remove(this);
					}
					this._TUser.Entity = value;
					if ((value != null))
					{
						value.TKuanhao.Add(this);
						this._caozuorenid = value.id;
					}
					else
					{
						this._caozuorenid = default(int);
					}
					this.SendPropertyChanged("TUser");
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
		
		private void attach_TTiaoma(TTiaoma entity)
		{
			this.SendPropertyChanging();
			entity.TKuanhao = this;
		}
		
		private void detach_TTiaoma(TTiaoma entity)
		{
			this.SendPropertyChanging();
			entity.TKuanhao = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TGongyingshang")]
	public partial class TGongyingshang : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _mingcheng;
		
		private string _lianxiren;
		
		private string _dianhua;
		
		private string _dizhi;
		
		private string _beizhu;
		
		private int _caozuorenid;
		
		private System.DateTime _charushijian;
		
		private System.DateTime _xiugaishijian;
		
		private EntitySet<TTiaoma> _TTiaoma;
		
		private EntityRef<TUser> _TUser;
		
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnmingchengChanging(string value);
    partial void OnmingchengChanged();
    partial void OnlianxirenChanging(string value);
    partial void OnlianxirenChanged();
    partial void OndianhuaChanging(string value);
    partial void OndianhuaChanged();
    partial void OndizhiChanging(string value);
    partial void OndizhiChanged();
    partial void OnbeizhuChanging(string value);
    partial void OnbeizhuChanged();
    partial void OncaozuorenidChanging(int value);
    partial void OncaozuorenidChanged();
    partial void OncharushijianChanging(System.DateTime value);
    partial void OncharushijianChanged();
    partial void OnxiugaishijianChanging(System.DateTime value);
    partial void OnxiugaishijianChanged();
    #endregion
		
		public TGongyingshang()
		{
			this._TTiaoma = new EntitySet<TTiaoma>(new Action<TTiaoma>(this.attach_TTiaoma), new Action<TTiaoma>(this.detach_TTiaoma));
			this._TUser = default(EntityRef<TUser>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mingcheng", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string mingcheng
		{
			get
			{
				return this._mingcheng;
			}
			set
			{
				if ((this._mingcheng != value))
				{
					this.OnmingchengChanging(value);
					this.SendPropertyChanging();
					this._mingcheng = value;
					this.SendPropertyChanged("mingcheng");
					this.OnmingchengChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_lianxiren", DbType="NVarChar(5) NOT NULL", CanBeNull=false)]
		public string lianxiren
		{
			get
			{
				return this._lianxiren;
			}
			set
			{
				if ((this._lianxiren != value))
				{
					this.OnlianxirenChanging(value);
					this.SendPropertyChanging();
					this._lianxiren = value;
					this.SendPropertyChanged("lianxiren");
					this.OnlianxirenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dianhua", DbType="VarChar(11) NOT NULL", CanBeNull=false)]
		public string dianhua
		{
			get
			{
				return this._dianhua;
			}
			set
			{
				if ((this._dianhua != value))
				{
					this.OndianhuaChanging(value);
					this.SendPropertyChanging();
					this._dianhua = value;
					this.SendPropertyChanged("dianhua");
					this.OndianhuaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dizhi", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string dizhi
		{
			get
			{
				return this._dizhi;
			}
			set
			{
				if ((this._dizhi != value))
				{
					this.OndizhiChanging(value);
					this.SendPropertyChanging();
					this._dizhi = value;
					this.SendPropertyChanged("dizhi");
					this.OndizhiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_beizhu", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string beizhu
		{
			get
			{
				return this._beizhu;
			}
			set
			{
				if ((this._beizhu != value))
				{
					this.OnbeizhuChanging(value);
					this.SendPropertyChanging();
					this._beizhu = value;
					this.SendPropertyChanged("beizhu");
					this.OnbeizhuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_caozuorenid", DbType="Int NOT NULL")]
		public int caozuorenid
		{
			get
			{
				return this._caozuorenid;
			}
			set
			{
				if ((this._caozuorenid != value))
				{
					if (this._TUser.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OncaozuorenidChanging(value);
					this.SendPropertyChanging();
					this._caozuorenid = value;
					this.SendPropertyChanged("caozuorenid");
					this.OncaozuorenidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_charushijian", DbType="DateTime NOT NULL")]
		public System.DateTime charushijian
		{
			get
			{
				return this._charushijian;
			}
			set
			{
				if ((this._charushijian != value))
				{
					this.OncharushijianChanging(value);
					this.SendPropertyChanging();
					this._charushijian = value;
					this.SendPropertyChanged("charushijian");
					this.OncharushijianChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_xiugaishijian", DbType="DateTime NOT NULL")]
		public System.DateTime xiugaishijian
		{
			get
			{
				return this._xiugaishijian;
			}
			set
			{
				if ((this._xiugaishijian != value))
				{
					this.OnxiugaishijianChanging(value);
					this.SendPropertyChanging();
					this._xiugaishijian = value;
					this.SendPropertyChanged("xiugaishijian");
					this.OnxiugaishijianChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TGongyingshang_TTiaoma", Storage="_TTiaoma", ThisKey="id", OtherKey="gysid")]
		public EntitySet<TTiaoma> TTiaoma
		{
			get
			{
				return this._TTiaoma;
			}
			set
			{
				this._TTiaoma.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TUser_TGongyingshang", Storage="_TUser", ThisKey="caozuorenid", OtherKey="id", IsForeignKey=true)]
		public TUser TUser
		{
			get
			{
				return this._TUser.Entity;
			}
			set
			{
				TUser previousValue = this._TUser.Entity;
				if (((previousValue != value) 
							|| (this._TUser.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TUser.Entity = null;
						previousValue.TGongyingshang.Remove(this);
					}
					this._TUser.Entity = value;
					if ((value != null))
					{
						value.TGongyingshang.Add(this);
						this._caozuorenid = value.id;
					}
					else
					{
						this._caozuorenid = default(int);
					}
					this.SendPropertyChanged("TUser");
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
		
		private void attach_TTiaoma(TTiaoma entity)
		{
			this.SendPropertyChanging();
			entity.TGongyingshang = this;
		}
		
		private void detach_TTiaoma(TTiaoma entity)
		{
			this.SendPropertyChanging();
			entity.TGongyingshang = null;
		}
	}
}
#pragma warning restore 1591
