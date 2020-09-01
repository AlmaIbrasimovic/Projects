import React from "react";
import loginSlika from "../logo.png";
import axios from 'axios'

export class Register extends React.Component {
    constructor (props) {
        super(props);
        this.state = {
            username: '',
            password: '',
            email: ''
        };
    }

    handleChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    register = () => {
        if (this.state.password === '' || this.state.email === '' || this.state.username === '') {
            alert("Molimo unesite sve podatke!")
        }
        else {
            axios.post('http://localhost:8083/user/register', {
                username: this.state.username,
                email: this.state.email,
                password: this.state.password,
                roleList: [{
                    roleId: 2,
                }]
            })
            alert("Uspješno ste kreirali račun!")
        }

    }

    render() {
        return (<div className ="base-container" ref={this.props.containerRef}>
            <div className="header-register">Kreiraj račun</div>
            <div className="content">
                <div className="image">
                    <img src={loginSlika} />
                </div>
                <div className="forma">
                    <div className="form-grupa">
                        <label htmlFor="username">Korisničko ime</label>
                        <input type="text" 
                        name="username"
                        value={this.state.username} 
                        onChange={e => this.handleChange(e)}
                        />
                    </div>
                    <div className="form-grupa">
                        <label htmlFor="password">E-mail adresa</label>
                        <input type="email" name="email"
                        value={this.state.email} 
                        onChange={e => this.handleChange(e)}
                        />
                    </div>
                    <div className="form-grupa">
                        <label htmlFor="password">Lozinka</label>
                        <input type="password" name="password"
                        value={this.state.password} 
                        onChange={e => this.handleChange(e)}
                        />
                    </div>
                </div>
            </div>
            <div className="footer">
                <button type="button" className="btn" onClick={this.register}>
                    Register
                </button>
            </div>
        </div>
        );    
    }
}
