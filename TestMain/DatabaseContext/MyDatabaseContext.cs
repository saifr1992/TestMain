using System;
using Microsoft.EntityFrameworkCore;
using TestMain.Entities;

namespace TestMain.DatabaseContext
{
	public class MyDatabaseContext : DbContext
    {
		public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options)
        {}

        public DbSet<UserEntity> Users { get; set; } // Database user table
        public DbSet<PostEntity> Posts { get; set; } // Database Posts table
        public DbSet<CommentEntity> Comments { get; set; } // Database Comments table
    }
}

