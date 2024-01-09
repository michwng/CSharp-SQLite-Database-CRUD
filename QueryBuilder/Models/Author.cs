/**       
 * -------------------------------------------------------------------
 * 	   File name: Author.cs
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

namespace QueryBuilder
{
    public class Author : IClassModel
    {
        public Int64 Id { get; init; }
        public string FirstName { get; init; }
        public string Surname { get; init; }

        /*
         * The base constructor of the Author class.
         * 
         * Date Created: 03/23/2022
         */
        public Author() 
        {
            Id = 99999;
            FirstName = "Example First Name";
            Surname = "Example Surname";
        }

        /*
         * The primary constructor of the Author class.
         * 
         * Date Created: 03/23/2022
         * @param int id
         * @param string firstName, surname
         */
        public Author(int id, string firstName, string surname)
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
        }


        /*
         * Returns a formatted strong containing the author's
         * Id, FirstName, and Surname.
         * 
         * Date Created: 03/23/2022
         * @return string sb
         */
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ID: " + Id);
            sb.Append("\nFirst Name: " + FirstName);
            sb.Append("\nSurname: " + Surname);

            return sb.ToString();
        }
    }
}
