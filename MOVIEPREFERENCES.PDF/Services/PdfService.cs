using Microsoft.EntityFrameworkCore;
using MOVIE.PREFERENCES.REPO.DBCONTEXT;
using MOVIE.PREFERENCES.REPO.Interfaces;
using MOVIE.PREFERENCES.REPO.MODELS;
using MOVIEPREFERENCES.PDF.Dto;
using MOVIEPREFERENCES.PDF.Interfaces;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace MOVIEPREFERENCES.PDF.Services
{
    public class PdfService : IPdfService
    {
        private readonly IRepositorio<Int32, UsuarioRepoDto> usuarioRepositorio;
        private readonly IRepositorio<Int32, PeliculaRepoDto> peliculaRepositorio;
        private readonly IRepositorio<Int32, GeneroRepoDto> generoRepositorio;

        private readonly MovieContext _context;

        ReportePdfDto reportePdfDto = new ReportePdfDto();

        public PdfService(IRepositorio<Int32, UsuarioRepoDto> usuarioRepositorio,
            IRepositorio<Int32, PeliculaRepoDto> peliculaRepositorio,
            IRepositorio<Int32, GeneroRepoDto> generoRepositorio,
            MovieContext context) 
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.peliculaRepositorio = peliculaRepositorio;
            this.generoRepositorio = generoRepositorio;
            this._context = context;

        }

        private void Inicializar()
        {
            this.reportePdfDto.usuarios = usuarioRepositorio.listar();
            this.reportePdfDto.peliculas = peliculaRepositorio.listar();
            this.reportePdfDto.Generos = generoRepositorio.listar();
        }

        public byte[] GenerarReporte()
        {
            try
            {
                Inicializar();

                var usuario = this.reportePdfDto.usuarios;

                var pdfDocumento = new PdfDocument();
                string content = ObtenerTextoHtml();
                string htmlContent = content.Replace("{0}", GenerarUsuarios())
                    .Replace("{1}", GenerarPeliculas())
                    .Replace("{2}", GenerarSugerencias());
                PdfGenerator.AddPdfPages(pdfDocumento, htmlContent, PageSize.A4);
                byte[] response = null;

                using(MemoryStream ms = new MemoryStream())
                {
                    pdfDocumento.Save(ms);
                    response = ms.ToArray();
                }

                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string ObtenerTextoHtml()
        {
            string[] Documents = System.IO.Directory.GetFiles("./Formato/");
            string text = File.ReadAllText(Documents[0]);
            return text;
        }

        private string GenerarUsuarios()
        {
            string texto = "<table><tr><th>Usuario</th><th>Nombre</th><th>Apellido</th><th>Correo</th></tr>";
            
            foreach(var usuario in reportePdfDto.usuarios)
            {
                texto += "<tr>";
                texto += $"<td>{usuario.Usuario}</td>";
                texto += $"<td>{usuario.Nombre}</td>";
                texto += $"<td>{usuario.Apellido}</td>";
                texto += $"<td>{usuario.Correo}</td>";
                texto += "</tr>";
            }

            texto += "</table>";

            return texto;
        }

        private string GenerarPeliculas()
        {
            string texto = "<table><tr><th>Nombre</th><th>Descripción</th><th>Generos</th></tr>";

            foreach (var pelicula in reportePdfDto.peliculas)
            {
                texto += "<tr>";
                texto += $"<td>{pelicula.Nombre}</td>";
                texto += $"<td>{pelicula.Descripcion}</td>";
                texto += $"<td>";
                foreach (var peliGenero in pelicula.PeliculaGenero)
                {
                    foreach(var genero in reportePdfDto.Generos)
                    {
                        if(peliGenero.GeneroId == genero.Id)
                        {
                            texto += $"{genero.Nombre}, ";
                        }
                    }
                }
                texto += "</td>";
                texto += "</tr>";
            }

            texto += "</table>";

            return texto;
        }

        private string GenerarSugerencias()
        {
            string texto = "";

            var listaUsuarios = _context.UsuarioRepoDto.Include(x => x.UsuarioGenero).ToList();

            foreach (var usuario in listaUsuarios)
            {
                texto += $"<h3><strong>{usuario.Usuario}</strong></h3>";
                texto += "<ul>";

                var generos = usuario.UsuarioGenero.Select(x => x.GeneroId).ToList();

                foreach (var pelicula in reportePdfDto.peliculas)
                {
                    var generoPeli = pelicula.PeliculaGenero.Select(x => x.GeneroId).ToList();

                    if(generoPeli.Any(x => generos.Any(y => y == x))) 
                    {
                        texto += $"<li>{pelicula.Nombre}</li>";
                    }
                }

                texto += "</ul>";
            }

            return texto;
        }
    }
}
