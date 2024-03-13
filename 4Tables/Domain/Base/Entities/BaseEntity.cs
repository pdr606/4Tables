namespace _4Tables.Domain.Base.Entities
{
    public class BaseEntity
    {

        public bool Available { get; private set; }
        public DateTime Created_At { get; private set; } = DateTime.UtcNow;
        public DateTime? Updated_At { get; private set; }

        protected void Update() {
            Updated_At = DateTime.UtcNow;
        }

        public void AtivarDesativar(bool available)
        {
            if(available)
            {
                Available = true;
                return;
            }
            Available = false;
        }
    }
}
