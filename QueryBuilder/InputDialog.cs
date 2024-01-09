/**       
 * -------------------------------------------------------------------
 * 	   File name: InputDialog.cs
 * 	Project name: QueryBuilder
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/24/2022	
 *            Last Modified:    03/24/2022
 * -------------------------------------------------------------------
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueryBuilder
{
    public partial class InputDialog : Form
    {
        internal string boxInput { get; private set; }
        /*
         * The base constructor for InputDialog.
         * 
         * Date Created: 03/24/2022
         */
        public InputDialog()
        {
            InitializeComponent();

            //Everytime an InputDialog is opened, the textbox will automatically be highlighted.
            this.ActiveControl = textBox1;
        }

        /*
         * References the "Ok" Button.
         * This method is called when the user clicks on the "Ok" Button. 
         * (This is an EventHandler Method)
         * 
         * Sets boxInput to the value in the textbox and closes the prompt.
         * 
         * Date Created: 03/24/2022
         */
        private void button1_Click(object sender, EventArgs e)
        {
            boxInput = textBox1.Text;
            Close();
        }
    }
}
