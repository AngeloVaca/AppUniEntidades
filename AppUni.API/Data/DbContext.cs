using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppUni.Entidades;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUni.Entidades.Carrera> Carreras { get; set; } = default!;

public DbSet<AppUni.Entidades.Universidad> Universidades { get; set; } = default!;
    }
