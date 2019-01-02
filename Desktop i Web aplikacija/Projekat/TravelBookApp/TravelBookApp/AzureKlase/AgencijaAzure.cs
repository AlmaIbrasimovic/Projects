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
    public class AgencijaAzure
    {
        public String id { get; set; }
        public String naziv { get; set; }
        public String idKartica { get; set; }
        public String telefon { get; set; }
        public String grad { get; set; }
        public String lokacija { get; set; }
        public String sifra { get; set; }
        public String email { get; set; }

        public AgencijaAzure() { }
        public AgencijaAzure(String _id, String _naziv, String _idKartica, String _telefon, String _grad, String _lokacija, String _sifra,String _email)
        {
            id = _id;
            naziv = _naziv;
            idKartica = _idKartica;
            telefon = _telefon;
            grad = _grad;
            lokacija = _lokacija;
            sifra = _sifra;
            email = _email;
        }

        public void UcitajAgencije()
        {
            try
            {
                string query = "SELECT * FROM AgencijaAzure;";
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
                            for(int i = 0; i < Globalna.nasaAgencija.Kartice.Count; i++)
                            {                              
                                if (Globalna.nasaAgencija.Kartice[i].Id.ToString() == reader.GetString(6))
                                {
                                    index = i;
                                    break;
                                }
                            }
                            Agencija a = new Agencija(reader.GetString(5), Globalna.nasaAgencija.Kartice[index], reader.GetString(7), reader.GetString(11), reader.GetString(8), reader.GetString(9), reader.GetString(10));
                            Globalna.nasaAgencija.Agencije.Add(a);
                        }                       
                    }
                    c.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception AgencijaAzure1: " + e.Message);
            }
        }

        public int dodajAgenciju(Agencija a)
        {
            try
            {
                String query = "insert into AgencijaAzure(id,naziv,idKartica,telefon,grad,lokacija,sifra,email) " + "values (@id,@naziv,@idKartica,@telefon,@grad,@lokacija,@sifra,@email)";
                ConnectionStringAzure s = new ConnectionStringAzure();
                using (SqlConnection con = new SqlConnection(s.konekcija))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter id = new SqlParameter();
                    id.Value = a.Id.ToString();
                    id.ParameterName = "id";
                    cmd.Parameters.Add(id);
                   
                    SqlParameter naziv = new SqlParameter();
                    naziv.Value = a.NazivAgencije;
                    naziv.ParameterName = "naziv";
                    cmd.Parameters.Add(naziv);
                   
                    SqlParameter idKartica = new SqlParameter();
                    idKartica.Value = a.PodaciOBankovnomRacunu.Id.ToString();
                    idKartica.ParameterName = "idKartica";
                    cmd.Parameters.Add(idKartica);
                   
                    SqlParameter broj = new SqlParameter();
                    broj.Value = a.KontaktTelefon;
                    broj.ParameterName = "telefon";
                    cmd.Parameters.Add(broj);
                   
                    SqlParameter grad = new SqlParameter();
                    grad.Value = a.Grad;
                    grad.ParameterName = "grad";
                    cmd.Parameters.Add(grad);
                    
                    SqlParameter lokacija = new SqlParameter();
                    lokacija.Value = a.Lokacija.ToString();
                    lokacija.ParameterName = "lokacija";
                    cmd.Parameters.Add(lokacija);
                 
                    SqlParameter sifra = new SqlParameter();
                    sifra.Value = a.Sifra;
                    sifra.ParameterName = "sifra";
                    cmd.Parameters.Add(sifra);
                 
                    SqlParameter email = new SqlParameter();
                    email.Value = a.EmailAdresa;
                    email.ParameterName = "email";
                    cmd.Parameters.Add(email);
                 
                    con.Open();
                    int r = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();
                    return r;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception AgencijaAzure2: " + e.Message);
                return 0;
            }
        }
    }
}