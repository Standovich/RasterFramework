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
    public partial class AddCurveForm : Form
    {
        private List<string> listOfAlgorithms;
        private IEnumerable<Type> listOfClasses;
        private Size maxSize;
        private bool EventsOff = false;

        public Type SelectedAlgorithm { get; set; }
        public List<Point> Points { get; set; }
        public AddCurveForm(IEnumerable<Type> listOfTypes, Size maxSize)
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

        private void AddCurveForm_Load(object sender, EventArgs e)
        {
            EventsOff = true;

            foreach (string name in listOfAlgorithms)
            {
                curveSelectBox.Items.Add(name);
            }

            Points = new List<Point>();
            numPointX.Maximum = maxSize.Width;
            numPointY.Maximum = maxSize.Height;

            SelectedAlgorithm = listOfClasses.First();
            curveSelectBox.SelectedIndex = 0;

            EventsOff = false;
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            Point newPoint = new((int)numPointX.Value, (int)numPointY.Value);
            Points.Add(newPoint);
            pointsListBox.Items.Add(newPoint);
        }

        private void curveSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!EventsOff)
            {
                foreach (Type type in listOfClasses)
                {
                    object lineClass = Activator.CreateInstance(type);
                    MethodInfo methodInfo = type.GetMethod("GetName");
                    var result = methodInfo.Invoke(lineClass, null);

                    if ((string)result == curveSelectBox.SelectedItem.ToString())
                    {
                        SelectedAlgorithm = type;
                        break;
                    }
                }
            }
        }
    }
}
