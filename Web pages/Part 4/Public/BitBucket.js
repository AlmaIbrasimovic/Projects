var BitBucket = (function(){
    var konstruktor = function(){ 
        return {
            ucitaj:function(nazivRepSpi, nazivRepVje,callback){
                var lista = [{
                    "imePrezime": "Alma Ibrasimovic",
                    "index": 17270
                },{
                    "imePrezime": "Lejla Kasum",
                    "index":17280
                }, {
                    "imePrezime": "Emina Catic",
                    "index": 17546
                },{
                    "imePrezime": "Zlata Karic",
                    "index": 17334
                },{
                    "imePrezime": "Mujo Mujic",
                    "index": 1766
                }];
                document.getElementsByTagName("input")[3].disabled = false;
                callback(lista);
            }
        }
    }
    return konstruktor;
}());