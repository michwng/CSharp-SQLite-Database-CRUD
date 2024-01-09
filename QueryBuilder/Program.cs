/**       
 * -------------------------------------------------------------------
 * 	   File name: Program.cs
 * 	Project name: QueryBuilder
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/21/2022	
 *            Last Modified:    03/24/2022
 * -------------------------------------------------------------------
 */

using System.IO;
using System.Text;
using System.Runtime.InteropServices;
using System.Media;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

namespace QueryBuilder
{
    /*
     * Program can run on both a Console or a Windows GUI! 
     * You can configure this by going to:
     * 
     * (Visual Studio)
     * 1. Open the Solution Explorer
     * 2. Right Click the Project, QueryBuilder.
     * 3. Select Properties in the menu.
     * 4. Under "Output Type", Select "Console Application".
     * 
     * If WindowsApplication is an option, that option
     * prevents the Console from opening - only allowing 
     * forms to open.
     * 
     * Thanks to: https://stackoverflow.com/questions/4362111/how-do-i-show-a-console-output-window-in-a-forms-application
     */
    public static class Program
    {
        //useGUI puts a firm line between MessageDialog & InputDialog prompts
        //and Command.WriteLine()/Command.ReadLine() prompts.
        public static Boolean useGUI { get; private set; } = false;
        private static QueryBuilder queryBuilder;
        static string DefaultDatabasePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString() + Path.DirectorySeparatorChar + "Data" + Path.DirectorySeparatorChar + "Database.sqlite";
        private static SoundPlayer player = new SoundPlayer();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            //Windows users can use the GUI, but other platforms may not support the GUI.
            AskToUseGUI();
            queryBuilder = new QueryBuilder(DefaultDatabasePath);
            player.SoundLocation = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString() + Path.DirectorySeparatorChar + "freddyfazbear.wav";
            player.Load();
            if (useGUI)
            {
                System.Windows.Forms.Application.Run(new MainMenu());
            }
            else 
            {
                Console.WriteLine("Now using the Console!");
                Console.WriteLine("Welcome to Sqlite Database and QueryBuilder!");

                //A slightly modified version from Lab 4.
                //Removes the need for a variable.
                while (true) 
                {
                    //Menu asks the user to input a valid number and returns the number.
                    //LaunchMethod lauches a method based on that returned number.
                    launchMethod(Menu());
                }
            }
        }




        /*  
         * -------------------------------------------------------------------
         * 	            
         * 	            Menu Methods
         * 	            
         * -------------------------------------------------------------------
         */
        /*
         * Asks the user if they would like to use the GUI.
         * Added for platforms that do not support Windows Forms.
         * 
         * Date Created: 03/23/2022
         */
        private static void AskToUseGUI() 
        {
            Console.WriteLine("Would you like to use the Program's Graphical User Interface? (Windows Only)");
            Console.WriteLine("Type \"yes\" into the console to use the GUI. \nOtherwise, press Enter twice.");

            //We add the space because the user would normally
            //have to press enter twice if they didn't enter anything.
            //Adding the space makes the program think the user entered something and then pressed enter.
            string choice = Console.ReadLine();
            //also validates "yes" with the quotes:
            if (choice == "yes" || choice == "\"yes\"")
            {
                ApplicationConfiguration.Initialize();
                useGUI = true;
            }
        }



        /*
         * This method acts as the menu. 
         * Lists the available applications and inputs.
         * Validates user input.
         * 
         * Date Created: 03/21/2022
         * @return int menuChoice
         */
        private static int Menu()
        {
            string? input = "";
            Console.WriteLine("\nPlease type in the number beside the action you would like to perform.");

            //Continues asking the user for the right input.
            do
            {
                Console.WriteLine("Please type the number next to the option to proceed:");
                Console.WriteLine("1. Test Read (Author Class)");
                Console.WriteLine("2. Test Read All (Author Class)");
                Console.WriteLine("3. Create a New Author");
                Console.WriteLine("4. Update an Existing Author");
                Console.WriteLine("5. Delete an Existing Author");
                Console.WriteLine("6. Exit the Application");
                try
                {
                    input = Console.ReadLine();

                    int menuChoice = Int32.Parse(input.Trim());

                    if (menuChoice >= 1 && menuChoice <= 6)
                    {
                        return menuChoice;
                    }
                    else
                    {
                        Console.WriteLine($"\nOops! \"{input}\" is not an option.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"\nOops! \"{input}\" isn't a number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"\nOops! \"{input}\" is not an option.");
                }
                catch (ArgumentNullException)
                {
                    //Repeat the top message again, asking the user to input a number.
                }
            }
            while (true);
        }
        //end menu()


        /*
         * This method launches a method based on 
         * user input in the menu() method.
         * 
         * Date Created: 03/21/2022
         */
        private static void launchMethod(int menuChoice)
        {
            //Commented out to support Visual Studio Code's Debug Console.
            //Console.Clear();

            switch (menuChoice)
            {
                //Test Read (Author Class)
                case 1:
                    Read();
                    break;


                //Test Read All (Author Class)
                case 2:
                    ReadAll();
                    break;


                //Create a new Author
                case 3:
                    CreateAuthor();
                    break;


                //Update an Existing Author
                case 4:
                    UpdateAuthor();
                    break;


                //Delete an Existing Author
                case 5:
                    DeleteAuthor();
                    return;


                //Exit the Application
                case 6:
                    Exit();
                    break;


                default:
                    Exit();
                    break;
            }

            Console.WriteLine("\n----- End of Method -----\n\n");
        }
        //end launchMethod()


        /*
        * -------------------------------------------------------------------
        * 	            
        * 	            Other Methods
        * 	            
        * -------------------------------------------------------------------
        */

        /*
         * Allows the program to randomly read an author.
         * 
         * Date Created: 03/24/2022
         * Date Updated: 01/09/2024
         */
        internal static string Read() 
        {
            Random random = new Random();
            //everything past the queryBuilder.Read looks... like a lot.
            //We just randomly select a number from 1 to queryBuilder.ReadAll<Author>().Count().
            String readResult = queryBuilder.Read<Author>(random.Next(queryBuilder.ReadAll<Author>().Count()) + 1).ToString();

            if (useGUI) 
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("The program randomly selected: \n" + readResult);

                if (readResult.ToLower().Contains("fazbear"))
                {
                    player.Play();
                    stringBuilder.Append("\n\nCongrats! You found the Easter Egg!\n");
                    stringBuilder.Append("Polish: \"O cholera czy to Freddy fazbear?\"\n");
                    stringBuilder.Append("English: \"Oh sh__, is that Freddy fazbear?\"\n");
                    stringBuilder.Append("From: https://www.youtube.com/watch?v=BDmvkPNyA3k");
                }

                return stringBuilder.ToString();
            }

            if (readResult.ToLower().Contains("fazbear"))
            {
                player.Play();
                Console.WriteLine("Congrats! You found the Easter Egg!");
                Console.WriteLine("Polish: \"O cholera czy to Freddy fazbear?\"");
                Console.WriteLine("English: \"Oh sh__, is that Freddy fazbear?\"");
                Console.WriteLine("From: https://www.youtube.com/watch?v=BDmvkPNyA3k");
            }

            Console.WriteLine("The program randomly selected: ");
            Console.WriteLine(readResult);

            //We don't need to return anything for non-GUI, so we return an empty string.
            return "";
        }


        /*
         * Allows the program to read a list of authors.
         * 
         * Date Created: 03/24/2022
         */
        internal static string ReadAll()
        {
            StringBuilder sb = new StringBuilder();
            List<Author> readList = queryBuilder.ReadAll<Author>();
            foreach (Author author in readList)
            {
                if (useGUI)
                {
                    sb.Append(author.ToString() + "\n--------------------\n");
                }
                else 
                {
                    Console.WriteLine(author.ToString() + "\n--------------------");
                }
            }
            return sb.ToString();
        }

        /*
         * Allows the program to create an author.
         * It is run through queryBuilder and also adds the author
         * to the Database.sqlite file.
         * 
         * Date Created: 03/24/2022
         */
        internal static void CreateAuthor() 
        {
            string createFirstName;
            string createSurname;

            if (useGUI)
            {
                InputDialog inputDialog = new InputDialog();
                inputDialog.label1.Text = "Enter the First Name for the Author: ";
                inputDialog.ShowDialog();
                createFirstName = inputDialog.boxInput;

                inputDialog = new InputDialog();
                inputDialog.label1.Text = "Enter the Surname of the Author: ";
                inputDialog.ShowDialog();
                createSurname = inputDialog.boxInput;
            }
            else 
            {
                Console.WriteLine("Enter the First Name for the Author: ");
                createFirstName = Console.ReadLine();
                Console.WriteLine("Enter the Surname of the Author: ");
                createSurname = Console.ReadLine();
            }

            if (!String.IsNullOrWhiteSpace(createFirstName) && !String.IsNullOrWhiteSpace(createSurname))
            {
                //Pretty neat, huh? queryBuilder.ReadAll<Author>().Count() + 1 is like an autoincrement.
                Author newAuthor = new Author(queryBuilder.ReadAll<Author>().Count() + 1, createFirstName.Trim(), createSurname.Trim());
                queryBuilder.Create(newAuthor);
            }
            else 
            {
                if (useGUI)
                {
                    MessageDialog messageDialog = new MessageDialog();
                    messageDialog.label1.Text = "Oops! One of the fields was empty!\nReturning to the menu.";
                    messageDialog.ShowDialog();
                }
                else 
                {
                    Console.WriteLine("Oops! One of the fields was empty!\nReturning to the menu.");
                }
            }

        }

        /*
         * Allows the program to update an author.
         * It is run through queryBuilder and also 
         * updates the author in the Database.sqlite file.
         * 
         * Date Created: 03/24/2022
         */
        internal static void UpdateAuthor()
        {
            List<Author> updateList = queryBuilder.ReadAll<Author>();
            string idChange;
            int intId;

            if (useGUI)
            {
                InputDialog inputDialog = new InputDialog();
                inputDialog.label1.Text = "Enter the ID of the Author you want to change.";
                inputDialog.ShowDialog();
                idChange = inputDialog.boxInput;
            }
            else
            {
                Console.WriteLine("Enter the ID of the Author you want to change.");
                idChange = Console.ReadLine();
            }

            try
            {
                if (!String.IsNullOrWhiteSpace(idChange))
                {
                    intId = int.Parse(idChange);
                }
                else
                    intId = -1;
                if (intId <= 0 || intId > updateList.Count())
                {
                    //We also print this error if the Id is out of bounds.
                    if (useGUI)
                    {
                        MessageDialog messageDialog = new MessageDialog();
                        messageDialog.label1.Text = "We couldn't find an author with that ID!";
                        messageDialog.ShowDialog();
                    }
                    else
                    {
                        Console.WriteLine("We couldn't find an author with that ID!");
                    }
                    //leave the method since we didn't find an author to update.
                    return;
                }
            }
            catch (FormatException)
            {
                //You'll be seeing this if statement a LOT.
                if (useGUI)
                {
                    MessageDialog messageDialog = new MessageDialog();
                    messageDialog.label1.Text = "We couldn't find an author with that ID!";
                    messageDialog.ShowDialog();
                }
                else
                {
                    Console.WriteLine("We couldn't find an author with that ID!");
                }
                //leave the method since we didn't find an author to update.
                return;
            }

            string updateFirstName;
            string updateSurname;
            if (useGUI)
            {
                InputDialog inputDialog = new InputDialog();
                inputDialog.label1.Text = $"Enter the new First Name for the Author: \n(Old First Name: {updateList[intId - 1].FirstName})";
                inputDialog.ShowDialog();
                updateFirstName = inputDialog.boxInput;

                inputDialog = new InputDialog();
                inputDialog.label1.Text = $"Enter the new Surname of the Author: \n(Old Surname: {updateList[intId - 1].Surname})";
                inputDialog.ShowDialog();
                updateSurname = inputDialog.boxInput;
            }
            else 
            {
                Console.WriteLine("Enter the new First Name for the Author: ");
                Console.WriteLine("Old First Name: " + updateList[intId - 1].FirstName);
                updateFirstName = Console.ReadLine();

                Console.WriteLine("Enter the new Surname of the Author: ");
                Console.WriteLine("Old Surname: " + updateList[intId - 1].Surname);
                updateSurname = Console.ReadLine();
            }

            if (!String.IsNullOrWhiteSpace(updateFirstName) && !String.IsNullOrWhiteSpace(updateSurname))
            {
                Author updateAuthor = new Author(intId, updateFirstName.Trim(), updateSurname.Trim());
                queryBuilder.Update(updateAuthor);
            }
            else 
            {
                if (useGUI)
                {
                    MessageDialog messageDialog = new MessageDialog();
                    messageDialog.label1.Text = "One of the fields were null! \nReturning to the Menu.";
                    messageDialog.ShowDialog();
                }
                else
                {
                    Console.WriteLine("One of the fields were null! \nReturning to the Menu.");
                }
            }
        }

        /*
         * Allows the program to delete an author.
         * It is run through queryBuilder and also 
         * deletes the author from the Database.sqlite file.
         * 
         * Date Created: 03/24/2022
         */
        internal static void DeleteAuthor()
        {
            List<Author> deleteList = queryBuilder.ReadAll<Author>();
            string idDelete;
            int intId;

            if (useGUI)
            {
                //It would be easier to create 1 InputDialog for the entire method,
                //but I am unsure if making one outisde this would break the method for non-Window platforms.
                InputDialog inputDialog = new InputDialog();
                inputDialog.label1.Text = "Enter the ID of the Author you want to delete.";
                inputDialog.ShowDialog();
                //boxInput is set to the value inside the textbox after pressing the "Ok" button.
                idDelete = inputDialog.boxInput;
            }
            else
            {
                Console.WriteLine("Enter the ID of the Author you want to delete.");
                idDelete = Console.ReadLine();
            }

            //----------------------------------------------------------

            try
            {
                if (!String.IsNullOrWhiteSpace(idDelete))
                {
                    intId = int.Parse(idDelete);
                }
                else
                    intId = -1;

                if (intId <= 0 || intId > deleteList.Count())
                {
                    //We also print this error if the Id is out of bounds.
                    if (useGUI)
                    {
                        MessageDialog messageDialog = new MessageDialog();
                        messageDialog.label1.Text = "We couldn't find an author with that ID!";
                        messageDialog.ShowDialog();
                    }
                    else
                    {
                        Console.WriteLine("We couldn't find an author with that ID!");
                    }

                    //leave the method since we didn't find an author to delete.
                    return;
                }
            }
            catch (FormatException)
            {
                if (useGUI)
                {
                    MessageDialog messageDialog = new MessageDialog();
                    messageDialog.label1.Text = "We couldn't find an author with that ID!";
                    messageDialog.ShowDialog();
                }
                else
                {
                    Console.WriteLine("We couldn't find an author with that ID!");
                }

                //leave the method since we didn't find an author to delete.
                return;
            }

            //----------------------------------------------------------

            string deleteFirstName;
            if (useGUI)
            {
                InputDialog inputDialog = new InputDialog();
                inputDialog.label1.Text = "Confirm Deletion by typing in the Author's First Name: \nFirst Name: \"" + deleteList[intId - 1].FirstName + "\"";
                inputDialog.ShowDialog();
                deleteFirstName = inputDialog.boxInput;
            }
            else
            {
                Console.WriteLine("Confirm Deletion by typing in the Author's First Name: ");
                Console.WriteLine("First Name: " + deleteList[intId - 1].FirstName);
                deleteFirstName = Console.ReadLine();
            }

            //----------------------------------------------------------

            //Also includes input for if the user put double quotations around the surname.
            if (deleteFirstName != null && (deleteFirstName.Trim() == deleteList[intId - 1].FirstName || deleteFirstName.Trim() == "\"" + deleteList[intId - 1].FirstName + "\""))
            {
                string deleteSurname;

                if (useGUI)
                {
                    InputDialog inputDialog = new InputDialog();
                    inputDialog.label1.Text = "Confirm Deletion by typing in the Author's Surname: \nSurname: \"" + deleteList[intId - 1].Surname + "\"";
                    inputDialog.ShowDialog();
                    deleteSurname = inputDialog.boxInput;
                }
                else
                {
                    Console.WriteLine("Confirm Deletion by typing in the Author's Surname: ");
                    Console.WriteLine("Surname: " + deleteList[intId - 1].Surname);
                    deleteSurname = Console.ReadLine();
                }

                //Also includes input for if the user put double quotations around the surname.
                if (deleteSurname != null && (deleteSurname.Trim() == deleteList[intId - 1].Surname || deleteSurname.Trim() == "\"" + deleteList[intId - 1].Surname + "\""))
                {
                    Author deleteAuthor = new Author(intId, deleteList[intId - 1].FirstName.Trim(), deleteList[intId - 1].Surname.Trim());
                    queryBuilder.Delete<Author>(deleteAuthor);

                    return;
                }
                Console.WriteLine("Oops! The Surname was entered incorrectly.");
            }
            Console.WriteLine("Oops! The First Name was entered incorrectly.");
        }

        /*
         * Exits the Program and ends the application.
         * 
         * Date Created: 03/24/2022
         */
        internal static void Exit() 
        {
            if (useGUI)
            {
                MessageDialog messageDialog = new MessageDialog();
                messageDialog.label1.Text = "Thank you for using Sqlite Database and QueryBuilder!";
                messageDialog.ShowDialog();
            }
            else
            {
                Console.WriteLine("Thank you for using Sqlite Database and QueryBuilder!");
            }

            queryBuilder.Dispose();
            System.Environment.Exit(0);
        }
    }
}