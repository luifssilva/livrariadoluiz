namespace LivrariaDoLuiz.Application.Entity;
public class Response
{
        public object Value { get; set; } = null!;

        private IList<Notification> _messages { get; } = [];
        public IList<Notification> Message => _messages;

        public bool AnyMessage => _messages.Any();

        public Response() { }

        public Response(object @object) : this()
        {
            AddValue(@object);
        }

        public void AddValue(object @object)
        {
            Value = @object;
        }

        public void AddNotifications(Notification notification)
        {
            _messages.Add(notification);
        }

        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            foreach (var notification in notifications)
            {
                AddNotifications(notification);
            }
        }

        public override string ToString()
        {
            return string.Join(" - ", Message.Select(x => x.Message));
        }

        public object GetValue()
        {
            return Value;
        }    
}
