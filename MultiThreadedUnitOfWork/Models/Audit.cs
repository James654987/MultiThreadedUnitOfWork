using System;

namespace MultiThreadedUnitOfWork.Models
{
    public class Audit
    {
        protected Audit()
        {
        }

        public Audit(string tableModified)
        {
            TableModified = tableModified;
            DateTimeUpdated = DateTime.Now;
        }
        
        public virtual int PKey { get; }
        public virtual string TableModified { get; }
        public virtual DateTime DateTimeUpdated { get; }
    }
}