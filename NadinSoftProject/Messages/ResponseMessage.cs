using Newtonsoft.Json;

namespace NadinSoftProject.Host.Messages;

public class ResponseMessage
{
    public ResponseMessage()
    {
    }

    /// <inheritdoc />
    public ResponseMessage(string message)
    {
        this.message = message;
    }

    /// <inheritdoc />
    public ResponseMessage(string message, object content)
    {
        this.message = message;
        this.content = content;
    }

    public string message { get; set; }

    public object content { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}