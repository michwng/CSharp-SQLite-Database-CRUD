/**       
 * -------------------------------------------------------------------
 * 	   File name: IClassModel.cs
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
    public interface IClassModel
    {
        public Int64 Id { get; init; }
    }
}
