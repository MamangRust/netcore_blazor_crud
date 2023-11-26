using System;
using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Models;

public class MyWebApiDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }

    public MyWebApiDbContext(DbContextOptions<MyWebApiDbContext> options) : base(options)
    {
    }
}