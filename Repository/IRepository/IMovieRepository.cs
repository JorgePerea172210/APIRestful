using APIRestful.Models;

namespace APIRestful.Repository.IRepository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> Get();
        Task<IEnumerable<Movie>> GetByCategory(int categoryId);
        Task<Movie> GetById(int movieId);
        Task<Movie> SearchMovie(string name);
        Task Add(Movie insert);
        Task Update(Movie update);
        void Delete(Movie delete);
        Task Save();
        IEnumerable<Movie> Search(Func<Movie, bool> filter);
    }
}
