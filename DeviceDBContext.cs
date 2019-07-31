using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Database
{
    public class DeviceDBContext : DbContext
    {
        public DeviceDBContext(DbContextOptions<DeviceDBContext> options):base(options)
        {

        }

        public DbSet<Models.DeviceType> DeviceType { get; set; }
        public DbSet<Models.Device> Device { get; set; }

    }
}
 