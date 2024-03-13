using System.Text.Json.Serialization;

namespace _4Tables.Domain.Base.Common
{
    public class BasicResult
    {
        [JsonIgnore]
        public bool IsSuccess { get; private set; } = false;
        [JsonIgnore]
        public bool IsFailure => !IsSuccess;
        public List<Error> Errors { get; set; } = new List<Error>();

        public BasicResult() { }

        public BasicResult ISSUCESS(bool isSucces)
        {
            IsSuccess = isSucces;
            return this;
        }

        public BasicResult ERROR(Error error) { Errors.Add(error); return this; }

        public BasicResult ERROS(List<Error> errors)
        {
            foreach (var error in errors)
            {
                Errors.Add(error);
            }
            return this;
        }
    }
}
