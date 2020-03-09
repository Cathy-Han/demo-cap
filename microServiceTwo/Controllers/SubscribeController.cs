using System;
using System.Threading.Tasks;
using DotNetCore.CAP;
using microServiceTwo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace microServiceOne.Controllers
{
    public class SubscribeController:ControllerBase
    {
        [NonAction]
        [CapSubscribe("CustomerCreated")]
        public async Task CreateUser([FromServices]UserContext context,dynamic customer)
        {
            await context.Users.AddAsync(new microServiceTwo.Domain.User{
                Id=customer.Id,
                UserName=customer.Name,
                Password="111111"
            });
            await context.SaveChangesAsync();
        }
    }
}