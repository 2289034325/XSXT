﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tool.DB.JCSJ
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TGongyingshang> TGongyingshang { get; set; }
        public virtual DbSet<TTiaoma> TTiaoma { get; set; }
        public virtual DbSet<TCangku> TCangku { get; set; }
        public virtual DbSet<THuiyuan> THuiyuan { get; set; }
        public virtual DbSet<TFendian> TFendian { get; set; }
        public virtual DbSet<TUser> TUser { get; set; }
        public virtual DbSet<TKuanhao> TKuanhao { get; set; }
    }
}
