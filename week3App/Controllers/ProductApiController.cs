using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using week3App.Models;

namespace week3App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IBusControl _bus;
        private int retryCount = 5;
        public ProductApiController(IBusControl bus)
        {
            _bus = bus;
        }

        [HttpPost, Route("OrderProduct")]
        public async Task<IActionResult> Post([FromBody] ProductModel productModel)
        {
            ProductModel model = new ProductModel();
            model.Id = productModel.Id;
            model.ProductName = $"Product {productModel.Id}";
            model.GuidHere = Guid.NewGuid().ToString();

            Uri _uri = new Uri("rabbitmq://localhost/placedOrder-queue");
            var endPoint = await _bus.GetSendEndpoint(_uri);
            await endPoint.Send(model);

            return Ok("Order placed successfully!");

        }
    }
}
