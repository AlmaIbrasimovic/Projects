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
    public class PutovanjeAzure
    {
        public string id { get; set; }
        public DateTime datumPolaska { get; set; }
        public DateTime datumPovratka { get; set; }
        public int minBrojPutnika { get; set; }
        public int maxBrojPutnika { get; set; }
        public string opisPutovanja { get; set; }
        public Boolean istaknuto { get; set; }
        public string idAgencije { get; set; }
        public string idDestinacije { get; set; }
        public string idHotela { get; set; }
        public string idPrevoz { get; set; }
        public Double cijena { get; set; }
        
        public PutovanjeAzure() { }

        public PutovanjeAzure(string id, DateTime datumPolaska, DateTime datumPovratka, int minBrojPutnika, int maxBrojPutnika, string opisPutovanja, bool istaknuto, string idAgencije, string idDestinacije, string idHotela, string idPrevoz, Double cijena)
        {
            this.id = id;
            this.datumPolaska = datumPolaska;
            this.datumPovratka = datumPovratka;
            this.minBrojPutnika = minBrojPutnika;
            this.maxBrojPutnika = maxBrojPutnika;
            this.opisPutovanja = opisPutovanja;
            this.istaknuto = istaknuto;
            this.idAgencije = idAgencije;
            this.idDestinacije = idDestinacije;
            this.idHotela = idHotela;
            this.idPrevoz = idPrevoz;
            this.cijena = cijena;
        }

        public void UcitajPutovanja()
        {
            try
            {
                string query = "SELECT * FROM PutovanjeAzure;";
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
                                if (Globalna.nasaAgencija.Destinacije[i].Id.ToString() == reader.GetString(12))
                                {
                                    index = i;
                                    break;
                                }
                            }
                            int index2 = -1;
                            for (int i = 0; i < Globalna.nasaAgencija.Hoteli.Count; i++)
                            {
                                if (Globalna.nasaAgencija.Hoteli[i].Id.ToString() == reader.GetString(13))
                                {
                                    index2 = i;
                                    break;
                                }
                            }
                            int index3 = -1;
                            for (int i = 0; i < Globalna.nasaAgencija.Prevozi.Count; i++)
                            {
                                if (Globalna.nasaAgencija.Prevozi[i].Id.ToString() == reader.GetString(14))
                                {
                                    index3 = i;
                                    break;
                                }
                            }
                            Putovanje put = new Putovanje(reader.GetDateTimeOffset(5).DateTime, reader.GetDateTimeOffset(6).DateTime, Convert.ToInt32(reader.GetDouble(7)), Convert.ToInt32(reader.GetDouble(8)), reader.GetString(9), reader.GetBoolean(10), Convert.ToInt32(reader.GetString(11)), Globalna.nasaAgencija.Destinacije[index], Globalna.nasaAgencija.Hoteli[index2], Globalna.nasaAgencija.Prevozi[index3], reader.GetDouble(15));
                            Globalna.nasaAgencija.Putovanja.Add(put);
                        }
                        if (Globalna.nasaAgencija.Putovanja.Count == 0) Globalna.idSvihPutovanja = 0;
                        else if (Globalna.nasaAgencija.Putovanja.Count != 0) Globalna.idSvihPutovanja = Globalna.nasaAgencija.Putovanja.Count;
                    }
                    c.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception PutovanjeAzure1: " + e.Message);
            }
        }

        public int dodajPutovanje(Putovanje put)
        {
            try
            {
                String query = "insert into PutovanjeAzure(id,datumPolaska,datumPovratka,minBrojPutnika,maxBrojPutnika,opisPutovanja,istaknuto,idAgencije,idDestinacije,idHotela,idPrevoz,cijena) " + "values (@id,@datumPolaska,@datumPovratka,@minBrojPutnika,@maxBrojPutnika,@opisPutovanja,@istaknuto,@idAgencije,@idDestinacije,@idHotela,@idPrevoz,@cijena)";
                ConnectionStringAzure s = new ConnectionStringAzure();
                using (SqlConnection con = new SqlConnection(s.konekcija))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter id = new SqlParameter();
                    id.Value = put.Id;
                    id.ParameterName = "id";
                    cmd.Parameters.Add(id);

                    SqlParameter datumPolaska = new SqlParameter();
                    datumPolaska.Value = put.DatumPolaska;
                    datumPolaska.ParameterName = "datumPolaska";
                    cmd.Parameters.Add(datumPolaska);

                    SqlParameter datumPovratka = new SqlParameter();
                    datumPovratka.Value = put.DatumPovratka;
                    datumPovratka.ParameterName = "datumPovratka";
                    cmd.Parameters.Add(datumPovratka);

                    SqlParameter minBrojPutnika = new SqlParameter();
                    minBrojPutnika.Value = put.MinimalniBrojPutnika;
                    minBrojPutnika.ParameterName = "minBrojPutnika";
                    cmd.Parameters.Add(minBrojPutnika);

                    SqlParameter maxBrojPutnika = new SqlParameter();
                    maxBrojPutnika.Value = put.MaximalniBrojPutnika;
                    maxBrojPutnika.ParameterName = "maxBrojPutnika";
                    cmd.Parameters.Add(maxBrojPutnika);

                    SqlParameter opisPutovanja = new SqlParameter();
                    opisPutovanja.Value = put.OpisPutovanja;
                    opisPutovanja.ParameterName = "opisPutovanja";
                    cmd.Parameters.Add(opisPutovanja);

                    SqlParameter istaknuto = new SqlParameter();
                    istaknuto.Value = put.IstaknutoPutovanje;
                    istaknuto.ParameterName = "istaknuto";
                    cmd.Parameters.Add(istaknuto);

                    SqlParameter idAgencije = new SqlParameter();
                    idAgencije.Value = put.IdAgencije;
                    idAgencije.ParameterName = "idAgencije";
                    cmd.Parameters.Add(idAgencije);

                    SqlParameter idDestinacije = new SqlParameter();
                    idDestinacije.Value = put.InfoDestinacije.Id;
                    idDestinacije.ParameterName = "idDestinacije";
                    cmd.Parameters.Add(idDestinacije);

                    SqlParameter idHotela = new SqlParameter();
                    idHotela.Value = put.InfoHotela.Id;
                    idHotela.ParameterName = "idHotela";
                    cmd.Parameters.Add(idHotela);

                    SqlParameter idPrevoz = new SqlParameter();
                    idPrevoz.Value = put.InfoPrevoza.Id;
                    idPrevoz.ParameterName = "idPrevoz";
                    cmd.Parameters.Add(idPrevoz);

                    SqlParameter cijena = new SqlParameter();
                    cijena.Value = put.Cijena;
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
                Debug.WriteLine("Exception PutovanjeAzure2: " + e.Message);
                return 0;
            }
        }
    }
}
