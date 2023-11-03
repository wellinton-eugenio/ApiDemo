using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using primeiroProjeto.Models;

namespace primeiroProjeto.Data.Map
{
    public class ToDoMap : IEntityTypeConfiguration<ToDoModel>
    {
        public void Configure(EntityTypeBuilder<ToDoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255).HasColumnType("text");
            builder.Property(x => x.Description).HasMaxLength(1500).HasColumnType("text");
            builder.Property(x => x.Status);
            builder.Property(x => x.UserId);

            builder.HasOne(x => x.User);
        }

    }
}
