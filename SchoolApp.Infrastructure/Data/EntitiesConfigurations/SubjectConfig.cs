using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Infrastructure.Data.EntitiesConfigurations;

public class SubjectConfig : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("Subjects", schema: "dbo");
        builder.HasKey(sub => sub.Id);
        //builder.Property(sub => sub.Id).ValueGeneratedNever();

        builder
            .Property(sub => sub.Name)
            .HasColumnName("Name")
            .HasColumnType("varchar")
            .HasMaxLength(500)
            .IsRequired();

        builder
            .Property(sub => sub.Period)
            .HasColumnName("Period")
            .HasColumnType("datetime")
            .IsRequired();

        builder.HasData(LoadSubjects());
    }

    public static List<Subject> LoadSubjects()
    {
        return new List<Subject>
        {
            new Subject {Id=1, Name="React", Period=new DateTime(2023, 10, 12)},
            new Subject {Id=2, Name="Math", Period=new DateTime(2023, 11, 30)},
        };
    }
}
