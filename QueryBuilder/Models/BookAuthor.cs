/**       
 * -------------------------------------------------------------------
 * 	   File name: BookAuthor.cs
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
    public class BookAuthor : IClassModel
    {
        public Int64 Id { get; init; }
        public int AuthorId { get; init; }
        public int BookId { get; init; }

        /*
         * The base constructor of the BookAuthor class.
         * 
         * Date Created: 03/23/2022
         */
        public BookAuthor() 
        {
            Id = 99999;
            AuthorId = 99999;
            BookId = 99999;
        }

        /*
         * The primary constructor of the BookAuthor class.
         * 
         * Date Created: 03/23/2022
         * @param int id, authorId, bookId
         */
        public BookAuthor(int id, int authorId, int bookId)
        {
            Id = id;
            AuthorId = authorId;
            BookId = bookId;
        }
    }
}
