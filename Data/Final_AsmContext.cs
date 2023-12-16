using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Final_Asm.Models;

namespace Final_Asm.Data
{
    public class Final_AsmContext : DbContext
    {
        public Final_AsmContext (DbContextOptions<Final_AsmContext> options)
            : base(options)
        {
        }

        public DbSet<Final_Asm.Models.Customer> customers { get; set; } = default!;
        public DbSet<Final_Asm.Models.Author> authors { get; set; } = default!;

        public DbSet<Final_Asm.Models.Category> categorys { get; set; } = default!;

        public DbSet<Final_Asm.Models.Admin> admins { get; set; } = default!;

        public DbSet<Final_Asm.Models.Book> books { get; set; } = default!;

        public DbSet<Final_Asm.Models.UploadFile> uploadFiles { get; set; } = default!;

        public DbSet<Final_Asm.Models.OwnerAcc> bookAccs { get; set; } = default!;
        public DbSet<Final_Asm.Models.BookOwner> bookOwners { get; set; } = default!;


    }
}
