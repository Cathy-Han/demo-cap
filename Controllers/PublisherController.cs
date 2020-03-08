using System;
using System.Threading.Tasks;
using DotNetCore.CAP;
using microServiceOne.Domain;
using Microsoft.AspNetCore.Mvc;

namespace microServiceOne.Controllers
{
    public class PublisherController:ControllerBase
    {
        private readonly ICapPublisher _capPublisher;
        private readonly CustomerContext _context;

        public PublisherController(ICapPublisher publisher,CustomerContext context)
        {
            _capPublisher=publisher;
            _context=context;
        }
        /// <summary>
        /// 创建客户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<IActionResult> CreateCustomer(Customer model)
        {
            using(var trans = _context.Database.BeginTransaction(_capPublisher,true))
            {
                await _context.Customers.AddAsync(model);
                await _capPublisher.PublishAsync("CustomerCreated",model);
            }
            return Ok();
        }        
    }
}