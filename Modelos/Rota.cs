using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasV0.Modelos;
internal class Rota
{
    public string Origem { get; set; }
    public string Destino { get; set; }

    public Rota(string origem, string destino)
    {
        Origem = origem; 
        Destino = destino;
    }
}
