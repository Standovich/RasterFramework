namespace RasterFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            flPanel.Controls.Add(new ImageModul());
        }

        private void btnAddModul_Click(object sender, EventArgs e)
        {
            flPanel.Controls.Add(new ImageModul());
        }

        public void removeModul(ImageModul sender)
        {
            flPanel.Controls.Remove(sender);
        }
    }
}