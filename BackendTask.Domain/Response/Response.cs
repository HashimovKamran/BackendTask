namespace BackendTask.Domain.Response
{
    public static class Response
    {
        public static Result Fail(string message) => new(message, true);

        public static Result Ok(object data, string message = default) => new(data, message, false);
    }

    public class Result
    {
        public Result(object data, string msg, bool error) : this(msg, error)
        {
            Data = data;
        }
        public Result(string msg, bool error)
        {
            Message = msg;
            Error = error;
        }
        public object Data { get; set; }
        public string Message { get; set; } = "Something went wrong";
        public bool Error { get; set; }
    }
}
