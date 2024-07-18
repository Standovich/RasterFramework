using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RasterFramework.Forms
{
    public partial class AddLineForm : Form
    {
        private List<String> listOfAlgorithms;
        private IEnumerable<Type> listOfClasses;

        public Type SelectedAlgorithm { get; set; }

        public AddLineForm(IEnumerable<Type> listOfTypes)
        {
            InitializeComponent();
            InitLists(listOfTypes);
        }

        private void InitLists(IEnumerable<Type> listOfTypes)
        {
            listOfClasses = listOfTypes;
            listOfAlgorithms = new List<String>();

            foreach (Type type in listOfTypes)
            {
                object lineClass = Activator.CreateInstance(type);
                MethodInfo methodInfo = type.GetMethod("GetName");
                var result = methodInfo.Invoke(lineClass, null);

                listOfAlgorithms.Add((string)result);
            }
        }

        private void AddLineForm_Load(object sender, EventArgs e)
        {
            foreach (string name in listOfAlgorithms)
            {
                lineSelectBox.Items.Add(name);
            }
        }
    }
}
