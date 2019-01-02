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
    public class HotelAzure
    {
        public string id { get; set; }
        public string ime { get; set; }
        public int maxKapacitet { get; set; }
        public int kapacitet { get; set; }
        public string idDestinacije { get; set; }
        public double cijena { get; set; }
        public string slika { get; set; }

        public HotelAzure() { }

        public HotelAzure(string _id, string _ime, int _maxKapacitet, int _kapacitet, string _idDestinacije, double _cijena, string _slika = "")
        {
            id = _id;
            ime = _ime;
            slika = _slika;
            maxKapacitet = _maxKapacitet;
            kapacitet = _kapacitet;
            idDestinacije = _idDestinacije;
            cijena = _cijena;
        }
        public void UcitajHotele()
        {
            try
            {
                string query = "SELECT * FROM HotelAzure;";
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
                            int index = -1;
                            for (int i = 0; i < Globalna.nasaAgencija.Destinacije.Count; i++)
                            {
                                if (Globalna.nasaAgencija.Destinacije[i].Id.ToString() == reader.GetString(9))
                                {
                                    index = i;
                                    break;
                                }
                            }
                            Hotel h = new Hotel(reader.GetString(5), Convert.ToInt32(reader.GetDouble(7)), Convert.ToInt32(reader.GetDouble(8)), Globalna.nasaAgencija.Destinacije[index], reader.GetDouble(10));
                            //slika getString(6)
                            Globalna.nasaAgencija.Hoteli.Add(h);
                        }
                        if (Globalna.nasaAgencija.Hoteli.Count == 0) Globalna.idSvihHotela = 0;
                        else if (Globalna.nasaAgencija.Hoteli.Count != 0) Globalna.idSvihHotela = Globalna.nasaAgencija.Hoteli.Count;
                    }
                    c.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception HotelAzure1: " + e.Message);
            }
        }

        public int dodajHotel(Hotel h)
        {
            try
            {
                String query = "insert into HotelAzure(id,ime,slika,maxKapacitet,kapacitet,idDestinacije,cijena) " + "values (@id,@ime,@slika,@maxKapacitet,@kapacitet,@idDestinacije,@cijena)";
                ConnectionStringAzure s = new ConnectionStringAzure();
                using (SqlConnection con = new SqlConnection(s.konekcija))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter id = new SqlParameter();
                    id.Value = h.Id;
                    id.ParameterName = "id";
                    cmd.Parameters.Add(id);

                    SqlParameter ime = new SqlParameter();
                    ime.Value = h.Ime;
                    ime.ParameterName = "ime";
                    cmd.Parameters.Add(ime);

                    SqlParameter slika = new SqlParameter();
                    slika.Value = "not null slika";  
                    slika.ParameterName = "slika";
                    cmd.Parameters.Add(slika);

                    SqlParameter maxKapacitet = new SqlParameter();
                    maxKapacitet.Value = h.MaximalniKapacitet;
                    maxKapacitet.ParameterName = "maxKapacitet";
                    cmd.Parameters.Add(maxKapacitet);

                    SqlParameter kapacitet = new SqlParameter();
                    kapacitet.Value = h.Kapacitet;
                    kapacitet.ParameterName = "kapacitet";
                    cmd.Parameters.Add(kapacitet);

                    SqlParameter idDestinacije = new SqlParameter();
                    idDestinacije.Value = h.Lokacija.Id;
                    idDestinacije.ParameterName = "idDestinacije";
                    cmd.Parameters.Add(idDestinacije);

                    SqlParameter cijena = new SqlParameter();
                    cijena.Value = h.CijenaPoOsobi;
                    cijena.ParameterName = "cijena";
                    cmd.Parameters.Add(cijena);

                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    return r;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception HotelAzure2: " + e.Message);
                return 0;
            }
        }
    }
}
