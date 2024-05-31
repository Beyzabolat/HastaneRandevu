using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;
using System.Data.OleDb;

namespace LogicLayer
{
    public class LogicSec
    {
        public static List<EntitySec> LLSecList()
        {
            return DALSec.DALSecList();
        }
        public static int LLSecEkle(EntitySec p)
        {
            if (p.Secname != "" && p.Secsurname != "" && p.Secname.Length >= 3)
            {
                return DALSec.SecEkle(p);
            }
            else
            {
                return -1;
            }
        }

        public static bool LLSecSil(int per)
        {
            if (per >= 1)
            {
                return DALSec.SecSil(per);
            }
            else
            {
                return false;
            }
        }

        public static bool LLSecGuncelle(EntitySec ent)
        {
            if (ent.Secname.Length >= 3 && ent.Secname != "")
            {
                return DALSec.SecGuncelle(ent);
            }
            else
            {
                return false;
            }
        }
        public static int LLSecGiris(EntitySec p)
        {
            return DALSec.SecGiris(p);
        }
        public static string LLSekreterSifreAl(string email)
        {
            using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\admin\\Desktop\\HastaneRandevu\\HastaneRandevuKayıt.accdb;"))
            {
                string query = "SELECT SecPASSWORD FROM SecBilgi WHERE SecMAİL = @p1";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@p1", email);

                conn.Open();
                object result = cmd.ExecuteScalar();
                conn.Close();

                return result != null ? result.ToString() : null;
            }
        }
    }
}