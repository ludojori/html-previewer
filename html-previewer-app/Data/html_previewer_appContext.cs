using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using html_previewer_app.Models;

namespace html_previewer_app.Data
{
    public class html_previewer_appContext : DbContext
    {
        public html_previewer_appContext (DbContextOptions<html_previewer_appContext> options)
            : base(options)
        {
        }

        public DbSet<html_previewer_app.Models.HtmlCodeSampleModel> HtmlCodeSampleModel { get; set; }
    }
}
