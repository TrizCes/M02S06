using aula1.Model;
internal class Program
{
  private static void Main(string[] args)
  {
    var voosDesteAeroporto = new List<Voo>()
    {
      new Voo
      {
        Name = "Boing 876",
        PreferenciaDePouso = DateTime.Now.AddHours(4),
      },
      new Voo
      {
        Name = "Air Bus 9000",
        PreferenciaDePouso = DateTime.Now.AddHours(5),
      },
      new Voo
      {
        Name = "Taxi Air 2000",
        PreferenciaDePouso = DateTime.Now.AddHours(8),
      },
    };

    int minutosDediferencaSeguro = 20;

    void defineHorariosDeAterisagem(List<Voo> voosDesteAeroporto)
    {
      var voosDoMaisRecente = voosDesteAeroporto.OrderBy(e => e.PreferenciaDePouso).ToArray();
      for (var i = 0; i < voosDoMaisRecente.Count(); i++)
      {
        var vooEmQuestao = voosDoMaisRecente[i];
        if (i == 0) { }
        var vooAnterior = voosDoMaisRecente[i - 1];
        var vooSeguinte = voosDoMaisRecente[i + 1];

        var naoConflitou = false;
        var possuiConflito = false;
        while (!naoConflitou)
        {
          //modificar a preferencia de voo do voo em questão
          possuiConflito = estaConflitando(vooEmQuestao, vooSeguinte);
          if (!possuiConflito)
          {
            naoConflitou = true;
          }
        }

        if (!possuiConflito)
        {
          vooEmQuestao.PousoAlocado = vooEmQuestao.PreferenciaDePouso;
        }
      }

      bool estaConflitando(Voo principal, Voo comparado)
      {
        var min = principal.PreferenciaDePouso.AddMinutes(-minutosDediferencaSeguro);
        var max = principal.PreferenciaDePouso.AddMinutes(minutosDediferencaSeguro);

        if (comparado.PousoAlocado == null)
        { return false; }
        if (comparado.PreferenciaDePouso >= min && comparado.PreferenciaDePouso <= max)
        {
          return true;
        }
        return false;
      }

      defineHorariosDeAterisagem(voosDesteAeroporto);

      Console.WriteLine(voosDesteAeroporto[0].Name + " | " + voosDesteAeroporto[0].PreferenciaDePouso);
    }
  }
}
