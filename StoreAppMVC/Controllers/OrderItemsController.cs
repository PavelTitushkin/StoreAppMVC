using Microsoft.AspNetCore.Mvc;
using StoreApp_Core.Contracts;
using StoreApp_Core.DTOs;
using StoreAppMVC.Models.OrderItems;

namespace StoreAppMVC.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IOrderService _orderService;

        public OrderItemsController(IOrderItemService orderItemService, IOrderService orderService)
        {
            _orderItemService = orderItemService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderItemsByFilter(string? filter, int id)
        {
            var orderDto = await _orderService.GetOrderByIdAsync(id);

            if (orderDto != null)
            {
                orderDto.OrderItemDTOs = await _orderItemService.GetOrderItemsAsync(id, filter);

                return View(orderDto);
            }

            return RedirectToAction("GetOrderItemsByFilter", new { filter, id });
        }

        [HttpGet]
        public IActionResult CreateOrderItem(int orderId)
        {
            var model = new OrderItemModel()
            {
                OrderId = orderId,
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult EditOrderItemPartialView(int id, string name, decimal quantity, string unit, int orderId)
        {
            var model = new OrderItemModel()
            {
                Id = id,
                Name = name,
                Quantity = quantity,
                Unit = unit,
                OrderId = orderId
            };

            return View(model);
        }


        [HttpGet]
        public IActionResult DeleteOrderItemPartialView(int id, int orderId)
        {
            var model = new OrderItemModel()
            {
                Id = id,
                OrderId = orderId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderItem(OrderItemModel model)
        {
            if (ModelState.IsValid)
            {
                var canAddOrderItem = await _orderService.IsExistOrderNameAsync(model.Name);
                if (!canAddOrderItem)
                {
                    ModelState.AddModelError("Name", "Name of OrderItem cannot be the same as Order Number.");
                    return View(model);
                }

                var dto = new OrderItemDTO()
                {
                    Name = model.Name,
                    Quantity = model.Quantity,
                    Unit = model.Unit,
                    OrderId = model.OrderId,
                };

                await _orderItemService.CreateOrderItemAsync(dto);

                return RedirectToAction("GetOrderItemsByFilter", new { id = model.OrderId });
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditOrderItem(OrderItemModel model)
        {
            var dto = new OrderItemDTO()
            {
                Id = model.Id,
                Name = model.Name,
                Quantity = model.Quantity,
                Unit = model.Unit,
                OrderId = model.OrderId,
            };

            await _orderItemService.EditOrderItemAsync(dto);

            return RedirectToAction("GetOrderItemsByFilter", new { id = model.OrderId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrderItem(OrderItemModel model)
        {
            await _orderItemService.DeleteOrderItemAsync(model.Id);

            return RedirectToAction("GetOrderItemsByFilter", new { id = model.OrderId });
        }
    }
}
