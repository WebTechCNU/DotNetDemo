using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDemo._02_OOP
{
    public interface IDeletionService
    {
        // contract
        // SOLID 
        // OOP 

        public void DeleteProduct(int id);
    }
}
