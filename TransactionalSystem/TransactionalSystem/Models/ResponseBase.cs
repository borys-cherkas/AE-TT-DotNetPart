using Newtonsoft.Json;

namespace TransactionalSystem.Models
{
    public class ResponseBase
    {
        public ResponseBase(ErrorDetails error = null)
        {
            Error = error;
        }

        public bool Successful => Error == null;

        public ErrorDetails Error { get; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
