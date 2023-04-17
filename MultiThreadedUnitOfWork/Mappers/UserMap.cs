using AsynchronousSessionManagement.Models;
using FluentNHibernate.Mapping;

namespace AsynchronousSessionManagement.Mappers
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.PKey);
            Map(x => x.Name);
        }
    }
}