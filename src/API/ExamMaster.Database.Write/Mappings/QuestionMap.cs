using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MockExam.Manage.Domain.Mocks.Entities;
using MockExam.Manage.Domain.Questions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockExam.Manage.Database.Write.Mappings
{
    internal class QuestionMap : IEntityTypeConfiguration<QuestionEntity>
    {
        public void Configure(EntityTypeBuilder<QuestionEntity> builder)
        {
            builder.ToTable("Question");

            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(x => x.Statement).IsRequired(true).HasMaxLength(800);
            builder.Property(x => x.QuestionType).IsRequired(true);
            builder.Property(x => x.Active).IsRequired(true);            
            builder.Property(x => x.CreatedAt).IsRequired(true);
            builder.Property(x => x.CreatedBy).IsRequired(true);
            builder.Property(x => x.ModifiedAt).IsRequired(false);
             

        }
    }
}
