using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 
var app = builder.Build();

app.MapGet("/Artistas", () =>
{
    var dal = new DAL<Artista>(new ScreenSoundContext());
    var listaDeArtistas = dal.Listar();
    if (listaDeArtistas is null)
    {
        return Results.NotFound();
    }
    var listaDeArtistasResponse = listaDeArtistas.Select(a => new ArtistaResponse(a.Id, a.Nome, a.Bio, a.FotoPerfil)).ToList();
    return Results.Ok(listaDeArtistasResponse);
});

app.MapGet("/Artistas/{nome}", (string nome) =>
{
    var dal = new DAL<Artista>(new ScreenSoundContext());
    var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
    if (artista is null)
    {
        return Results.NotFound();
    }
    var artistaResponse = new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);
    return Results.Ok(artistaResponse);
});

app.Run();
