using Catedraticos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catedraticos.Connection
{
    public class Conn:DbContext
    {
        public Conn(DbContextOptions<Conn> options) : base(options) { }

        public DbSet<CatedraticoModel> tbl_Catedratico { get; set; }
    }
}
