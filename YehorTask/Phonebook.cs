using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YehorTask
{
  /// <summary>
  /// Телефонный справочник.
  /// </summary>
  internal class Phonebook
  {
    #region Поля и свойства

    /// <summary>
    /// Список хранимых абонентов.
    /// </summary>
    private List<ISubscriber> subscribers;

    #endregion

    #region Методы

    /// <summary>
    /// Добавить абонента в справочник.
    /// </summary>
    /// <exception cref="ArgumentException">Возникает если абонент с таким номером уже есть в справочнике.</exception>
    /// <param name="subscriber">Абонент которого нужно добавить.</param>
    public void AddSubscriber(ISubscriber subscriber)
    {
      if (this.subscribers.Any(s => s.Name == subscriber.Phonenumber))
        throw new ArgumentException($"Абонент с номером \"{subscriber.Phonenumber}\" уже есть в справочнике.");
      this.subscribers.Add(subscriber);
    }

    /// <summary>
    /// Получить абонента по номеру телефона.
    /// </summary>
    /// <param name="phonenumber">Номер телефона абонента.</param>
    /// <exception cref="KeyNotFoundException">Возникает если абонента с таким телефоном нет в справочнике.</exception>
    /// <exception cref="Exception">Возникает если в справочнике больше одного абонента с одинаковым номером.</exception>
    /// <returns>Найденый абонент.</returns>
    public ISubscriber GetSubscriberByPhonenumber(string phonenumber)
    {
      var subscribersWithThisPhonenumber =
        this.subscribers.Where(s => s.Phonenumber == phonenumber);

      if (subscribersWithThisPhonenumber.Count() == 0)
        throw new KeyNotFoundException("Абонента с таким телефоном нет в справочнике.");
      else if (subscribersWithThisPhonenumber.Count() > 1)
        throw new Exception("Неправильное состояние объекта, больше одного абонента с одинаковым номером.");

      return subscribersWithThisPhonenumber.First();
    }

    /// <summary>
    /// Получить абонентов по имени.
    /// </summary>
    /// <param name="name">Имя абонента.</param>
    /// <exception cref="KeyNotFoundException">Возникает если ни у одного абонента из справочника нет такого имени.</exception>
    /// <returns>Найденые абоненты.</returns>
    public IEnumerable<ISubscriber> GetSubscribersByName(string name)
    {
      var subscribersWithThisPhonenumber = this.subscribers.Where(s => s.Name == name);

      if (!subscribersWithThisPhonenumber.Any())
        throw new KeyNotFoundException("Абонентов с таким именем нет в справочнике.");

      return subscribersWithThisPhonenumber;
    }

    /// <summary>
    /// Удалить абонента из справочника.
    /// </summary>
    /// <param name="subscriber">Удаляемый абонент.</param>
    /// <returns>Удалось ли удалить переданного абонента.</returns>
    public bool DeleteSubscriber(ISubscriber subscriber)
    {
      return this.subscribers.Remove(subscriber);
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    public Phonebook()
    {
      this.subscribers = new List<ISubscriber>();
    }

    #endregion
  }
}
