using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ark.Data.Models.Configs
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            ////soft delete config
            //builder.Property<bool>("IsDeleted");
            //builder.HasQueryFilter(e => EF.Property<bool>(e, "IsDeleted") == false);

            builder.OwnsOne(p => p.HomeAddress);
            builder.OwnsOne(p => p.BusinessAddress);


            //foreign keys
            builder.HasOne(p => p.CurrentCompany).WithMany(c => c.People).HasForeignKey(p => p.CurrentCompanyId);

        }
    }
}
