using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IG.Core.Data.Entities
{
   public class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }

    }
}
