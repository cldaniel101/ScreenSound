using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();


builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 
var app = builder.Build();

app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
{
    var listaDeArtistas = dal.Listar();
    if (listaDeArtistas is null)
    {
        return Results.NotFound();
    }
    var listaDeArtistasResponse = listaDeArtistas.Select(a => new ArtistaResponse(a.Id, a.Nome, a.Bio, a.FotoPerfil)).ToList();
    return Results.Ok(listaDeArtistasResponse);
});

app.MapGet("/Artistas/{nome}", ([FromServices] DAL < Artista > dal, string nome) =>
{
    var artista = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
    if (artista is null)
    {
        return Results.NotFound();
    }
    var artistaResponse = new ArtistaResponse(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil);
    return Results.Ok(artistaResponse);
});

app.MapPost("/Artistas", ([FromServices] DAL < Artista > dal, [FromBody]Artista artista) => {
    dal.Adicionar(artista);
    return Results.Ok();
});

app.MapDelete("/Artistas/{id}", ([FromServices] DAL<Artista> dal, int id) =>
{
    var artista = dal.RecuperarPor(a => a.Id == id);
    if (artista is null)
    {
        return Results.NotFound();
    }
    dal.Deletar(artista);
    return Results.NoContent();
});

app.MapPut("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artista) =>
{
    var artistaAAtualizar = dal.RecuperarPor(a => a.Id == artista.Id);
    if (artistaAAtualizar is null)
    {
        return Results.NotFound();
    }
    artistaAAtualizar.Nome = artista.Nome;
    artistaAAtualizar.Bio = artista.Bio;
    artistaAAtualizar.FotoPerfil = artista.FotoPerfil;
    dal.Atualizar(artistaAAtualizar);
    return Results.Ok();
});

app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
{
    return Results.Ok(dal.Listar());
});

app.MapGet("/Musicas/{nome}", ([FromServices] DAL<Musica> dal, string nome) => 
{
    var musica = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
    if (musica is null)
    {
        return Results.NotFound();
    }
    var musicaResponse = new MusicaResponse(musica.Id, musica.Nome, musica.AnoLancamento, musica.Artista);
    return Results.Ok(musicaResponse);
});

app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) => {
    dal.Adicionar(musica);
    return Results.Ok();
});

app.MapDelete("/Musicas/{id}", ([FromServices] DAL<Musica> dal, int id) =>
{
    var musica = dal.RecuperarPor(a => a.Id == id);
    if (musica is null)
    {
        return Results.NotFound();
    }
    dal.Deletar(musica);
    return Results.NoContent();
});

app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) =>
{
    var musicaAAtualizar = dal.RecuperarPor(a => a.Id == musica.Id);
    if (musicaAAtualizar is null)
    {
        return Results.NotFound();
    }
    musicaAAtualizar.Nome = musica.Nome;
    musicaAAtualizar.AnoLancamento = musica.AnoLancamento;
    musicaAAtualizar.Artista = musica.Artista;
    dal.Atualizar(musicaAAtualizar);
    return Results.Ok();
});

app.Run();
