using System;
using System.Data;
using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;

namespace microServiceOne.Domain
{
    public class CustomerContext:DbContext
    {
        private readonly ICapPublisher _capPublisher;
        public CustomerContext(DbContextOptions options,ICapPublisher cap):base(options)
        {
            _capPublisher = cap;
        }

        public DbSet<Customer> Customers{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            modelBuilder.Entity<Customer>().ToTable("Customer").HasKey(k=>k.Id);
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}