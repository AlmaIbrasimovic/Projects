import React, {Component} from 'react'
import axios from 'axios'
import Dropdown from 'react-dropdown';

export class Korisnici extends Component {
    constructor(props) {
        super (props)
        this.state = {
            Korisnici : [],
            Header : [
                {Username: "", Email: "",uloga: "", obrisati: false}
            ],
            options:[],
            temp:'',
            email: '',
            username: '',
            uloga:'',
            password: '',
            tipUloge:'',
            id:''
        };
    }

    handleChange = (e, index) => {
        this.state.id = this.state.Korisnici[index].id;;
    }
    
    componentWillMount() {
        axios.get('http://localhost:8083/user/all')
          .then(res => {
            const Korisnici = res.data;
            this.setState({ Korisnici });
        })
        axios.get('http://localhost:8083/role/all')
          .then(res => {
            var temp=[];
            for (var i=0; i<res.data.length;i++) {
                temp.push({name: `${res.data[i].name}`, value: res.data[i].name, id: res.data[i].id});
                
            }
            this.setState({ options:temp });
        })

    }

    obrisiKorisnika = () => {
        axios.delete(`http://localhost:8083/user/${this.state.id}`)
            .then(res => {
                var TEMP = [...this.state.Korisnici];
                for (var i = 0; i<TEMP.length; i++) {
                    if(TEMP[i].id === this.state.id) TEMP.splice(i, 1);
                }
                this.setState({Korisnici:TEMP})
                alert("Uspješno obrisan korisnik!");
        })
    }

    kreirajKorisnika = () => {
        var idUloge =''
        for (var i = 0; i<this.state.options.length; i++) {
            console.log(this.state.options[i])
            console.log("Odabrani " + this.state.tipUloge)
            if (this.state.options[i].value === this.state.tipUloge) {
                idUloge = this.state.options[i].id;
                break;
            }
        }
        axios.post('http://localhost:8083/user/register', {
            username: this.state.username,
            email: this.state.email,
            password: this.state.password,
            roleList: [{
                roleId: idUloge,
            }]
        }).then(response => {
            if (response.status === 201 || response.status === 200) alert("Korisnik uspješno registrovan!")
        }).catch(err => {
            alert(err.response.data.errors)
        })

        var TEMP = [...this.state.Korisnici];
        const temp = {
            username: this.state.username,
            email: this.state.email,
            password: this.state.password,
            roleList: [{
                roleId: idUloge,
            }],
            obrisati: false
        }
        TEMP.push(temp);
        this.setState({Korisnici:TEMP}) 
    }

    handleChangeUloga = (selectedOption) => {
        if (selectedOption) {
            this.setState({tipUloge: selectedOption.value})
            this.setState({temp:selectedOption});
        }
    }
     
    prikazKorisnika() {      
        return this.state.Korisnici.map((korisnik, index) => {
           const {email, username, roleList, obrisati} = korisnik
           return (
              <tr key={username}>
                 <td>{username}</td>
                 <td>{email}</td>
                 <td>{roleList[0].name}</td>
                 <td>{obrisati}
                 <div className="brisanje">
                        <label>
                            <input type="checkbox"  
                            brisati={this.state.checked}
                            onChange={e => this.handleChange(e, index)}
                            />
                        </label>
                    </div>
               </td>
              </tr>
           ) 
        })
    }

    headerTabele() {
        let header = Object.keys(this.state.Header[0])
        return header.map((key, index) => {
           return <th key={index}>{key.toUpperCase()}</th>
        })
    }

    unosNovog = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }
    
    render() {
        return (
            <div>
            <h2 id='title'>Postojeći korisnici</h2>
            <div className ="glavniDIV">
                <table id='korisnici'>
                <tbody>
                    <tr>{this.headerTabele()}</tr>
                    {this.prikazKorisnika()}
                </tbody>
                </table>
                <div className="footer">
                    <button type="submit" className="btnObrisiKorisnika"  onClick={this.obrisiKorisnika}>
                        Obriši korisnika
                    </button>
                </div>
            </div>
            <form>
            <div className="formaKorisnici">
                <h2>Unos korisnika</h2>
                <div className="form-grupaKorisnici">
                    <label htmlFor="username">Username:</label>
                    <input type="text"
                    name="username"
                    value={this.state.username} 
                    onChange={e => this.unosNovog(e)}/>
                </div>
                <div className="form-grupaKorisnici">
                    <label htmlFor="username">Email:</label>
                    <input type="text"
                    name="email"
                    value={this.state.email} 
                    onChange={e => this.unosNovog(e)}/>
                </div>
                <div className="form-grupaKorisnici">
                    <label htmlFor="password">Password:</label>
                    <input type="password"
                    name="password"
                    value={this.state.password} 
                    onChange={e => this.unosNovog(e)}/>
                </div>
                <div className="form-grupaKorisnici">
                    <label htmlFor="uloga">Uloga:</label>
                    <Dropdown options={this.state.options}      
                        value={this.state.temp} 
                        onChange={(e) => {
                            this.handleChangeUloga(e);
                        }}
                        placeholder="Odaberite ponuđeni tip uloge"
                    />  
                </div>
                <button type="submit" className="btnDodajKorisnika"  onClick={this.kreirajKorisnika}>
                    Dodavanje novog korisnika
                </button>
            </div>
            </form>
            </div>
        )
    }
}

