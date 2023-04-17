using AsynchronousSessionManagement.Models;
using FluentNHibernate.Mapping;

namespace AsynchronousSessionManagement.Mappers
{
    public class AuditMap : ClassMap<Audit>
    {
        public AuditMap()
        {
            Id(x => x.PKey);
            Map(x => x.TableModified);
            Map(x => x.DateTimeUpdated);
        }
    }
}