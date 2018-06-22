using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bingoo
{
    public partial class Form1 : Form
    {
        Random rd = new Random();

        private bool button3WasClicked=true; 

        public Form1()

        {

            InitializeComponent();
            button1.Visible = false;
            timer1.Interval = 300; //Başlangıç hızı
            para.Text = "50"; //Başlangıç parası
            button3.Visible = false;

    }

        private void button1_Click(object sender, EventArgs e)

        {

            int parahak = Convert.ToInt32(para.Text);

            parahak = parahak - 5;  // Her butona tıklamada parayı bir azaltıyor.
            para.Text = parahak.ToString(); // Ekrana yazıyor.
            button1.Text = "10"; //Başlangıç süresi

            timer1.Enabled = true;
            button3WasClicked = true;

          


        }

        private void timer1_Tick(object sender, EventArgs e)

        {
            int parahak = Convert.ToInt32(para.Text);           //TextBoxtaki textlerin alınıp integer bir değere convert edilip atanması

            int sure1 = Convert.ToInt32(button1.Text);
            sure1--; //Geri sayım 

            if (parahak >= 0) // Para sıfırdan büyükse işlemin başlaması aksi halde Paranız bitti yazdırması.

            {
                if (sure1 > 0) //Para sıfırdan büyük ve sürenin de sıfırdan büyük olma durumu

                {
                    button1.Enabled = false;         // Başlat butonuna oyun devam ederken bir daha basılmamasını sağlıyor.

                    foreach (Control item in this.Controls)     //Control mekanizmalarının foreach le döngüye sokulması.

                    {

                        if (item is Label)              //Control edilen itemin label olup olmama durumu
                        {

                            for (int i = 1; i < 5; i++)    // For döngüsüyle Rastgele sayılar türetilirken döngü halinde tekrarlaması
                            {
                                item.Text = rd.Next(0, 8).ToString();

                            }
                        }

                        if (item is Button)             //Control edilen itemin button olup olmama durumu
                        {
                            if (item.Name == "button2")        // Control edilen buttonun adının button2 olup olmadığı         
                            {

                                button1.Text = sure1.ToString();  //Sürenin her azaldığında text e yazılması

                                switch (sure1)      //Sürenin kontrolü ve süre 3,2,1 olduğunda giderek yavaşlaması.(Heyecan olsun diye):D
                                {
                                    case 3:
                                        {
                                            timer1.Interval = 500;
                                        }
                                        break;
                                    case 2:
                                        {
                                            timer1.Interval = 600;
                                        }
                                        break;

                                    case 0:
                                        {
                                            timer1.Enabled = false;         //Süre bittiyse zamanın durması
                                        }
                                        break;
                                    default:
                                        {
                                            timer1.Interval = 300;
                                        }
                                        break;
                                }
                            }

                        }
                    }
                }

                else
                {
                    
                    button1.Enabled = true;
                     //Süre sıfırdan küçükse oyun çalışıyor demek olduğundan butona birdaha basılamaz şekline getirme         
                          

                    int deger1 = Convert.ToInt32(label6.Text);
                    int deger2 = Convert.ToInt32(label13.Text);  //Eşleşebilecek labelların işlem yapabilmek için int olarak belirlenen sayılara atanması.
                    int deger3 = Convert.ToInt32(label21.Text);

                    if (deger1 == deger2 && deger2 == deger3 && deger1 == deger3)
                    {
                        if (button3WasClicked == true)           //3 sayıyın da eşit gelebilme durumu

                        {
                           
                            for (int i = 0; i < 5; i++)
                            {


                                if (label6.ForeColor == System.Drawing.Color.Black && label13.ForeColor == System.Drawing.Color.Black && label21.ForeColor == System.Drawing.Color.Black)
                                {
                                    label13.ForeColor = System.Drawing.Color.Red;
                                    label6.ForeColor = System.Drawing.Color.Red;
                                    label21.ForeColor = System.Drawing.Color.Red;
                                }
                                else
                                {
                                    label13.ForeColor = System.Drawing.Color.Black;
                                    label6.ForeColor = System.Drawing.Color.Black;
                                    label21.ForeColor = System.Drawing.Color.Black;
                                }


                               


                            }
                            button1.Enabled = false;
                            pictureBox2.Visible = true;
                            button3.Visible = true;

                        }
                    
                    else 
                    {
                        timer1.Enabled = false;     //oyunun durması
                        parahak = parahak + 30;     //Kazanılan paranın eklenmesi
                        para.Text = parahak.ToString(); //Kazanılan parayla birlikte şimdiki para
                        MessageBox.Show("Jackpot!! 30 Kredi Kazandın");
                        pictureBox2.Visible = false;
                            
                           

                    }

                    }


                    if ((deger1 == deger2 && deger1 != deger3 && deger2 != deger3) || (deger2 == deger3 && deger1 != deger3 && deger1 != deger3) || (deger1 == deger3 && deger2 != deger3 && deger1 != deger2))
                    {

                        if (button3WasClicked == true)      //2 sayıyın eşit gelebilme durumu

                        {
                            if (deger1 == deger2 && deger1 != deger3 && deger2 != deger3 && button3WasClicked == true)
                            {

                                for (int i = 0; i < 5; i++)
                                {


                                    if (label6.ForeColor == System.Drawing.Color.Black && label13.ForeColor == System.Drawing.Color.Black)
                                    {
                                        label13.ForeColor = System.Drawing.Color.Red;
                                        label6.ForeColor = System.Drawing.Color.Red;
                                    }
                                    else
                                    {
                                        label13.ForeColor = System.Drawing.Color.Black;
                                        label6.ForeColor = System.Drawing.Color.Black;
                                    }

                                }

                                button1.Enabled = false;
                                button3.Visible = true;

                            }
                            else if (deger2 == deger3 && deger1 != deger2 && deger1 != deger3 && button3WasClicked == true)
                            {
                                for (int i = 0; i < 5; i++)
                                {

                                    if (label21.ForeColor == System.Drawing.Color.Black && label13.ForeColor == System.Drawing.Color.Black)
                                    {
                                        label21.ForeColor = System.Drawing.Color.Red;
                                        label13.ForeColor = System.Drawing.Color.Red;
                                    }
                                    else
                                    {
                                        label21.ForeColor = System.Drawing.Color.Black;
                                        label13.ForeColor = System.Drawing.Color.Black;
                                    }

                                }
                                button1.Enabled = false;
                                button3.Visible = true;
                            }


                            else if (deger1 == deger3 && deger2 != deger3 && deger1 != deger2 && button3WasClicked == true)
                            {

                                for (int i = 0; i < 5; i++)
                                {

                                    if (label21.ForeColor == System.Drawing.Color.Black && label6.ForeColor == System.Drawing.Color.Black)
                                    {
                                        label21.ForeColor = System.Drawing.Color.Red;
                                        label6.ForeColor = System.Drawing.Color.Red;
                                    }
                                    else
                                    {
                                        label21.ForeColor = System.Drawing.Color.Black;
                                        label6.ForeColor = System.Drawing.Color.Black;
                                    }

                                }


                                button1.Enabled = false;
                                button3.Visible = true;
                            }

                        }
                        else if (button3WasClicked == false)
                        {

                            timer1.Enabled = false;
                            parahak = parahak + 15;
                            para.Text = parahak.ToString();
                            MessageBox.Show("Harikaaa 15 kredi kazandın");
                            button3WasClicked = true;
                            

                        }
                    }

                    if(deger1!=deger2 && deger2!=deger3 && deger1!=deger3)                        //Hiçbir sayının tutmama durumu

                    {

                        timer1.Enabled = false;            //Oyun durur.
                        MessageBox.Show("Bu sefer olmadı bir daha dene");

                    }
                }
            }

            else            //Paranın kalmaması durumu

            {
                button1.Enabled = false;     //Başla butonu saklanır.Basılamaz.
                timer1.Enabled = false;
                MessageBox.Show("Malesef krediniz kalmadı");

            }


        }

        private void button2_Click(object sender, EventArgs e)

        {

            button2.BackColor = Color.Green;
                     
            button2.Visible = false;
            button1.Visible = true;

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            button3WasClicked = false;
            label21.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label13.ForeColor = Color.Black;
            button1.Enabled = true;
            button3.Visible = false;
            

        }

        private void oyunKurallarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form kuralform = new Form2();
            kuralform.Show();
        }
    }
}


