using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using EntityLayer;

namespace DataAccessLayer
{
    public class DALDoc
    {
        public static List<EntityDoc> DALDocList()
        {
            List<EntityDoc> degerler = new List<EntityDoc>();
            OleDbCommand komut1 = new OleDbCommand("SELECT * FROM DocBilgi", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            OleDbDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityDoc ent = new EntityDoc();
                ent.Docid = Convert.ToInt32(dr["DocID"]);
                ent.Docname = dr["DocAD"].ToString();
                ent.Docsurname = dr["DocSOYAD"].ToString();
                ent.Docbranch = dr["DocBRANŞ"].ToString();
                ent.Docphone = dr["DocTELEFON"].ToString();
                ent.Docusername = dr["DocUSERNAME"].ToString();
                ent.Docpassword = dr["DocPASSWORD"].ToString();
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }

        public static OleDbCommand BolumHastaSayisiCek(string brans)
        {
            OleDbCommand komut2 = new OleDbCommand("SELECT Count(HastaID) FROM HastaBilgi WHERE HastaBÖLÜM=@P1", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1", brans);
            return komut2;
        }

        public static OleDbCommand DoktorAdıCek(EntityDoc p)
        {
            OleDbCommand komut2 = new OleDbCommand("SELECT DocAD FROM DocBilgi WHERE DocUSERNAME=@P1 AND DocPASSWORD=@P2", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1", p.Docusername);
            komut2.Parameters.AddWithValue("@P2", p.Docpassword);
            return komut2;
        }

        public static OleDbCommand DoktorSoyadıCek(EntityDoc p)
        {
            OleDbCommand komut2 = new OleDbCommand("SELECT DocSOYAD FROM DocBilgi WHERE DocUSERNAME=@P1 AND DocPASSWORD=@P2", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1", p.Docusername);
            komut2.Parameters.AddWithValue("@P2", p.Docpassword);
            return komut2;
        }

        public static int DocEkle(EntityDoc p)
        {
            OleDbCommand komut2 = new OleDbCommand("INSERT INTO DocBilgi(DocAD,DocSOYAD,DocBRANŞ,DocTELEFON,DocUSERNAME,DocPASSWORD) VALUES (@P1,@P2,@P3,@P4,@P5,@P6)", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1", p.Docname);
            komut2.Parameters.AddWithValue("@P2", p.Docsurname);
            komut2.Parameters.AddWithValue("@P3", p.Docbranch);
            komut2.Parameters.AddWithValue("@P4", p.Docphone);
            komut2.Parameters.AddWithValue("@P5", p.Docusername);
            komut2.Parameters.AddWithValue("@P6", p.Docpassword);
            return komut2.ExecuteNonQuery();
        }

        public static bool DocSil(int p)
        {
            OleDbCommand komut3 = new OleDbCommand("DELETE FROM DocBilgi WHERE DocID = @P1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@P1", p);
            return komut3.ExecuteNonQuery() > 0;
        }

        public static bool DocGuncelle(EntityDoc ent)
        {
            OleDbCommand komut4 = new OleDbCommand("UPDATE DocBilgi SET DocAD=@P1,DocSOYAD=@P2,DocBRANŞ=@P3,DocTELEFON=@P4,DocUSERNAME=@P5,DocPASSWORD=@P6 WHERE DocID=@P7", Baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@P1", ent.Docname);
            komut4.Parameters.AddWithValue("@P2", ent.Docsurname);
            komut4.Parameters.AddWithValue("@P3", ent.Docbranch);
            komut4.Parameters.AddWithValue("@P4", ent.Docphone);
            komut4.Parameters.AddWithValue("@P5", ent.Docusername);
            komut4.Parameters.AddWithValue("@P6", ent.Docpassword);
            komut4.Parameters.AddWithValue("@P7", ent.Docid);
            return komut4.ExecuteNonQuery() > 0;
        }

        public static int DoktorGiris(EntityDoc p)
        {
            Baglanti.bgl.Close();
            Baglanti.bgl.Open();
            OleDbCommand komut3 = new OleDbCommand("SELECT * FROM DocBilgi WHERE DocUSERNAME=@P1 AND DocPASSWORD=@P2", Baglanti.bgl);
            komut3.Parameters.AddWithValue("@P1", p.Docusername);
            komut3.Parameters.AddWithValue("@P2", p.Docpassword);
            OleDbDataReader dr = komut3.ExecuteReader();
            if (dr.Read())
            {
                EntityDoc doktor = new EntityDoc();
                doktor.Docid = Convert.ToInt32(dr["DocID"]);
                doktor.Docname = dr["DocAD"].ToString();
                doktor.Docsurname = dr["DocSOYAD"].ToString();
                doktor.Docusername = dr["DocUSERNAME"].ToString();
                doktor.Docpassword = dr["DocPASSWORD"].ToString();
                doktor.Docphone = dr["DocTELEFON"].ToString();
                doktor.Docbranch = dr["DocBRANŞ"].ToString();
                dr.Close();
                return 1;
            }
            else
            {
                dr.Close();
                return 2;
            }
        }
    }
}
