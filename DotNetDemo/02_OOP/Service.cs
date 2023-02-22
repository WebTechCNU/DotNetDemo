using System.Data.SqlClient;

namespace DotNetDemo._02_OOP
{
    public class BaseProduct
    { 
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Car : BaseProduct 
    {
        public string Model { get; set; }
    }

    public class Appartment : BaseProduct
    {
        public string Adress { get; set; }
    }

    public class BaseService // System.Object
    {
        protected string _connectionString = ""; // variable

        public string ConnectionString 
        { 
            get 
            { 
                return _connectionString; // property
            } // SOLID, 
        }

        public void Main() 
        {
            //Name = "SampleName";
        }

        public BaseProduct GetProducts(int id) // method
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString)) 
            {
                //var data = sqlConnection
                // get data somehow
            }
            return null;
        }
    }

    public class DerivedService : BaseService, IDeletionService // is-a OR "inheritance"
    {
        public void DeleteProduct(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                //var data = sqlConnection
                // delete data somehow
            }
        }
    }

    public class DerivedDerivedService : DerivedService // : BaseService
    {
        public string Conn => _connectionString;
    }

    public class CompositionService : IDeletionService
    {
        private string _connectionString;

        public CompositionService(BaseService baseService)
        {
            _connectionString = baseService.ConnectionString; // has-a OR "composition"
        }

        public void DeleteProduct(int id) // lower coupling 
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                //var data = sqlConnection
                // delete data somehow
            }
        }
    }
}
