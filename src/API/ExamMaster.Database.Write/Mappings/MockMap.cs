using Common.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockExam.Manage.Domain.Mocks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockExam.Manage.Database.Write.Mappings
{
    internal class MockMap : IEntityTypeConfiguration<MockEntity>
    {
        public void Configure(EntityTypeBuilder<MockEntity> builder)
        {
            builder.ToTable("Mock");

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(x => x.Title).IsRequired(true).HasMaxLength(250);
            builder.Property(x => x.Description).IsRequired(true).HasMaxLength(350);
            builder.Property(x => x.Access).IsRequired(true);
            builder.Property(x => x.Active).IsRequired(true);

            builder.OwnsOne(x => x.EffectivePeriod, effectivePeriod =>
                {
                    effectivePeriod.Property(a => a.StartDate).HasColumnName("StartDate").IsRequired(true);
                    effectivePeriod.Property(a => a.EndDate).HasColumnName("EndDate").IsRequired(false);
                }
            );

            builder.Property(x => x.CreatedAt).IsRequired(true);
            builder.Property(x => x.CreatedBy).IsRequired(true);
            builder.Property(x => x.ModifiedAt).IsRequired(false);
             

        }
    }
}
