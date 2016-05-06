using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPractic.Models
{
    public class tbContent
    {
        [Key]
        public int ContentId { get; set; }
        public byte[] ContentPic { get; set; }
    }
}