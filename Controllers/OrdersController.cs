using aljuvifoods_webapi.DTOs.Order;
using aljuvifoods_webapi.Models;
using aljuvifoods_webapi.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aljuvifoods_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public OrdersController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllOrders()
        {
            var orders = await context.Orders.Include(x => x.OrderUser)
                                             .Include(x => x.Products)
                                             .ThenInclude(products => products.Product)
                                             .ToListAsync();
            return Ok(orders);
        }
        [HttpPost]
        public async Task<ActionResult> PostOrder([FromBody] OrderCDTO orderCDTO)
        {
            try
            {
                var transaction = context.Database.BeginTransaction();
                var order = mapper.Map<Order>(orderCDTO);

                context.Add(order);
                await context.SaveChangesAsync();
               

                var orderProducts = new List<OrderProduct>();
                if(orderCDTO.Products != null)
                {
                    foreach (var orderProduct in orderCDTO.Products)
                    {
                        orderProducts.Add(new OrderProduct()
                        {
                            ProductId = orderProduct.ProductId,
                            OrderId = order.Id,
                            Amount = orderProduct.Amount,
                            Total = orderProduct.Total,
                        });
                    }
                    context.AddRange(orderProducts);
                    

                }
                await context.SaveChangesAsync();
                transaction.Commit();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
