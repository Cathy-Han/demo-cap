using System;
using System.Data;
using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;

namespace microServiceTwo.Domain
{
    public class UserContext:DbContext
    {
        private readonly ICapPublisher _capPublisher;
        public UserContext(DbContextOptions options,ICapPublisher cap):base(options)
        {
            _capPublisher = cap;
        }

        public DbSet<User> Users{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            modelBuilder.Entity<User>().ToTable("User").HasKey(k=>k.Id);
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}