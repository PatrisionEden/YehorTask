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
    /// <returns>Найденый абонент.</returns>
    public ISubscriber GetSubscriberByPhonenumber(string phonenumber)
    {
      return subscribers.Where(s => s.Phonenumber == phonenumber).Single();
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
        throw new KeyNotFoundException($"Абонентов с именем \"{name}\" нет в справочнике.");

      return subscribersWithThisPhonenumber;
    }

    /// <summary>
    /// Удалить абонента из справочника.
    /// </summary>
    /// <param name="subscriber">Удаляемый абонент.</param>
    public void DeleteSubscriber(ISubscriber subscriber)
    {
      this.subscribers.Remove(subscriber);
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
