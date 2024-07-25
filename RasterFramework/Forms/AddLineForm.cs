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
        private List<string> listOfAlgorithms;
        private IEnumerable<Type> listOfClasses;
        private Size maxSize;
        private bool EventsOff = false;

        public Type SelectedAlgorithm { get; set; }
        public Point PointA { get; set; }
        public Point PointB { get; set; }

        public AddLineForm(IEnumerable<Type> listOfTypes, Size maxSize)
        {
            InitializeComponent();
            InitLists(listOfTypes);
            this.maxSize = maxSize;
        }

        private void InitLists(IEnumerable<Type> listOfTypes)
        {
            listOfClasses = listOfTypes;
            listOfAlgorithms = new List<string>();

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
            EventsOff = true;

            foreach (string name in listOfAlgorithms)
            {
                lineSelectBox.Items.Add(name);
            }

            numLineX1.Maximum = maxSize.Width;
            numLineY1.Maximum = maxSize.Height;
            numLineX2.Maximum = maxSize.Width;
            numLineY2.Maximum = maxSize.Height;

            SelectedAlgorithm = listOfClasses.First();
            lineSelectBox.SelectedIndex = 0;

            EventsOff = false;
        }

        private void lineSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!EventsOff)
            {
                foreach (Type type in listOfClasses)
                {
                    object lineClass = Activator.CreateInstance(type);
                    MethodInfo methodInfo = type.GetMethod("GetName");
                    var result = methodInfo.Invoke(lineClass, null);

                    if ((string)result == lineSelectBox.SelectedItem.ToString())
                    {
                        SelectedAlgorithm = type;
                        break;
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            PointA = new((int)numLineX1.Value, (int)numLineY1.Value);
            PointB = new((int)numLineX2.Value, (int)numLineY2.Value);
        }
    }
}
