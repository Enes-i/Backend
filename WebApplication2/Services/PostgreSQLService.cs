using Npgsql;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class PostgreSQLService
    {
        private readonly string _connectionString;

        public PostgreSQLService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Point> GetAllPoints()
        {
            var points = new List<Point>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                var command = new NpgsqlCommand("SELECT * FROM Points", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var point = new Point
                        {
                            Id = reader.GetInt64(0),
                            PointX = reader.GetDouble(1),
                            PointY = reader.GetDouble(2),
                            Name = reader.GetString(3)
                        };
                        points.Add(point);
                    }
                }
            }

            return points;
        }

        public Point GetPointById(long id)
        {
            Point point = null;

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                var command = new NpgsqlCommand("SELECT * FROM Points WHERE Id = @id", connection);
                command.Parameters.AddWithValue("id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        point = new Point
                        {
                            Id = reader.GetInt64(0),
                            PointX = reader.GetDouble(1),
                            PointY = reader.GetDouble(2),
                            Name = reader.GetString(3)
                        };
                    }
                }
            }

            return point;
        }

        public void AddPoint(Point point)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                var command = new NpgsqlCommand("INSERT INTO Points (PointX, PointY, Name) VALUES (@x, @y, @name)", connection);
                command.Parameters.AddWithValue("x", point.PointX);
                command.Parameters.AddWithValue("y", point.PointY);
                command.Parameters.AddWithValue("name", point.Name);

                command.ExecuteNonQuery();
            }
        }

        public void UpdatePoint(Point point)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                var command = new NpgsqlCommand("UPDATE Points SET PointX = @x, PointY = @y, Name = @name WHERE Id = @id", connection);
                command.Parameters.AddWithValue("id", point.Id);
                command.Parameters.AddWithValue("x", point.PointX);
                command.Parameters.AddWithValue("y", point.PointY);
                command.Parameters.AddWithValue("name", point.Name);

                command.ExecuteNonQuery();
            }
        }

        public void DeletePoint(long id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                var command = new NpgsqlCommand("DELETE FROM Points WHERE Id = @id", connection);
                command.Parameters.AddWithValue("id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
