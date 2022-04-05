using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace html_previewer_app.Models
{
    public class HtmlCodeSampleModel
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public string Code { get; set; }
        
        [Display(Name = "Created On")]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        
        [Display(Name = "Last Modified")]
        [DataType(DataType.Date)]
        public DateTime LastModified { get; set; }
    }
}
