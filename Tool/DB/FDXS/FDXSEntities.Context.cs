﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tool.DB.FDXS
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FDXSEntities : DbContext
    {
        public FDXSEntities()
            : base("name=FDXSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TJinchuhuo> TJinchuhuo { get; set; }
        public virtual DbSet<TJinchuMX> TJinchuMX { get; set; }
        public virtual DbSet<TKucunXZ> TKucunXZ { get; set; }
        public virtual DbSet<TTiaoma> TTiaoma { get; set; }
        public virtual DbSet<TUser> TUser { get; set; }
        public virtual DbSet<VFKucun> VFKucun { get; set; }
        public virtual DbSet<TPandian> TPandian { get; set; }
    }
}
