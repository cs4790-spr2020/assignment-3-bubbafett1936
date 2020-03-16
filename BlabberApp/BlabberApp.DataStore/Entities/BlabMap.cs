using BlabberApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlabberApp.DataStore.Entities
{
   public class BlabMap
   {
       public BlabMap(EntityTypeBuilder<Blab> entityBuilder)
       {
           entityBuilder.HasKey(t => t.SysID);
           entityBuilder.Property(t => t.UserID);
           entityBuilder.Property(t => t.Message);
       }
   } 
}