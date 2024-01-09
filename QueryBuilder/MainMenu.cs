/**       
 * -------------------------------------------------------------------
 * 	   File name: MainMenu.cs
 * 	Project name: QueryBuilder
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/21/2022	
 *            Last Modified:    03/24/2022
 * -------------------------------------------------------------------
 */

namespace QueryBuilder
{
    //The MainMenu class steals functionality from Program.
    public partial class MainMenu : Form
    {
        /*
         * The default constructor for main menu.
         * 
         * Date Created: 03/21/2022 
         */
        public MainMenu()
        {
            InitializeComponent();
        }

        /**
         * References the "Test Read (Author Class)" Button.
         * This method is called when the user clicks on the "Test Read (Author Class)" Button. 
         * (This is an EventHandler Method)
         * 
         * Reads from a random Author in the Database.
         * 
         * Date Created: 03/24/2022
         */
        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(Program.Read());
        }

        /**
         * References the "Test Read All (Author Class)" Button.
         * This method is called when the user clicks on the "Test Read All (Author Class)" Button. 
         * (This is an EventHandler Method)
         * 
         * Reads all Authors in the Database
         * 
         * Date Created: 03/24/2022
         */
        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(Program.ReadAll());
        }

        /**
         * References the "Create a New Author" Button.
         * This method is called when the user clicks on the "Create a New Author" Button. 
         * (This is an EventHandler Method)
         * 
         * Allows the user to create and add an author to the database.
         * 
         * Date Created: 03/24/2022
         */
        private void button3_Click(object sender, EventArgs e)
        {
            Program.CreateAuthor();
        }

        /**
         * References the "Update an Existing Author" Button.
         * This method is called when the user clicks on the "Update an Existing Author" Button. 
         * (This is an EventHandler Method)
         * 
         * Allows the user to update an existing author in the database.
         * 
         * Date Created: 03/24/2022
         */
        private void button4_Click(object sender, EventArgs e)
        {
            Program.UpdateAuthor();
        }

        /**
         * References the "Delete an Existing Author" Button.
         * This method is called when the user clicks on the "Delete an Existing Author" Button. 
         * (This is an EventHandler Method)
         * 
         * Allows the user to delete an existing author in the database.
         * 
         * Date Created: 03/24/2022
         */
        private void button5_Click(object sender, EventArgs e)
        {
            Program.DeleteAuthor();        
        }

        /**
         * References the "Exit the Application" Button.
         * This method is called when the user clicks on the "Exit the Application" Button. 
         * (This is an EventHandler Method)
         * 
         * Exits the program.
         * 
         * Date Created: 03/24/2022
         */
        private void button6_Click(object sender, EventArgs e)
        {
            Program.Exit();
        }
    }
}