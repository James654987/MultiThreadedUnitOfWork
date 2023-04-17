using FluentNHibernate.Mapping;
using MultiThreadedUnitOfWork.Models;

namespace MultiThreadedUnitOfWork.Mappers
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