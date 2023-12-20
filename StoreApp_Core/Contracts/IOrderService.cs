using MediatR;
using StoreApp_Core.DTOs;

namespace StoreApp_Core.Contracts
{
    /// <summary>
    /// Интерфейс для работы с OrderService
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Получает заказ по <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id заказа</param>
        /// <returns>Возвращает заказ</returns>
        Task<OrderDTO?> GetOrderByIdAsync(int id);

        /// <summary>
        /// Получает заказы в интервале дат <paramref name="searchDateStart"/> и <paramref name="searchDateEnd"/> по фильтру <paramref name="filter"/>
        /// </summary>
        /// <param name="searchDateStart">Дата начала поиска</param>
        /// <param name="searchDateEnd">Дата окончания поиска</param>
        /// <param name="filter">Фильтр, по которому сортируются заказа</param>
        /// <returns>Коллекция заказов</returns>
        Task<ICollection<OrderDTO>?> GetOrdersByFilterAsync(DateTime searchDateStart, DateTime searchDateEnd, string? filter);

        /// <summary>
        /// Создаёт заказ
        /// </summary>
        /// <param name="order">Модель с данными заказа</param>
        /// <returns>Результат создания</returns>
        Task<bool> CreateOrderAsync(OrderDTO order);

        /// <summary>
        /// Редактируе заказ
        /// </summary>
        /// <param name="order">Модель с данными заказа</param>
        /// <returns>Результат редактирования</returns>
        Task<Unit> EditOrderAsync(OrderDTO order);

        /// <summary>
        /// Удаляет заказ по <paramref name="id"/>
        /// </summary>
        /// <param name="id">Id заказа</param>
        /// <returns>Результат удаления</returns>
        Task<Unit> DeleteOrderAsync(int id);

        /// <summary>
        /// Проверяет на совпадение <paramref name="name"/> c Provider
        /// </summary>
        /// <param name="name">Номер заказа</param>
        /// <returns>Результат сравнения</returns>
        Task<bool> IsExistOrderNameAsync(string name);
    }
}
