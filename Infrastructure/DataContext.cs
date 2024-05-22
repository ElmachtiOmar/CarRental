using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Booking> Bookings { get; set; }

        public DbSet<BookingStatus> BookingStatuses { get; set; }
    }
}
