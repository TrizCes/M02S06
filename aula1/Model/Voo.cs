using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aula1.Model
{
  public class Voo
  {
    public String Name { get; set; }
    public DateTime PreferenciaDePouso { get; set; }
    public DateTime? PousoAlocado { get; set; }

    public Voo() { }

  }
}
