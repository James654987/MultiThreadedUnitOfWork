using FluentNHibernate.Mapping;
using MultiThreadedUnitOfWork.Models;

namespace MultiThreadedUnitOfWork.Mappers
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