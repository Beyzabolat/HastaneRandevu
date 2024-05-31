using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALHst
    {
        public static List<EntityHst> DALHstList()
        {
            List<EntityHst> degerler = new List<EntityHst>();
            OleDbCommand komut1 = new OleDbCommand("SELECT * FROM HastaBilgi", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            OleDbDataReader hst = komut1.ExecuteReader();
            while (hst.Read())
            {
                EntityHst ent = new EntityHst();
                ent.Hstid = Convert.ToInt32(hst["HastaID"]);
                ent.Hstname = hst["HastaAD"].ToString();
                ent.Hstsurname = hst["HastaSOYAD"].ToString();
                ent.Hsttckn = hst["HastaTCKN"].ToString();
                ent.Hstphone = hst["HastaTELEFON"].ToString();
                ent.Hstbolum = hst["HastaBÖLÜM"].ToString();
                ent.Docname = hst["DoktorADI"].ToString();
                ent.Tarih = Convert.ToDateTime(hst["Tarih"]);
                ent.Saat = hst["Saat"].ToString();
                ent.Rapor = hst["Rapor"].ToString();
                degerler.Add(ent);
            }
            hst.Close();
            return degerler;
        }

        public static int HstEkle(EntityHst p)
        {
            using (OleDbCommand komut2 = new OleDbCommand("INSERT INTO HastaBilgi(HastaAD, HastaSOYAD, HastaTCKN, HastaTELEFON, HastaBÖLÜM, DoktorADI, Tarih, Saat, Rapor) VALUES (@P1, @P2, @P3, @P4, @P5, @P6, @P7, @P8, @P9)", Baglanti.bgl))
            {
                if (komut2.Connection.State != ConnectionState.Open)
                {
                    komut2.Connection.Open();
                }

                komut2.Parameters.Add("@P1", OleDbType.VarChar).Value = p.Hstname;
                komut2.Parameters.Add("@P2", OleDbType.VarChar).Value = p.Hstsurname;
                komut2.Parameters.Add("@P3", OleDbType.VarChar).Value = p.Hsttckn;
                komut2.Parameters.Add("@P4", OleDbType.VarChar).Value = p.Hstphone;
                komut2.Parameters.Add("@P5", OleDbType.VarChar).Value = p.Hstbolum;
                komut2.Parameters.Add("@P6", OleDbType.VarChar).Value = p.Docname;

                if (p.Tarih is DateTime tarihValue)
                {
                    komut2.Parameters.Add("@P7", OleDbType.Date).Value = tarihValue;
                }
                else
                {
                    throw new ArgumentException("Tarih bir DateTime nesnesi olmalıdır");
                }

                komut2.Parameters.Add("@P8", OleDbType.VarChar).Value = p.Saat;
                komut2.Parameters.Add("@P9", OleDbType.VarChar).Value = p.Rapor;

                return komut2.ExecuteNonQuery();
            }
        }



        public static bool HstSil(int p)
        {
            OleDbCommand komut3 = new OleDbCommand("DELETE FROM HastaBilgi WHERE HASTAID = @P1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@P1", p);
            return komut3.ExecuteNonQuery() > 0;
        }

        public static bool HstGuncelle(EntityHst ent)
        {
            OleDbCommand komut4 = new OleDbCommand("UPDATE HastaBilgi SET HastaAD=@P1,HastaSOYAD=@P2,HastaTCKN=@P3,HastaTELEFON=@P4,HastaBÖLÜM=@P5,DoktorADI=@P6,Tarih=@P7,Saat=@P8 WHERE HASTAID=@P9", Baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@P1", ent.Hstname);
            komut4.Parameters.AddWithValue("@P2", ent.Hstsurname);
            komut4.Parameters.AddWithValue("@P3", ent.Hsttckn);
            komut4.Parameters.AddWithValue("@P4", ent.Hstphone);
            komut4.Parameters.AddWithValue("@P5", ent.Hstbolum);
            komut4.Parameters.AddWithValue("@P6", ent.Docname);
            komut4.Parameters.AddWithValue("@P7", ent.Tarih);
            komut4.Parameters.AddWithValue("@P8", ent.Saat);
            komut4.Parameters.AddWithValue("@P9", ent.Hstid);
            return komut4.ExecuteNonQuery() > 0;
        }

        public static OleDbDataReader filter(string Branch)
        {
            OleDbCommand komut5 = new OleDbCommand("SELECT * FROM DocBilgi WHERE DocBRANŞ = @P1", Baglanti.bgl);
            if (komut5.Connection.State != ConnectionState.Open)
            {
                komut5.Connection.Open();
            }
            komut5.Parameters.AddWithValue("@P1", Branch);
            OleDbDataReader dr = komut5.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        public static bool HstGuncelle2(EntityHst ent)
        {
            OleDbCommand komut4 = new OleDbCommand("UPDATE HastaBilgi SET Rapor=@P1 WHERE HASTAID=@P2", Baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@P1", ent.Rapor);
            komut4.Parameters.AddWithValue("@P2", ent.Hstid);
            return komut4.ExecuteNonQuery() > 0;
        }

        public static List<EntityHst> DALDoktoraGoreHstList(EntityDoc p)
        {
            List<EntityHst> degerler = new List<EntityHst>();
            OleDbCommand komut1 = new OleDbCommand("SELECT * FROM HastaBilgi WHERE DoktorADI=@P1", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            string adsoyad = p.Docname + " " + p.Docsurname;
            komut1.Parameters.AddWithValue("@P1", adsoyad);
            OleDbDataReader hst = komut1.ExecuteReader();
            while (hst.Read())
            {
                EntityHst ent = new EntityHst();
                ent.Hstid = Convert.ToInt32(hst["HastaID"]);
                ent.Hstname = hst["HastaAD"].ToString();
                ent.Hstsurname = hst["HastaSOYAD"].ToString();
                ent.Hsttckn = hst["HastaTCKN"].ToString();
                ent.Hstphone = hst["HastaTELEFON"].ToString();
                ent.Hstbolum = hst["HastaBÖLÜM"].ToString();
                ent.Docname = hst["DoktorADI"].ToString();
                ent.Tarih = Convert.ToDateTime(hst["Tarih"]);
                ent.Saat = hst["Saat"].ToString();
                ent.Rapor = hst["Rapor"].ToString();
                degerler.Add(ent);
            }
            hst.Close();
            return degerler;
        }
    }
}
