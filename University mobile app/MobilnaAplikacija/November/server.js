const express = require('express');
const app = express();
const https = require('https');
const request = require('request');
const axios = require('axios');


//Vraca sve o predmetima koje student trenutno slusa
//Potrebno pokrenuti Sierra i Lima server
app.get('/predmeti/:idstudenta', (req, res) => {
    idstudenta=req.params.idstudenta;
    mainResponse="";
axios.get('http://localhost:31918/predmeti/trenutni/'+idstudenta) //grupa Sierra //poziv vraca nazive svih predmeta
  .then(response => {
    brojPredmeta=response.data.trenutniPredmeti.length;
    i=0;
    let nizPedmeta=response.data.trenutniPredmeti
    axios.get('http://localhost:31918/studenti/'+idstudenta) //grupa Sierra //trazimo indeks studenta na osnovi id-a
    .then(response => {
        indeks=response.data[0].indeks;
        //console.log(indeks);
    //Prolazimo kroz sve vraćene predmete za studenta sa pronadjenim indeksom
    nizPedmeta.forEach(function(element) {
      //Poziv apija za svaki predmet
    axios.get('http://localhost:31912/izvjestaj/'+ indeks +'/'+element.naziv+'/bodovi') //grupa Lima //poziv vraca sve bodove na predmetu koji se salje kao parametar pored indeksa
    .then(response => {    
      i++;
      pomJSON=response.data;
      pomJSON['bodovi'].push({'predmet':element.naziv})
      //sve smjestamo u mainResponse
      if (i!=1) mainResponse=mainResponse+","+JSON.stringify(pomJSON);
      else mainResponse='['+JSON.stringify(pomJSON);
      if(i==brojPredmeta) {
        mainResponse=mainResponse+"]"
        res.json(JSON.parse(mainResponse));
      }

    })
    .catch(error => {
      console.log(error);
    });
  });
  })
  .catch(error => {
    console.log(error);
  });
})
.catch(error => {
  console.log(error);
});


  //Ovaj api vraća podatke o predmetu u sljedećem formatu
  /*
  [{"bodovi":
  [{"postojiStudent":true,"slusaPredmet":true,"prisustvo":10,"moguciBodPrisus":10,"prviParcijalni":10,"moguciBodPrve":20,"drugiParcijalni":"/",
  "moguciBodDruge":0,"zavrsni":"/","moguciBodZavrsnog":0,"zadaca":"/","moguciBodZad":1,"projekat":"/","moguciBodPro":14707,"ocjena":"/"},
  {"predmet":"Projektovanje informacionih sistema"}]},
  {"bodovi":[{"postojiStudent":true,"slusaPredmet":true,"prisustvo":10,"moguciBodPrisus":10,"prviParcijalni":"/","moguciBodPrve":0,
  "drugiParcijalni":"/","moguciBodDruge":0,"zavrsni":"/","moguciBodZavrsnog":0,"zadaca":"/","moguciBodZad":0,"projekat":"/","moguciBodPro":1387,
  "ocjena":"/"},{"predmet":"DS"}]}...
  ...
  ]
  */
});

//ISto samo za odslusane predmete
app.get('/odslusani/:idstudenta', (req, res) => {
  idstudenta=req.params.idstudenta;
  mainResponse="";
axios.get('http://localhost:31918/predmeti/odslusani/'+idstudenta) //grupa Sierra //poziv vraca nazive svih predmeta
.then(response => {
  brojPredmeta=response.data.odslusaniPredmeti.length;
  i=0;
  if(brojPredmeta==0) 
  res.json(JSON.parse("[]"));
  let nizPedmeta=response.data.odslusaniPredmeti
  axios.get('http://localhost:31918/studenti/'+idstudenta) //grupa Sierra //trazimo indeks studenta na osnovi id-a
  .then(response => {
      indeks=response.data[0].indeks;
      //console.log(indeks);
  //Prolazimo kroz sve vraćene predmete za studenta sa pronadjenim indeksom
  nizPedmeta.forEach(function(element) {
    //Poziv apija za svaki predmet
  axios.get('http://localhost:31912/izvjestaj/'+ indeks +'/'+element.naziv+'/bodovi') //grupa Lima //poziv vraca sve bodove na predmetu koji se salje kao parametar pored indeksa
  .then(response => {    
    i++;
    pomJSON=response.data;
    pomJSON['bodovi'].push({'predmet':element.naziv})
    //sve smjestamo u mainResponse
    if (i!=1) mainResponse=mainResponse+","+JSON.stringify(pomJSON);
    else mainResponse='['+JSON.stringify(pomJSON);
    if(i==brojPredmeta) {
      mainResponse=mainResponse+"]"
      res.json(JSON.parse(mainResponse));
    }

  })
  .catch(error => {
    console.log(error);
  });
});
})
.catch(error => {
  console.log(error);
});
})
.catch(error => {
console.log(error);
});
});



//Vraca ukupan br bodova po predmetima koje student trenutno slusa i koje je slusao
//Potrebno pokrenuti Sierra i Lima server

app.get('/predmeti/:idstudenta/ukupnoBodova', (req, res) => {
  idstudenta=req.params.idstudenta;
  resp="[";
axios.get('http://localhost:31914/predmeti/'+idstudenta) 
.then(response => {
  brojPredmeta=response.data.length;
    i=0;
    let nizPedmeta=response.data
    nizPedmeta.forEach(function(element) {
      //mainResponse=mainResponse+"\""+element.bodovi[1].predmet+"\":"+"\""+element[0].bodovi.prisustvo+"\"";
      ukupnoBodova=0;
      if(element.bodovi[0].prisustvo!="/") ukupnoBodova=ukupnoBodova+element.bodovi[0].prisustvo;
      if(element.bodovi[0].prviParcijalni!="/") ukupnoBodova=ukupnoBodova+element.bodovi[0].prviParcijalni;
      if(element.bodovi[0].drugiParcijalni!="/") ukupnoBodova=ukupnoBodova+element.bodovi[0].drugiParcijalni;
      if(element.bodovi[0].zavrsni!="/") ukupnoBodova=ukupnoBodova+element.bodovi[0].zavrsni;
      if(element.bodovi[0].zadaca!="/") ukupnoBodova=ukupnoBodova+element.bodovi[0].zadaca;
      if(element.bodovi[0].projekat!="/") ukupnoBodova=ukupnoBodova+element.bodovi[0].projekat;
      //console.log(ukupnoBodova + element.bodovi[1].predmet);
      resp=resp+"{\"predmet\":\""+element.bodovi[1].predmet+"\",\"bodovi\":\""+ukupnoBodova+"\"},"
    })
    axios.get('http://localhost:31914/odslusani/'+idstudenta) 
.then(response => {
  brojPredmeta=response.data.length;
    i=0;
    let nizPedmeta=response.data
    nizPedmeta.forEach(function(element) {
      //mainResponse=mainResponse+"\""+element.bodovi[1].predmet+"\":"+"\""+element[0].bodovi.prisustvo+"\"";
      ukupnoBodova=0;
      if(element.bodovi[0].prisustvo!="/") ukupnoBodova=ukupnoBodova+element.bodovi[0].prisustvo;
      if(element.bodovi[0].prviParcijalni!="/") ukupnoBodova=ukupnoBodova+element.bodovi[0].prviParcijalni;
      if(element.bodovi[0].drugiParcijalni!="/") ukupnoBodova=ukupnoBodova+element.bodovi[0].drugiParcijalni;
      if(element.bodovi[0].zavrsni!="/") ukupnoBodova=ukupnoBodova+element.bodovi[0].zavrsni;
      if(element.bodovi[0].zadaca!="/") ukupnoBodova=ukupnoBodova+element.bodovi[0].zadaca;
      if(element.bodovi[0].projekat!="/") ukupnoBodova=ukupnoBodova+element.bodovi[0].projekat;
      //console.log(ukupnoBodova + element.bodovi[1].predmet);
      resp=resp+"{\"predmet\":\""+element.bodovi[1].predmet+"\",\"bodovi\":\""+ukupnoBodova+"\"},"
    })
    
    resp=resp.replace(/.$/,"]") //mijenjamo zadnji znak u ] kako bi bilo u json formatu
    res.json(JSON.parse(resp));
})
.catch(error => {
console.log(error);
});
})
.catch(error => {
console.log(error);
});

//Ovaj api vraća podatke o predmetu u sljedećem formatu
/*
[{"predmet":"ARM","bodovi":"10"},{"predmet":"Projektovanje informacionih sistema","bodovi":"20"},
{"predmet":"IEK","bodovi":"10"},{"predmet":"SI","bodovi":"28"}]
*/
});
app.get('/predmeti/:idstudenta/prviParcijalni', (req, res) => {
  res.json( [
    {
      predmet: "Administracija racunarskih mreza",
      bodovi : 6
    },
    {
      predmet: "Vještačka inteligencija",
      bodovi : 13
    },
    {
      predmet: "Softver inženjering",
      bodovi : 17
    }
  ]);
});

app.listen(31914);

