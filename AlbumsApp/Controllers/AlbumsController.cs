using AlbumsApp.Entities;
using AlbumsApp.Models;
using AlbumsApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlbumsApp.Controllers
{
    public class AlbumsController : Controller
    {
        private IAlbumManager _albumManager;

        public AlbumsController(IAlbumManager albumManager)
        {
            _albumManager = albumManager;
        }

        [HttpGet("/albums/{genre?}")]
        public IActionResult GetAlbums(string genre)
        {
            ICollection<Album> albums;

            if (string.IsNullOrEmpty(genre) || genre == "All")
            {
                albums = _albumManager.GetAllAlbums().ToList();
                genre = "All";
            }
            else
            {
                albums = _albumManager.GetAlbumsByGenre(genre);
            }

            AlbumViewModel albumViewModel = new AlbumViewModel()
            {
                Genres = _albumManager.GetAllGenres(),
                RandomAlbum = _albumManager.GetRandomAlbum(),
                ActiveGenre = genre,
                Albums = albums,
            };

            return View("List", albumViewModel);
        }
    }
}
