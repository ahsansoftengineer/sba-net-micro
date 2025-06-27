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


```c#
_rabbit = new RabbitBase();
var param = new RabbitMQParam
{
    body = data,
    route = new RabbitMQRoute
    {
        Exchange = "ex-sample",
        Queue = "q-sample",
        Key = "sample.key"
    },
    options = new RabbitMQOptions
    {
        ExchangeDurable = true,
        QueueDurable = true
    }
};

_rabbit.Pubs(param);


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