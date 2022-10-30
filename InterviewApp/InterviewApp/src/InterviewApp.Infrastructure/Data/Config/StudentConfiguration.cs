using InterviewApp.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InterviewApp.Infrastructure.Data.Config
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(p => p.FullName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.DOB)
                .IsRequired();
        }
    }
}
