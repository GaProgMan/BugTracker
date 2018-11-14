using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BugTracker.Data.Entities;

namespace BugTracker.Repo.Data.Mapping
{
    public class BugMap
    {
        public BugMap(EntityTypeBuilder<Bug> entityBuilder)  
        {  
            entityBuilder.HasKey(b => b.Id);
            entityBuilder.ToTable("Bugs");
        } 
    }
}