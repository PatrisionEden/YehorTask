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
  interface ISubscriber
  {
    /// <summary>
    /// Имя абонента.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Номер телефона абонента.
    /// </summary>
    public string Phonenumber { get; }
  }
}
