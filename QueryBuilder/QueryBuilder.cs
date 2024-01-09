/**       
 * -------------------------------------------------------------------
 * 	   File name: QueryBuilder.cs
 * 	Project name: QueryBuilder
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/23/2022	
 *            Last Modified:    03/24/2022
 * -------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace QueryBuilder
{
    public class QueryBuilder : IDisposable
    {
        SqliteConnection connection;
        MessageDialog msgDialog = new MessageDialog();

        /*
         * The primary constructor of the QueryBuilder class.
         * 
         * Date Created: 03/23/2022
         * @param string locationOfDatabase
         */
        public QueryBuilder(string locationOfDatabase)
        {
            connection = new SqliteConnection($@"Data Source={locationOfDatabase}");
            Console.WriteLine("SqliteConnection setup successfully.");
            connection.Open();
        }


        /*
         * Reads a table row where the 
         * parameter id equals an id from the table
         * and returns the resulting value.
         * 
         * Date Created: 03/23/2022
         * @return T data
         */
        public T Read<T>(int id) where T : new()
        {
            var command = connection.CreateCommand();

            //Author SQL Example
            //SELECT *
            //FROM Author
            //WHERE Author.Id = (parameter id);
            command.CommandText = $"select * from {typeof(T).Name} where {typeof(T).Name}.Id = {id}";

            var reader = command.ExecuteReader();
            T data = new T();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    typeof(T).GetProperty(reader.GetName(i)).SetValue(data, reader.GetValue(i));
                }
            }
            reader.Close();

            return data;
        } //End of Read


        /*
         * Reads all items from the table and 
         * returns all items in a List Format.
         * 
         * Date Created: 03/23/2022
         * @return List<T> datas
         */
        public List<T> ReadAll<T>() where T : new()
        {
            var command = connection.CreateCommand();
            command.CommandText = $"select * from {typeof(T).Name}";

            var reader = command.ExecuteReader();

            T data;
            var datas = new List<T>();

            while (reader.Read())
            {
                data = new T();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    typeof(T).GetProperty(reader.GetName(i)).SetValue(data, reader.GetValue(i));
                }

                datas.Add(data);
            }
            reader.Close();

            return datas;
        } //End of ReadAll

        /*
         * Creates a new author and adds them to the database.
         * 
         * Date Created: 03/23/2022
         * Last Modified: 03/24/2022
         * @param T obj
         */
        public void Create<T>(T obj) where T : new()
        {
            var command = connection.CreateCommand();

            //sb will gather all the values from the properties of obj.
            StringBuilder sb = new StringBuilder();

            //Gets the properties of the object.
            var propInfo = obj.GetType().GetProperties();

            //We first append all the values to StringBuilder sb.
            for (int i = 0; i < propInfo.Length; i++)
            {
                sb.Append(propInfo[i].GetValue(obj) + ",");
            }

            //Then, we separate the values...
            string[] splitPropValues = sb.ToString().Split(',');

            //(by the way, we clear sb for the INSERT INTO (table) VALUES({sb})
            sb.Clear();

            //and attempt to parse them to see if they belong to another type.
            for (int i = 0; i < propInfo.Length; i++)
            {
                //First, attempt to parse the value into a DateOnly.
                try
                {
                    DateOnly date = DateOnly.Parse(splitPropValues[i]);

                    //If the parse didn't throw an error, we've got a date!
                    sb.Append($"TO_DATE({splitPropValues[i]})");
                }
                catch (FormatException)
                {
                    //If the DateOnly Parse failed, then we attempt to parse it into an Int64.
                    try
                    {
                        Int64 number = Int64.Parse(splitPropValues[i]);

                        //If the parse didn't throw an error, we've got a number!
                        sb.Append(number);
                    }
                    catch (FormatException)
                    {
                        //When both parses fail,
                        //we assume that this is a true string.
                        sb.Append($"\"{splitPropValues[i]}\"");
                    }
                }

                //Also, put a comma to separate the values if this is not the last value we're adding.
                if (i != propInfo.Length - 1)
                {
                    sb.Append(", ");
                }
            } //end for-loop

            //Voila! Our string is ready to be put in the SQL statement.
            Console.WriteLine("sb: \'" + sb.ToString() + "\'");

            //Slap the insertOperation into the Values(),
            command.CommandText = $"INSERT INTO {typeof(T).Name} VALUES({sb});";

            //(Just for reference. Prints out the command text.)
            Console.WriteLine("Command Run: " + command.CommandText);

            //And run the command, inserting the person into the database. Woo!
            command.ExecuteNonQuery();


            if (Program.useGUI)
            {
                msgDialog.label1.Text = "The Object has been Created!";
                msgDialog.ShowDialog();
            }
            else
            {
                Console.WriteLine("The Object has been Created!");
            }
        } //End of Create


        /*
         * Updates an existing object, as well as their instance in the Database.
         * 
         * Date Created: 03/23/2022
         * Last Modified: 03/24/2022
         * @param T obj
         */
        public void Update<T>(T obj) where T : new()
        {
            //We use a simliar algorithm to the Create method.
            var command = connection.CreateCommand();
            command.CommandText = $"select * from {typeof(T).Name}";
            var reader = command.ExecuteReader();

            //sb will gather all the values from the properties of obj.
            StringBuilder sb = new StringBuilder();

            //Gets the properties of the object.
            var propInfo = obj.GetType().GetProperties();
            List<string> columnNames = new List<string>();
            List<string> columnValues = new List<string>();

            T data;
            var datas = new List<T>();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                columnNames.Add(reader.GetName(i));
                columnValues.Add(propInfo[i].GetValue(obj).ToString());
            }

            reader.Close();

            //Check that we have the names and values in our lists.
            for (int i = 0; i < columnNames.Count; i++)
            {
                Console.WriteLine("Column Name: " + columnNames[i] + " | Column Value: " + columnValues[i]);
            }

            //Afterward, we use sb to setup the magic.
            //We attempt to parse values to see if they belong to another type.
            //We skip index 0 because that's the Id. We don't need to change that.
            for (int i = 1; i < propInfo.Length; i++)
            {
                sb.Append(columnNames[i] + " = ");

                //First, attempt to parse the value into a DateOnly.
                try
                {
                    DateOnly date = DateOnly.Parse(columnValues[i]);

                    //If the parse didn't throw an error, we've got a date!
                    sb.Append($"TO_DATE({columnValues[i]})");
                }
                catch (FormatException)
                {
                    //If the DateOnly Parse failed, then we attempt to parse it into an Int64.
                    try
                    {
                        Int64 number = Int64.Parse(columnValues[i]);

                        //If the parse didn't throw an error, we've got a number!
                        sb.Append(number);
                    }
                    catch (FormatException)
                    {
                        //When both parses fail,
                        //we assume that this is a true string.
                        sb.Append($"\"{columnValues[i]}\"");
                    }
                }

                //Also, put a comma to separate the values if this is not the last value we're adding.
                if (i != propInfo.Length - 1)
                {
                    sb.Append(", ");
                }
            } //end for-loop

            //Voila! Our string is ready to be put in the SQL statement.
            Console.WriteLine("Set Rules: \'" + sb.ToString() + "\'");

            //Slap the sb and the id into the Update statement,
            command.CommandText = $"UPDATE {typeof(T).Name} SET {sb} WHERE({typeof(T).Name}.Id = {columnValues[0]});";

            //(Just for reference. Prints out the command text.)
            Console.WriteLine("Command Run: " + command.CommandText);

            //And run the command, inserting the person into the database. Woo!
            command.ExecuteNonQuery();


            if (Program.useGUI)
            {
                msgDialog.label1.Text = "The Object has been Updated!";
                msgDialog.ShowDialog();
            }
            else
            {
                Console.WriteLine("The Object has been Updated!");
            }

        } //End of Update


        /*
         * Deletes an existing object as well as their instance in the Database.
         * 
         * Date Created: 03/23/2022
         * @param T obj
         */
        public void Delete<T>(T obj)
        {
            //DELETE is basically the UPDATE method with less steps.
            //However, we also implement an algorithm that, upon deletion of an instance,
            //instances with higher ids than the deleted instance are shifted down by 1.


            var command = connection.CreateCommand();
            command.CommandText = $"select * from {typeof(T).Name}";
            var reader = command.ExecuteReader();

            //important for determining the total amount of rows in the schema.
            //for some reason, connection.GetSchema().Rows.Count is not accurate.
            int amountOfRows = 0;

            //Gets the properties of the object.
            var propInfo = obj.GetType().GetProperties();
            List<string> columnNames = new List<string>();
            List<string> columnValues = new List<string>();

            T data;
            var datas = new List<T>();

            //In the case of delete, we only need the id.
            for (int i = 0; i < 1; i++)
            {
                columnNames.Add(reader.GetName(i));
                columnValues.Add(propInfo[i].GetValue(obj).ToString());
                amountOfRows++;
            }

            //increment amountOfRows while there are still rows to read.
            while (reader.Read()) 
            {
                amountOfRows++;
            }

            reader.Close();

            //Check that we have the names and values in our lists.
            for (int i = 0; i < columnNames.Count; i++)
            {
                Console.WriteLine("Column Name: " + columnNames[i] + " | Column Value: " + columnValues[i]);
            }

            //No need to append anything. The algorithm from Create and Update is not needed here.

            //Same step as in Update, except we delete the value with that same ID.
            command.CommandText = $"DELETE FROM {typeof(T).Name} WHERE({typeof(T).Name}.Id = {columnValues[0]});";

            //See that the command is formatted correctly.
            Console.WriteLine("Command Run: " + command.CommandText);

            //Run the command, deleting the person from the database.
            command.ExecuteNonQuery();

            if (Program.useGUI)
            {
                msgDialog.label1.Text = "The Object has been Deleted!";
                msgDialog.ShowDialog();
            }
            else
            {
                Console.WriteLine("The Object has been Deleted!");
            }


            //But, our job isn't done yet! There's an ID gap because we deleted that instance!
            //Based on the way that Program is built, we'd break the unique constraint of ID if we inserted after deleting!
            //So, we include this algorithm to shift down and fit the missing ID.
            try
            {
                //We automatically shuffle instances with a higher ID than the deleted instance 1 step down.
                //We start on the index after the one we deleted.
                //For example, if we deleted index 4, we start at index 5.
                //This is unique to the DELETE method.
                for (int i = int.Parse(columnValues[0]) + 1; i < amountOfRows; i++)
                {
                    //(typeof(T).Name is the table name)
                    //For example, if we deleted index 4, our first command looks like:
                    //UPDATE Author SET Id 4 WHERE Author.Id = 5;
                    command.CommandText = $"UPDATE {typeof(T).Name} SET Id = {i-1} WHERE({typeof(T).Name}.Id = {i});";

                    //Show that the command is formatted properly.
                    Console.WriteLine("Command Run: " + command.CommandText);

                    //run the command.
                    command.ExecuteNonQuery();
                }
            }
            catch (IndexOutOfRangeException)
            {
                //If someone deleted an object on the last index, this gets thrown. 
                //In that case, we don't need to shuffle anything down, so we skip the for-loop.
            }

        } //End of Delete

        /*
         * Closes the connection class and 
         * frees up some resources.
         * 
         * Date Created: 03/23/2022
         */
        public void Dispose()
        {
            msgDialog.Dispose();
            connection.Close();
        }
    }
}
