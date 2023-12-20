using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using StoreApp_Core.Contracts;
using StoreApp_Core.DTOs;
using StoreAppMVC.Exceptions;
using StoreAppMVC.Models.Orders;
using System.Text;

namespace StoreAppMVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProviderService _providerService;

        public OrdersController(IOrderService orderService, IProviderService providerService)
        {
            _orderService = orderService;
            _providerService = providerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersByFilter(DateTime searchDateEnd, DateTime searchDateStart, string? filter)
        {
            var dtos = await _orderService.GetOrdersByFilterAsync(searchDateStart, searchDateEnd, filter);

            return View(dtos);
        }


        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var model = new OrderModel();
            var providers = await _providerService.GetAllProvidersAsync();
            model.ProviderList = new SelectList(providers, "Id", "Name");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditOrderPartialView(OrderModel model)
        {
            var providers = await _providerService.GetAllProvidersAsync();
            model.ProviderList = new SelectList(providers, "Id", "Name");

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = new OrderDTO()
                {
                    Number = model.Number,
                    Date = model.Date,
                    ProviderDTOId = model.ProviderId
                };

                if (!await _orderService.CreateOrderAsync(dto))
                {
                    throw new OrderNumberIsNotUniqueException("Не должно существовать 2х заказов от одного поставщика с одинаковыми номерами");
                }

                return RedirectToAction("GetOrdersByFilter");
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditOrder(OrderModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = new OrderDTO()
                {
                    Id = model.Id,
                    Number = model.Number,
                    Date = model.Date,
                    ProviderDTOId = model.ProviderId
                };

                await _orderService.EditOrderAsync(dto);

                return RedirectToAction("GetOrdersByFilter");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult DeleteOrderPartialView(string dtoJson)
        {

            var json = Encoding.UTF8.GetString(Convert.FromBase64String(dtoJson));
            var orderDto = JsonConvert.DeserializeObject<OrderDTO>(json);

            return PartialView(orderDto);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _orderService.DeleteOrderAsync(id);

            return RedirectToAction("GetOrdersByFilter");
        }
    }
}
