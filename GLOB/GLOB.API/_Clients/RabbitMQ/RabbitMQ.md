| #  | **Function Name**               | **Use Case**                                                    | **Where to Use**       |
| -- | ------------------------------- | --------------------------------------------------------------- | ---------------------- |
| 1  | `BasicConsume(...)` (overloads) | Start consuming messages with different options                 | Consumer               |
| 2  | `BasicPublish(...)` (overloads) | Publish a message (with optional address, mandatory flag, etc.) | Publisher              |
| 3  | `QueueDeclare(...)`             | Declare a queue with default options                            | Setup / Initialization |
| 4  | `ExchangeBind(...)`             | Bind one exchange to another                                    | Setup / Initialization |
| 5  | `ExchangeBindNoWait(...)`       | Bind exchanges with nowait = true                               | Advanced Setup         |
| 6  | `ExchangeDeclare(...)`          | Declare an exchange with optional flags                         | Setup / Initialization |
| 7  | `ExchangeDeclareNoWait(...)`    | Declare an exchange with nowait = true                          | Advanced Setup         |
| 8  | `ExchangeUnbind(...)`           | Unbind an exchange from another                                 | Cleanup / Admin        |
| 9  | `ExchangeDelete(...)`           | Delete an exchange                                              | Cleanup / Admin        |
| 10 | `ExchangeDeleteNoWait(...)`     | Delete an exchange with nowait = true                           | Cleanup / Admin        |
| 11 | `QueueBind(...)`                | Bind a queue to an exchange                                     | Setup / Initialization |
| 12 | `QueueDelete(...)`              | Delete a queue (with conditions)                                | Cleanup / Admin        |
| 13 | `QueueDeleteNoWait(...)`        | Delete a queue with nowait = true                               | Cleanup / Admin        |
| 14 | `QueueUnbind(...)`              | Unbind a queue from an exchange                                 | Cleanup / Admin        |

---

Let me know if you'd like a version of this as a formatted `.md` table or code comments for reference.
### Example Pub 1
```c#
[HttpPost] [NoCache]
public async Task<IActionResult> Createz([FromBody] ProjectzLookupDtoCreate dto)
{
    try
    {
        var param = new RabbitMQParam
        {
        payload = new()
        {
            Body = dto,
            Event = $"ProjectzLookupz_{EP.Create}"
        },
        route = new(MQ_Exch.Auth, Controllerz.ProjectzLookup,  EP.Create),
        options = new()
        {
            ExchangeDurable = true,
            QueueDurable = true
        }
        };
        _API_RabbitMQ.Pubs(param);
        return param.payload.ToExtVMSingle().Ok();
    }
    catch (Exception ex)
    {
        // return ex.Ok();
        return $"--> Rabbit MQ Error : {ex.Message}".ToExtVMSingle().Ok();
    }

}

```
### Example Pub 2
```c#
  [HttpPut("{Id}")] [NoCache]
  public async Task<IActionResult> Update(string Id, [FromBody] ProjectzLookupDtoCreate dto)
  {
    Route.Key = EP.Update;
    var param = new RabbitMQParam
    {
      payload = new()
      {
        Resource = Id,
        Body = dto,
        Event = $"ProjectzLookupz_{EP.Update}"
      },
      route = Route
    };

    _API_RabbitMQ.Pubs(param);
    return param.payload.ToExtVMSingle().Ok();
  }  

```
### Example Sub 1
```c#
var param = new RabbitMQParam
{
    route = new RabbitMQRoute
    {
        Exchange = "ex-sample",
        Queue = "q-sample",
        Key = "sample.key"
    },
    options = new RabbitMQOptions
    {
        AutoAck = false
    }
};

_rabbit.Subs<SampleMessage>(param, message =>
{
    Console.WriteLine($"[Subscriber] Received: {message.Text} at {message.Time}");
});
```