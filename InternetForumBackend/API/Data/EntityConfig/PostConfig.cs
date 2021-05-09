﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.EntityConfig
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.PostId);

            builder.Property(p => p.PostTitle)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(p => p.PostContent)
                .IsRequired();

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(255);

            builder.Property(p => p.Link)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(p => p.Community)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CommunityId);

            builder.HasOne(p => p.User)
                .WithMany(r => r.Posts)
                .HasForeignKey(p => p.UserId);
        }
    }
}
