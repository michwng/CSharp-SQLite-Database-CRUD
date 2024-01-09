/**       
 * -------------------------------------------------------------------
 * 	   File name: Books.cs
 * 	Project name: QueryBuilder
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/21/2022	
 *            Last Modified:    03/23/2022
 * -------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder
{
    public class Books : IClassModel
    {
        public Int64 Id { get; init; }
        public string Title { get; init; }
        public string ISBN { get; init; }
        public DateOnly DateOfPublication { get; init; }

        /*
         * The base constructor of the Books class.
         * 
         * Date Created: 03/23/2022
         */
        public Books() 
        {
            Id = 99999;
            Title = "Example Books Title";
            ISBN = "000-000000000-00";
            DateOfPublication = DateOnly.Parse("12/23/2000");
        }

        /*
         * The primary constructor of the Books class.
         * 
         * Date Created: 03/23/2022
         * @param int id
         * @param string title, isbn
         * @param DateOnly dateOfPublication
         */
        public Books(int id, string title, string isbn, DateOnly dateOfPublication)
        {
            Id = id;
            Title = title;
            ISBN = isbn;
            DateOfPublication = dateOfPublication;
        }
    }
}
