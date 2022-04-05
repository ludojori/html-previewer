using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using html_previewer_app.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace html_previewer_app.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new html_previewer_appContext(serviceProvider.
                GetRequiredService<DbContextOptions<html_previewer_appContext>>()))
            {
                if (context.HtmlCodeSampleModel.Any())
                {
                    serviceProvider.GetRequiredService<ILogger<Program>>()
                        .LogDebug("Database already seeded.");
                    return;
                }

                context.HtmlCodeSampleModel.AddRange(
                    new HtmlCodeSampleModel
                    {
                        Id = "0",
                        Name = "SeedSample0",
                        Code = "",
                        CreatedOn = DateTime.Parse("1989-2-12"),
                        LastModified = DateTime.Now
                    },

                    new HtmlCodeSampleModel
                    {
                        Id = "1",
                        Name = "SeedSample1",
                        Code = "",
                        CreatedOn = DateTime.Parse("1984-3-13"),
                        LastModified = DateTime.Now
                    },

                    new HtmlCodeSampleModel
                    {
                        Id = "2",
                        Name = "SeedSample2",
                        Code = "",
                        CreatedOn = DateTime.Parse("1986-2-23"),
                        LastModified = DateTime.Now
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
