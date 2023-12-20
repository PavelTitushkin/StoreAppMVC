using MediatR;
using StoreApp_Core.DTOs;

namespace StoreApp_Core.Contracts
{
    /// <summary>
    /// Интерфейс для работы с OrderItemService
    /// </summary>
    public interface IOrderItemService
    {
        /// <summary>
        /// Получает все товары заказа по <paramref name="id"/> и фильтру <paramref name="filter"/>
        /// </summary>
        /// <param name="id">Id заказа</param>
        /// <param name="filter">Фильтр, по которому сортируются товары</param>
        /// <returns>Возвращает коллекцию товаров</returns>
        Task<ICollection<OrderItemDTO>?> GetOrderItemsAsync(int id, string? filter);

        /// <summary>
        /// Создаёт новый товар в заказе
        /// </summary>
        /// <param name="dto">Модель с данными товара</param>
        /// <returns>Результат создания</returns>
        Task<Unit> CreateOrderItemAsync(OrderItemDTO dto);

        /// <summary>
        /// Редактирут товар в заказе 
        /// </summary>
        /// <param name="dto">Модель с данными товара</param>
        /// <returns>Результат редактирования</returns>
        Task<Unit> EditOrderItemAsync(OrderItemDTO dto);

        /// <summary>
        /// Удаляет товар из заказа по <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id товара</param>
        /// <returns>Результат удаления</returns>
        Task<Unit> DeleteOrderItemAsync(int id);
    }
}
