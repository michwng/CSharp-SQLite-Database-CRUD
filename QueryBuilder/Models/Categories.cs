/**       
 * -------------------------------------------------------------------
 * 	   File name: Categories.cs
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
    public class Categories : IClassModel
    {
        public Int64 Id { get; init; }
        public string Name { get; init; }

        /*
         * The base constructor of the Categories class.
         * 
         * Date Created: 03/23/2022
         */
        public Categories() 
        {
            Id = 99999;
            Name = "Example Category";
        }

        /*
         * The primary constructor of the Categories class.
         * 
         * Date Created: 03/23/2022
         * @param int id
         * @param string name
         */
        public Categories(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
