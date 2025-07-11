using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Shared.Modelos
{
    public record MusicaResponse(int Id, string Nome, int? AnoLancamento, Artista? Artista);
}
