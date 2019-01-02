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
    public class PrevozAzure
    {
        public string id { get; set; }
        public string ime { get; set; }
        public string vrstaPrevoza { get; set; }
        public int maxKapacitet { get; set; }
        public int kapacitet { get; set; }
        public double cijena { get; set; }
        public string idDestinacije { get; set; }
        public PrevozAzure() { }

        public PrevozAzure(string _id, string _ime, string _vrstaPrevoza, int _maxKapacitet, int _kapacitet, double _cijena, string _idDestinacije)
        {
            id = _id;
            ime = _ime;
            vrstaPrevoza = _vrstaPrevoza;
            maxKapacitet = _maxKapacitet;
            kapacitet = _kapacitet;
            cijena = _cijena;
            idDestinacije = _idDestinacije;
        }
        public void UcitajPrevoze()
        {
            try
            {
                string query = "SELECT * FROM PrevozAzure;";
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
                            VrstaPrevoza vrsta = (VrstaPrevoza)Enum.Parse(typeof(VrstaPrevoza), reader.GetString(6));                         
                            Prevoz p = new Prevoz(reader.GetString(5), vrsta, Convert.ToInt32(reader.GetDouble(7)), Convert.ToInt32(reader.GetDouble(8)), reader.GetDouble(9),reader.GetString(10));
                            Globalna.nasaAgencija.Prevozi.Add(p);
                        }
                        if (Globalna.nasaAgencija.Prevozi.Count == 0) Globalna.idSvihPrevoza = 0;
                        else if (Globalna.nasaAgencija.Prevozi.Count != 0) Globalna.idSvihPrevoza = Globalna.nasaAgencija.Prevozi.Count;
                    }
                    c.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception PrevozAzure1: " + e.Message);
            }
        }

        public int dodajPrevoz(Prevoz p)
        {
            try
            {
                String query = "insert into PrevozAzure(id,ime,vrstaPrevoza,maxKapacitet,kapacitet,cijena,idDestinacije) "+  "values (@id,@ime,@vrstaPrevoza,@maxKapacitet,@kapacitet,@cijena,@idDestinacije)";
                ConnectionStringAzure s = new ConnectionStringAzure();
                using (SqlConnection con = new SqlConnection(s.konekcija))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter id = new SqlParameter();
                    id.Value = p.Id;
                    id.ParameterName = "id";
                    cmd.Parameters.Add(id);

                    SqlParameter ime = new SqlParameter();
                    ime.Value = p.Ime;
                    ime.ParameterName = "ime";
                    cmd.Parameters.Add(ime);

                    SqlParameter vrstaPrevoza = new SqlParameter();
                    vrstaPrevoza.Value = p.VrstaPrevoza;
                    vrstaPrevoza.ParameterName = "vrstaPrevoza";
                    cmd.Parameters.Add(vrstaPrevoza);

                    SqlParameter maxKapacitet = new SqlParameter();
                    maxKapacitet.Value = p.MaximalniKapacitet;
                    maxKapacitet.ParameterName = "maxKapacitet";
                    cmd.Parameters.Add(maxKapacitet);

                    SqlParameter kapacitet = new SqlParameter();
                    kapacitet.Value = p.Kapacitet;
                    kapacitet.ParameterName = "kapacitet";
                    cmd.Parameters.Add(kapacitet);

                    SqlParameter cijena = new SqlParameter();
                    cijena.Value = p.CijenaPoOsobi;
                    cijena.ParameterName = "cijena";
                    cmd.Parameters.Add(cijena);

                    SqlParameter idDestinacije = new SqlParameter();
                    idDestinacije.Value = p.PrevozDestinacija;
                    idDestinacije.ParameterName = "idDestinacije";
                    cmd.Parameters.Add(idDestinacije);

                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    return r;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception PrevozAzure2: " + e.Message);
                return 0;
            }
        }
    }
}
