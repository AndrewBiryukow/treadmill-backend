using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using treadmill_server.Data.Concrete;
using treadmill_server.Entities;

namespace treadmill_server.Configurations;

public class ProductConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User", "");
    }
}