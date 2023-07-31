using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.AddBookRead;

// Kafka, Rabbit
public interface IBookReadPublisher
{
    Task<bool> PublishAsync(int userId, string isbn);
}
