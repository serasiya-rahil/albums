﻿using AlbumsApp.Entities;

namespace AlbumsApp.Services
{
    public interface IAlbumManager
    {
        public void AddAlbum(Album album);

        public ICollection<Album> GetAllAlbums();

        public ICollection<Album> GetAlbumsByGenre(string genre);

        public Album GetRandomAlbum();

        public ICollection<string> GetAllGenres();
    }
}
