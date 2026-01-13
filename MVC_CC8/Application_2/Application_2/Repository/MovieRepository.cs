using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MoviesApp.Models;

namespace MoviesApp.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly string connectionString =
            "Server=.;Database=MoviesDB;Trusted_Connection=True;";

        public void Add(Movie movie)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Movies (Moviename, DirectorName, DateofRelease) VALUES (@name,@director,@date)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", movie.Moviename);
                cmd.Parameters.AddWithValue("@director", movie.DirectorName);
                cmd.Parameters.AddWithValue("@date", movie.DateofRelease);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Movie movie)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Movies SET Moviename=@name, DirectorName=@director, DateofRelease=@date WHERE Mid=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", movie.Mid);
                cmd.Parameters.AddWithValue("@name", movie.Moviename);
                cmd.Parameters.AddWithValue("@director", movie.DirectorName);
                cmd.Parameters.AddWithValue("@date", movie.DateofRelease);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Movies WHERE Mid=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Movie GetById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Movies WHERE Mid=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Movie
                    {
                        Mid = (int)reader["Mid"],
                        Moviename = reader["Moviename"].ToString(),
                        DirectorName = reader["DirectorName"].ToString(),
                        DateofRelease = Convert.ToDateTime(reader["DateofRelease"])
                    };
                }
            }
            return null;
        }

        public IEnumerable<Movie> GetAll()
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Movies";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movies.Add(new Movie
                    {
                        Mid = (int)reader["Mid"],
                        Moviename = reader["Moviename"].ToString(),
                        DirectorName = reader["DirectorName"].ToString(),
                        DateofRelease = Convert.ToDateTime(reader["DateofRelease"])
                    });
                }
            }
            return movies;
        }

        public IEnumerable<Movie> GetByYear(int year)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Movies WHERE YEAR(DateofRelease)=@year";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@year", year);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movies.Add(new Movie
                    {
                        Mid = (int)reader["Mid"],
                        Moviename = reader["Moviename"].ToString(),
                        DirectorName = reader["DirectorName"].ToString(),
                        DateofRelease = Convert.ToDateTime(reader["DateofRelease"])
                    });
                }
            }
            return movies;
        }

        public IEnumerable<Movie> GetByDirector(string directorName)
        {
            List<Movie> movies = new List<Movie>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Movies WHERE DirectorName=@director";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@director", directorName);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movies.Add(new Movie
                    {
                        Mid = (int)reader["Mid"],
                        Moviename = reader["Moviename"].ToString(),
                        DirectorName = reader["DirectorName"].ToString(),
                        DateofRelease = Convert.ToDateTime(reader["DateofRelease"])
                    });
                }
            }
            return movies;
        }
    }
}
