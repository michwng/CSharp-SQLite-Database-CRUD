/**       
 * -------------------------------------------------------------------
 * 	   File name: MessageDialog.cs
 * 	Project name: FormTemplate
 * -------------------------------------------------------------------
 *  Author’s name and email:    Michael Ng, ngmw01@etsu.edu			
 *            Creation Date:	03/20/2022	
 *            Last Modified:    03/20/2022
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
    public partial class MessageDialog : Form
    {
        public MessageDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
