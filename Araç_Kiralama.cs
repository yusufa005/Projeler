using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace araçkrlm
{
    class Araç_Kiralama
    {
        SqlConnection baglanti = new SqlConnection("Data Source=YUSUFLAPTOP\\SQLEXPRESS;Initial Catalog=Araç_Kiralama;Integrated Security=True");
        DataTable tablo = new DataTable();
        public void ekle_sil_güncelle(SqlCommand komut, string sorgu)
        {
            try
            {
          
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = sorgu;
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
            catch
            {
                ;
            }


        }
        public DataTable listele(SqlDataAdapter adtr, string sorgu)
        {
            tablo = new DataTable();
            adtr = new SqlDataAdapter(sorgu,baglanti);
            adtr.Fill(tablo);
            baglanti.Close();
            return tablo; 
        }
        public void Boş_Araçlar(ComboBox combo, string sorgu )
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu,baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combo.Items.Add(read["plaka"].ToString());
            }
;baglanti.Close();
        }
        public void TC_ara(TextBox tcara,TextBox tc,TextBox adsoyad,TextBox telefon, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                tc.Text = read["tc"].ToString();
                adsoyad.Text = read["adsoyad"].ToString();
                telefon.Text=read["telefon"].ToString();

            }
; baglanti.Close();
         }
        public void ÜcretHesapla(ComboBox combokirasekli,TextBox ucret,string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (combokirasekli.SelectedIndex == 0) ucret.Text= (int.Parse(read["kiraucreti"].ToString()) * 0.1).ToString();
                if (combokirasekli.SelectedIndex == 1) ucret.Text = (int.Parse(read["kiraucreti"].ToString()) * 0.80).ToString();
                if (combokirasekli.SelectedIndex == 2) ucret.Text = (int.Parse(read["kiraucreti"].ToString()) * 0.70).ToString();


            }
; baglanti.Close();
        }
        public void CombodanGetir(ComboBox araçlar, TextBox marka, TextBox seri, TextBox yil, TextBox renk, string sorgu)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                marka.Text = read["marka"].ToString();
                seri.Text = read["seri"].ToString();
                yil.Text = read["yıl"].ToString();
                renk.Text = read["renk"].ToString();

            }
; baglanti.Close();
        }
        public void satışhesapla( Label lbl)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(tutar) from  satış ",baglanti);
            lbl.Text = "Toplam Tutar"+komut.ExecuteScalar()+"TL";
            baglanti.Close();
        }
    }
    }