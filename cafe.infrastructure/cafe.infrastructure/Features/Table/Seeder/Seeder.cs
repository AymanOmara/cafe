using cafe.Domain.Table.Entity;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Table.Seeder
{
    public static class TableSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            for (int i = 1; i <= 31; i++)
            {
                modelBuilder.Entity<TableEntity>().HasData(new TableEntity() { Id = i, Name = $"{i}", LobbyName = LobbyName.Inside });
            }
            for (int i = 32; i <= 60; i++)
            {
                modelBuilder.Entity<TableEntity>().HasData(new TableEntity() { Id = i, Name = $"{i}", LobbyName = LobbyName.Outside });
            }
        }
    }
}

