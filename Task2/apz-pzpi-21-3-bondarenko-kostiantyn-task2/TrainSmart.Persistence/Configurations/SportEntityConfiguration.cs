﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainSmart.Domain.AggregateRoots;
using TrainSmart.Domain.Entities;

namespace TrainSmart.Persistence.Configurations;

public class SportEntityConfiguration: IEntityTypeConfiguration<Sport>
{
    public void Configure(EntityTypeBuilder<Sport> builder)
    {
        builder
            .Property(x => x.Name)
            .IsRequired();
    }
}