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
    public class DALSec
    {
        public static List<EntitySec> DALSecList()
        {
            List<EntitySec> degerler = new List<EntitySec>();
            OleDbCommand komut1 = new OleDbCommand("SELECT * FROM SecBilgi", Baglanti.bgl);
            if (komut1.Connection.State != ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            OleDbDataReader sec = komut1.ExecuteReader();
            while (sec.Read())
            {
                EntitySec ent = new EntitySec();
                ent.Secid = Convert.ToInt32(sec["SecID"]);
                ent.Secname = sec["SecAD"].ToString();
                ent.Secsurname = sec["SecSOYAD"].ToString();
                ent.Secphone = sec["SecTELEFON"].ToString();
                ent.Secusername = sec["SecUSERNAME"].ToString();
                ent.Secpassword = sec["SecPASSWORD"].ToString();
                degerler.Add(ent);
            }
            sec.Close();
            return degerler;
        }

        public static int SecEkle(EntitySec p)
        {
            OleDbCommand komut2 = new OleDbCommand("INSERT INTO SecBilgi(SecAD,SecSOYAD,SecTELEFON,SecUSERNAME,SecPASSWORD) VALUES (@P1,@P2,@P3,@P4,@P5)", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@P1", p.Secname);
            komut2.Parameters.AddWithValue("@P2", p.Secsurname);
            komut2.Parameters.AddWithValue("@P3", p.Secphone);
            komut2.Parameters.AddWithValue("@P4", p.Secusername);
            komut2.Parameters.AddWithValue("@P5", p.Secpassword);
            return komut2.ExecuteNonQuery();
        }
        public static bool SecSil(int p)
        {
            OleDbCommand komut3 = new OleDbCommand("DELETE FROM SecBilgi WHERE SecID = @P1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@P1", p);
            return komut3.ExecuteNonQuery() > 0;
        }

        public static bool SecGuncelle(EntitySec ent)
        {
            OleDbCommand komut4 = new OleDbCommand("UPDATE SecBilgi SET SecAD=@P1,SecSOYAD=@P2,SecTELEFON=@P3,SecUSERNAME=@P4,SecPASSWORD=@P5 WHERE SecID=@P6", Baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@P1", ent.Secname);
            komut4.Parameters.AddWithValue("@P2", ent.Secsurname);
            komut4.Parameters.AddWithValue("@P3", ent.Secphone);
            komut4.Parameters.AddWithValue("@P4", ent.Secusername);
            komut4.Parameters.AddWithValue("@P5", ent.Secpassword);
            komut4.Parameters.AddWithValue("@P6", ent.Secid);
            return komut4.ExecuteNonQuery() > 0;
        }
        public static int SecGiris(EntitySec p)
        {
            Baglanti.bgl.Close();
            Baglanti.bgl.Open();
            OleDbCommand komut3 = new OleDbCommand("SELECT * FROM SecBilgi WHERE SecUSERNAME=@P1 AND SecPASSWORD=@P2", Baglanti.bgl);
            komut3.Parameters.AddWithValue("@P1", p.Secusername);
            komut3.Parameters.AddWithValue("@P2", p.Secpassword);
            OleDbDataReader sec = komut3.ExecuteReader();
            if (sec.Read())
            {
                EntitySec sekreter = new EntitySec();
                sekreter.Secid = Convert.ToInt16(sec["SecID"]);
                sekreter.Secname = Convert.ToString(sec["SecAD"]);
                sekreter.Secsurname = Convert.ToString(sec["SecSOYAD"]);
                sekreter.Secusername = Convert.ToString(sec["SecUSERNAME"]);
                sekreter.Secpassword = Convert.ToString(sec["SecPASSWORD"]);
                sekreter.Secphone = Convert.ToString(sec["SecTELEFON"]);
                sec.Close();
                return 1;
            }
            else
            {
                sec.Close();
                return 2;
            }
        }
    }
}
