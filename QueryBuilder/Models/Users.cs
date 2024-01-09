/**       
 * -------------------------------------------------------------------
 * 	   File name: Users.cs
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
    public class Users : IClassModel
    {
        public Int64 Id { get; init; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string OtherUserDetails { get; set; }
        public double AmountOfFine { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        /*
         * The base constructor of the Users class.
         * 
         * Date Created: 03/23/2022
         */
        public Users() 
        {
            Id = 99999;
            UserName = "Example";
            UserAddress = "15233 Example Street";
            OtherUserDetails = "";
            AmountOfFine = 0.00;
            Email = "example@example.com";
            PhoneNumber = "000-000-0000";
        }

        /*
         * The primary constructor of the Users class.
         * 
         * Date Created: 03/23/2022
         * @param int id
         * @param double fine
         * @param string username, userAddress, otherDetails, email, phoneNumber
         */
        public Users(int id, string username, string userAddress, string otherDetails, double fine, string email, string phoneNumber)
        {
            Id = id;
            UserName = username;
            UserAddress = userAddress;
            OtherUserDetails = otherDetails;
            AmountOfFine = fine;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
