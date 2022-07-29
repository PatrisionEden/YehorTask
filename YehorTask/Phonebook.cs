using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YehorTask
{
  class Phonebook
  {
    #region Поля и свойства
    /// <summary>
    /// Словарь который связывает имя с ISubscriber.
    /// </summary>
    private Dictionary<string, List<ISubscriber>> mapByName;
    /// <summary>
    /// Словарь который связывает номер телефона с ISubscriber.
    /// </summary>
    private Dictionary<string, List<ISubscriber>> mapByPhone;
    #endregion
    #region Методы
    /// <summary>
    /// Добавляет <paramref name="subscriber"/> в экземпляр Phonebook.
    /// </summary>
    /// <param name="subscriber">Запись в Phonebook к добавлению.</param>
    public void AddSubscriber(ISubscriber subscriber)
    {
      if (!this.mapByName.ContainsKey(subscriber.Name))
        this.mapByName[subscriber.Name] = new List<ISubscriber>();
      if (!this.mapByPhone.ContainsKey(subscriber.PhoneNumber))
        this.mapByPhone[subscriber.PhoneNumber] = new List<ISubscriber>();

      this.mapByName[subscriber.Name].Add(subscriber);
      this.mapByPhone[subscriber.PhoneNumber].Add(subscriber);
    }
    /// <summary>
    /// Возвращает коллекцию Subscriber c переданным <paramref name="name"/>.
    /// </summary>
    /// <param name="name">Имя Subscriber.</param>
    /// <returns>Коллекция Subscriber с соответсвующими Name.</returns>
    public IReadOnlyCollection<ISubscriber> GetSubscribersByName(string name)
    {
      return this.mapByName[name];
    }
    /// <summary>
    /// Возвращает коллекцию Subscriber c переданным <paramref name="phonenumber"/>.
    /// </summary>
    /// <param name="phonenumber">Номер телефона Subscriber.</param>
    /// <returns>Коллекция Subscriber с соответсвующими Phonenumber.</returns>
    public IReadOnlyCollection<ISubscriber> GetSubscribersByPhone(string phonenumber)
    {
      return this.mapByPhone[phonenumber];
    }
    /// <summary>
    /// Возвращает первого Subscriber с совпавшим <paramref name="name"/>.
    /// </summary>
    /// <param name="name">Имя Subscriber.</param>
    /// <returns>Первый Subscriber с совпавшим <paramref name="name"/>.</returns>
    public ISubscriber GetFirstSubscriberByName(string name)
    {
      try
      {
        return this.mapByName[name].First();
      }
      catch (Exception ex)
      {
        throw new KeyNotFoundException("Не был найден", ex);
      }
    }
    /// <summary>
    /// Возвращает первого Subscriber с совпавшим <paramref name="phonenumber"/>.
    /// </summary>
    /// <param name="phonenumber">Имя Subscriber</param>.
    /// <returns>Первый Subscriber с совпавшим <paramref name="phonenumber"/>.</returns>
    public ISubscriber GetSubscriberByPhonenumber(string phonenumber)
    {
      try
      {
        return this.mapByPhone[phonenumber].First();
      }
      catch (Exception ex)
      {
        throw new KeyNotFoundException("Не был найден", ex);
      }
    }
    /// <summary>
    /// Удаляет Subscriber из Phonebook в том случае если, по переданному 
    /// <paramref name="name"/> есть одно и только одно совпадение.
    /// </summary>
    /// <param name="name">Имя, по которому будет удален Subscriber.</param>
    /// <returns>Удаляемый Subscriber.</returns>
    public ISubscriber DeleteSubscriberByName(string name)
    {
      if (!this.mapByName.ContainsKey(name))
        throw new KeyNotFoundException(name + " не существует в данном phonebook");
      if (this.mapByName[name].Count > 1)
        throw new Exception("больше одного значения по данному name");

      var toBeDeleted = this.mapByName[name].First();
      DeleteSubscriberFromMapByPhone(toBeDeleted);
      this.mapByName[name] = new List<ISubscriber>();
      return toBeDeleted;
    }
    /// <summary>
    /// Удаляет Subscriber из Phonebook в том случае если, по переданному 
    /// <paramref name="phonenumber"/> есть одно и только одно совпадение.
    /// </summary>
    /// <param name="phonenumber">Номер телефона, по которому будет удален Subscriber.</param>
    /// <returns>Удаляемый Subscriber.</returns>
    public ISubscriber DeleteSubscriberByPhonenumber(string phonenumber)
    {
      if (!this.mapByPhone.ContainsKey(phonenumber))
        throw new KeyNotFoundException(phonenumber + " не существует в данном phonebook");
      if (this.mapByPhone[phonenumber].Count > 1)
        throw new Exception("больше одного значения по данному phonenumber");

      var toBeDeleted = this.mapByPhone[phonenumber].First();
      DeleteSubscriberFromMapByName(toBeDeleted);
      this.mapByPhone[phonenumber] = new List<ISubscriber>();
      return toBeDeleted;
    }
    /// <summary>
    /// Удаляет одно или нескоолько вхождений <paramref name="subscriber"/> из Phonebook.
    /// </summary>
    /// <param name="subscriber">Удаляемый Subscriber.</param>
    public void DeleteSubscriber(ISubscriber subscriber)
    {
      DeleteSubscriberFromMapByPhone(subscriber);
      DeleteSubscriberFromMapByName(subscriber);
    }
    /// <summary>
    /// Удаляет все вхождения Subscriber с переданным <paramref name="name"/>.
    /// </summary>
    /// <param name="name">Имя, с которым Subscriber будут удалены.</param>
    /// <returns>Коллекция удаленных Subscriber.</returns>
    public IReadOnlyCollection<ISubscriber> DeleteAllByName(string name)
    {
      if (!this.mapByName.ContainsKey(name))
        return new List<ISubscriber>();

      var toBeDeletedList = this.mapByName[name];
      this.mapByName[name] = new List<ISubscriber>();

      foreach (var toBeDeletedSubscriber in toBeDeletedList)
      {
        DeleteSubscriberFromMapByPhone(toBeDeletedSubscriber);
        DeleteSubscriberFromMapByName(toBeDeletedSubscriber);
      }

      return toBeDeletedList;
    }
    /// <summary>
    /// Удаляет все вхождения Subscriber с переданным <paramref name="phonenumber"/>.
    /// </summary>
    /// <param name="phonenumber">Номер телефона, с которым Subscriber будут удалены.</param>
    /// <returns>Коллекция удаленных Subscriber.</returns>
    public IReadOnlyCollection<ISubscriber> DeleteAllByPhone(string phonenumber)
    {
      if (!this.mapByPhone.ContainsKey(phonenumber))
        return new List<ISubscriber>();

      var toBeDeletedList = this.mapByPhone[phonenumber];
      this.mapByPhone[phonenumber] = new List<ISubscriber>();

      foreach (var toBeDeletedSubscriber in toBeDeletedList)
      {
        DeleteSubscriberFromMapByPhone(toBeDeletedSubscriber);
        DeleteSubscriberFromMapByName(toBeDeletedSubscriber);
      }

      return toBeDeletedList;
    }
    /// <summary>
    /// Удалить все вхождения <paramref name="subscriber"/> из mapByPhone.
    /// </summary>
    /// <param name="subscriber">Тот, которого нужно удалить.</param>
    private void DeleteSubscriberFromMapByPhone(ISubscriber subscriber)
    {
      var list = this.mapByPhone[subscriber.PhoneNumber];
      list.Remove(subscriber);
    }
    /// <summary>
    /// Удалить все вхождения <paramref name="subscriber"/> из mapByName.
    /// </summary>
    /// <param name="subscriber">Тот, которого нужно удалить.</param>
    private void DeleteSubscriberFromMapByName(ISubscriber subscriber)
    {
      var list = this.mapByName[subscriber.Name];
      list.Remove(subscriber);
    }
    #endregion
    #region Конструкторы
    /// <summary>
    /// Конструктор класса Phonebook. Инициализирует поля дефолтными значениями.
    /// </summary>
    public Phonebook()
    {
      this.mapByName = new Dictionary<string, List<ISubscriber>>(); //вот тут неопределенка.
      this.mapByPhone = new Dictionary<string, List<ISubscriber>>();
    }
    #endregion
  }
}
