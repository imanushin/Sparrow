namespace Sparrow.Web.Models
{
    public abstract class BaseTestViewModel
    {
        protected BaseTestViewModel(string testIdentity)
        {
            Name = testIdentity;
            TestIdentity = testIdentity;
        }

        public string Name
        {
            get;
            private set;
        }

        public string TestIdentity
        {
            get;
            private set;
        }
    }
}