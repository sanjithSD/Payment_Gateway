using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebhookHandler.Application.Service.Abstraction
{
    public interface IWebhookService
    {
        Task<bool> ProcessWebhookAsync(string body,string signature);
    }
}
