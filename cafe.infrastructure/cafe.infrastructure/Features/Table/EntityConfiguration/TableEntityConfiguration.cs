using cafe.Domain.Table.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cafe.infrastructure.Features.Table.EntityConfiguration
{
    public class TableEntityConfiguration : IEntityTypeConfiguration<TableEntity>
	{
        public void Configure(EntityTypeBuilder<TableEntity> builder)
        {
            for (int i = 1; i <= 31; i++)
            {
                builder.HasData(new TableEntity() { Id = i, Name = $"{i}", LobbyName = LobbyName.Inside });
            }
            for (int i = 32; i <= 60; i++)
            {
                builder.HasData(new TableEntity() { Id = i, Name = $"{i}", LobbyName = LobbyName.Outside });
            }

            builder
                .HasQueryFilter(table => !table.Deleted);
        }
    }
}

