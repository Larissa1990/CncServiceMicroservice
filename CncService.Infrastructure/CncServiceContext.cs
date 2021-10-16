using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using CncService.Domain.CncServiceAggregate;
using CncService.Domain;
using MediatR;

namespace CncService.Infrastructure
{
    public class CncServiceContext :DbContext,IUnitOfWork
    {
        public DbSet<CNCService> services { get; set; }
        public DbSet<Subscribe> subscribers { get; set; }

        string connectionString =
            "Server=localhost;uid=root;pwd=hzbp;port=3306;Database=db_cncservice;charset=utf8";

        private readonly IMediator mediator;

        public CncServiceContext(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public CncServiceContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CNCService>(
                c =>{
                    c.HasMany(c => c.endpoints)
                    .WithOne()
                    .HasForeignKey(e => e.serviceid);
                    c.HasKey(c => c.id);
                });

            builder.Entity<Endpoint>(
                e =>
                {
                    e.HasMany(e => e.contract)
                    .WithOne()
                    .HasForeignKey(c => c.endpointId);

                    e.HasOne(e => e.binding)
                    .WithOne()
                    .HasForeignKey<Binding>(e => e.id);
                });
        }

        public async Task<bool>SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await mediator.DispatchDomainEventsAsync(this);
            var result = base.SaveChangesAsync(cancellationToken);
            return true;
        }

    }
}
