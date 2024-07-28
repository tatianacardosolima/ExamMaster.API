using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockExam.Manage.Domain.Answers.Entities;
using MockExam.Manage.Domain.Mocks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockExam.Manage.Database.Write.Mappings
{
    internal class AnswerMap : IEntityTypeConfiguration<AnswerOptionEntity>
    {
        public void Configure(EntityTypeBuilder<AnswerOptionEntity> builder)
        {
            builder.ToTable("AnswerOption");
            
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(x => x.Answer).IsRequired(true).HasMaxLength(250);
            builder.Property(x => x.IsCorrectAnswer).IsRequired(true);            
            builder.Property(x => x.Active).IsRequired(true);
            builder.Property(x => x.CreatedAt).IsRequired(true);
            builder.Property(x => x.CreatedBy).IsRequired(true);
            builder.Property(x => x.ModifiedAt).IsRequired(false);
             

        }
    }
}
