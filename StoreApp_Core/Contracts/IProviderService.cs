using MediatR;
using StoreApp_Core.DTOs;

namespace StoreApp_Core.Contracts
{
    /// <summary>
    /// Интерфейс для работы с ProviderService
    /// </summary>
    public interface IProviderService
    {
        /// <summary>
        /// Получает все Provider
        /// </summary>
        /// <returns>Коллекия Provider</returns>
        Task<ICollection<ProviderDTO>> GetAllProvidersAsync();

        /// <summary>
        /// Создаёт нового Provider
        /// </summary>
        /// <param name="dto">Модель данных Provider</param>
        /// <returns>Результат создания</returns>
        Task<Unit> CreateProviderAsync(ProviderDTO dto);
    }
}
