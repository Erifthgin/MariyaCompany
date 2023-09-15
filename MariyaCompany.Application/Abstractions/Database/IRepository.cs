using System;
using System.Collections.Generic;
using System.Linq;

namespace MariyaCompany.Application.Abstractions.Database
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Создать объект в бд
        /// </summary>
        bool Create(T item);

        /// <summary>
        /// Поиск по id
        /// </summary>
        T FindById(int id);

        /// <summary>
        /// Получение объекта из бд
        /// </summary>
        IQueryable<T> GetAll();

        /// <summary>
        /// получить вместе с виртуальными методами
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAllWithVirtual();

        /// <summary>
        /// получить с выбранным свойством
        /// </summary>
        /// <param name="property"></param>
        IQueryable<T> GetAllWithSelectVirtual(string property);

        /// <summary>
        /// Удаление объекта из бд
        /// </summary>
        bool Remove(T item);

        /// <summary>
        /// Обновление объекта из бд
        /// </summary>
        bool Update(T item);
    }
}
