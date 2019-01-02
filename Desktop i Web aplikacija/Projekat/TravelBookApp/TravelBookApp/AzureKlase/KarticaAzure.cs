using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApp.Model;

namespace TravelBookApp.AzureKlase
{
    public class KarticaAzure
    {
        public String id { get; set; }
        public String vrstaKartice { get; set; }
        public String datumIsteka { get; set; }
        public String broj { get; set; }
        public double csc { get; set; }

        public KarticaAzure() { }
        public KarticaAzure(String _id, String _vrstaKartice, String _datumIsteka, String _broj, int _csc)
        {
            id = _id;
            vrstaKartice = _vrstaKartice;
            datumIsteka = _datumIsteka;
            broj = _broj;
            csc = _csc;
        }
        public void UcitajKartice()
        {
            try
            {               
                string query = "SELECT * FROM KarticaAzure";
                ConnectionStringAzure s = new ConnectionStringAzure();           
                using (SqlConnection c = new SqlConnection(s.konekcija))
                {
                    c.Open();                   
                    if (c.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand sc = c.CreateCommand();
                        sc.CommandText = query;
                        SqlDataReader reader = sc.ExecuteReader(); 
                        while (reader.Read())
                        {
                            VrstaKartice vrsta = (VrstaKartice)Enum.Parse(typeof(VrstaKartice), reader.GetString(5));                           
                            Kartica k = new Kartica(vrsta, reader.GetString(6), reader.GetString(7), reader.GetDouble(8));                         
                            Globalna.nasaAgencija.Kartice.Add(k);                   
                        }
                        if (Globalna.nasaAgencija.Kartice.Count == 0) Globalna.idSvihKartica = 0;
                        else if (Globalna.nasaAgencija.Kartice.Count != 0) Globalna.idSvihKartica = Globalna.nasaAgencija.Kartice.Count;
                    }
                    c.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception KarticaAzure1: " + e.Message);
            }
        }

        public int dodajKarticu(Kartica k)
        {
            try
            {
                String query = "INSERT INTO KarticaAzure(id,vrstaKartice,datumIsteka,broj,csc) " + "VALUES (@id,@vrstaKartice,@datumIsteka,@broj,@csc)";
                ConnectionStringAzure s = new ConnectionStringAzure();
                using (SqlConnection con = new SqlConnection(s.konekcija))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter id = new SqlParameter();
                    id.Value = k.Id.ToString();
                    id.ParameterName = "id";
                    cmd.Parameters.Add(id);

                    SqlParameter vrstaKartice = new SqlParameter();
                    vrstaKartice.Value = k.Vrsta.ToString();
                    vrstaKartice.ParameterName = "vrstaKartice";
                    cmd.Parameters.Add(vrstaKartice);

                    SqlParameter datumIsteka = new SqlParameter();
                    datumIsteka.Value = k.DatumIsteka;
                    datumIsteka.ParameterName = "datumIsteka";
                    cmd.Parameters.Add(datumIsteka);

                    SqlParameter broj = new SqlParameter();
                    broj.Value = k.Broj;
                    broj.ParameterName = "broj";
                    cmd.Parameters.Add(broj);

                    SqlParameter csc = new SqlParameter();
                    csc.Value = k.Csc;
                    csc.ParameterName = "csc";
                    cmd.Parameters.Add(csc);

                    con.Open();
                    
                    int r = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    return r;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception KarticaAzure2: " + e.Message);
                return 0;
            }          
        }
    }
}
