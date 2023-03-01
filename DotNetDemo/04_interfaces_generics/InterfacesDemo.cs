using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo._04_interfaces_generics
{
    public class InterfacesDemo
    {
        public void Main()
        {
            IMovable movable = new Car();
            movable.Move();
            movable = new Bicycle();
            movable.Move();

            Car carOld = new Car() { ReleaseDate = new DateTime(1970, 1, 1)};
            Car carNew = new Car() { ReleaseDate = new DateTime(2010, 1, 1) };

            Console.WriteLine(carNew.CompareTo(carOld));

            using (var disposableAccess = new DatabaseDisposable()) 
            {
                disposableAccess.Work();
            }

            // var d = new Disposable()
            // d.Dispose();
        }

        public void WorkWithDatabase(IDatabaseAccess<Product> databaseAccess) 
        {
            var product = databaseAccess.GetProduct(10);
        }
    }

    public class DbTestDatabaseAccess 
    {
        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            return new Product() { Id = id};
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }

    public class MongoDbDatabaseAccess 
    {
        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }

    public class MssqlDatabseAccess : IDatabaseAccess<Product>, IGet
    {
        private string _connString = "";

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteProduct(int id)
        {
            //await dbContext.Products.DeleteAsync(id);
            throw new NotImplementedException();
        }

        void IGet.GetProduct(int id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IDatabaseAccess<T>
    {
        public T GetProduct(int id);
        public void UpdateProduct(Product product);
        public Task DeleteProduct(int id);
    }

    public interface IGet 
    {
        public void GetProduct(int id);
    }

    public class Product : BaseProduct
    {
        public int Id { get; set; }

        public int CompareTo(Product? other)
        {
            throw new NotImplementedException();
        }
    }

    public class BaseProduct
    {
    }

    public interface IMovable 
    {
        public void Move();
    }

    public class Car : IMovable, IComparable<Car>
    {
        public DateTime ReleaseDate { get; set; }

        public int CompareTo(Car? other)
        {
            if (ReleaseDate < other?.ReleaseDate) { return -1; }
            else if (ReleaseDate == other?.ReleaseDate) { return 0; }
            else { return 1; };
        }

        public void Move()
        {
            Console.WriteLine("Car goes whowho");
        }
    }

    public class Bicycle : IMovable, ICloneable
    {
        public Product Product;

        public object Clone()
        {
            return new Bicycle() { Product = new Product() { Id = Product.Id} };
        }

        public void Move()
        {
            Console.WriteLine("Bicycle goes whowho");
        }
    }

    public class DatabaseDisposable : IDisposable
    {
        private SqlConnection _connection;

        public void Work() { }
        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
