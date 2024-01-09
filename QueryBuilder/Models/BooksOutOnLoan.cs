/**       
 * -------------------------------------------------------------------
 * 	   File name: BooksOutOnLoan.cs
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
    public class BooksOutOnLoan : IClassModel
    {
        public Int64 Id { get; init; }
        public int BookId { get; init; }
        public DateOnly DateIssued { get; init; }
        public DateOnly DueDate { get; init; }
        public DateOnly? DateReturned { get; init; }

        /*
         * The base constructor of the BooksOutOnLoan class.
         * 
         * Date Created: 03/23/2022
         */
        public BooksOutOnLoan() 
        {
            Id = 99999;
            BookId = 99999;
            DateIssued = DateOnly.Parse("10/20/2000");
            DueDate = DateOnly.Parse("11/10/2000");
            DateReturned = null;
        }

        /*
         * The priamry constructor of the BooksOutOnLoan class.
         * 
         * Date Created: 03/23/2022
         */
        public BooksOutOnLoan(int id, int bookId, DateOnly dateIssued, DateOnly dueDate, DateOnly dateReturned)
        {
            Id = id;
            BookId = bookId;
            DateIssued = dateIssued;
            DueDate = dueDate;
            DateReturned = dateReturned;
        }
    }
}
