//namespace InterviewApp.SharedKernel;

public class ResponseModel
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public static ResponseModel Fail(string message = null)
    {
        return new ResponseModel
        {
            IsSuccess = false,
            Message = message
        };
    }

    public static ResponseModel Success(string message = null)
    {
        return new ResponseModel
        {
            IsSuccess = true,
            Message = message
        };
    }
}

public class ResponseModel<T> : ResponseModel
{
    public T Data { get; set; }

    public ResponseModel()
    {
    }

    public ResponseModel(T data)
    {
        Data = data;
    }

    public static ResponseModel<T> Fail(string message = null, T data = default)
    {
        return new ResponseModel<T>
        {
            IsSuccess = false,
            Message = message,
            Data = data
        };
    }

    public static ResponseModel<T> Success(T data, string message = null)
    {
        return new ResponseModel<T>(data)
        {
            IsSuccess = true,
            Message = message,
            Data = data
        };
    }
}