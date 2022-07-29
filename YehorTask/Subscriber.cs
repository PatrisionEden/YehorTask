using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YehorTask
{
  /// <summary>
  /// Абонент.
  /// </summary>
  internal class Subscriber : ISubscriber
  {
    public string Name { get; set; }

    public string Phonenumber { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя абонента.</param>
    /// <param name="phoneNumber">Телефон абонента.</param>
    public Subscriber(string name, string phoneNumber)
    {
      Name = name;
      Phonenumber = phoneNumber;
    }
  }
}
