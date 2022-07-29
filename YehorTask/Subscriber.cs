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

    public string PhoneNumber { get; set; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="phoneNumber"></param>
    public Subscriber(string name, string phoneNumber)
    {
      Name = name;
      PhoneNumber = phoneNumber;
    }
  }
}
