﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataTranslate
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FD_BetaEntities : DbContext
    {
        public FD_BetaEntities()
            : base("name=FD_BetaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TJintuihuo> TJintuihuo { get; set; }
        public virtual DbSet<TJintuimingxi> TJintuimingxi { get; set; }
        public virtual DbSet<TXiaoshou> TXiaoshou { get; set; }
    }
}
