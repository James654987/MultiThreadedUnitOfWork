namespace MultiThreadedUnitOfWork.Models
{
    public class User
    {
        protected User()
        {
        }

        public User(string name)
        {
            Name = name;
        }

        public virtual int PKey { get; }
        public virtual string Name { get; }
    }
}