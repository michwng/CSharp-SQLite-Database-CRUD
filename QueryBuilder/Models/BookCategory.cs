/**       
 * -------------------------------------------------------------------
 * 	   File name: BookCategory.cs
 * 	Project name: QueryBuilder
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/23/2022	
 *            Last Modified:    03/23/2022
 * -------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    public class BookCategory : IClassModel
    {
        public Int64 Id { get; init; }
        public int BookId { get; init; }
        public int CategoryId { get; init; }

        /*
         * The base constructor of the BookCategory class.
         * 
         * Date Created: 03/23/2022
         */
        public BookCategory() 
        {
            Id = 99999;
            BookId = 99999;
            CategoryId = 99999;
        }

        /*
         * The primary constructor of the BookCategory class.
         * 
         * Date Created: 03/23/2022
         * @param int id, bookId, categoryId
         */
        public BookCategory(int id, int bookId, int categoryId) 
        {
            Id = id;
            BookId = bookId;
            CategoryId = categoryId;
        }
    }
}
