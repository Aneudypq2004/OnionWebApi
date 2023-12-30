using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    internal class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasData(
                 new Position { Name = "Software Engineer" },
                 new Position { Name = "Data Analyst" },
                 new Position { Name = "UX Designer" },
                 new Position { Name = "Project Manager" },
                 new Position { Name = "DevOps Engineer" },
                 new Position { Name = "QA Engineer" },
                 new Position { Name = "Product Manager" },
                 new Position { Name = "Backend Developer" }
 );
        }
    }
}
