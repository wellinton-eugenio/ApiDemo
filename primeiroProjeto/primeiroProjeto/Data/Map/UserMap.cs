using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using primeiroProjeto.Models;

namespace primeiroProjeto.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UsersModel>
    {
        public void Configure(EntityTypeBuilder<UsersModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnType("text");
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150).HasColumnType("text");
            builder.Property(x => x.Password).IsRequired().HasMaxLength(20);
        }
    }
}
