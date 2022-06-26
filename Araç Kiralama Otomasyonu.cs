namespace araçkrlm
{
    public partial class frmanasayfa : Form
    {
        public frmanasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMüsteri ekle = new frmMüsteri();
            ekle.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmMüsteriListele listele = new FrmMüsteriListele();
            listele.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAraçKayıt kayıt = new frmAraçKayıt();
            kayıt.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAraçListele listele = new frmAraçListele();
            listele.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSözlesme sözlesme = new frmSözlesme();
            sözlesme.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSatış satış = new frmSatış();
            satış.ShowDialog();
        }
    }
}