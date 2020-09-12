import React, {Component} from 'react'
import axios from 'axios'
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';
import {withStyles} from '@material-ui/core';
import Grid from '@material-ui/core/Grid';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import SigninPIC from '../../assets/img/signIN1.jpg';
import InputAdornment from '@material-ui/core/InputAdornment';
import EmailIcon from '@material-ui/icons/Email';
import PasswordIcon from '@material-ui/icons/VpnKey';
import AccountBoxIcon from '@material-ui/icons/AccountBox';
import {toast} from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'


toast.configure()
const useStyles = (theme) => ({
    root: {
        height: '89.5vh',
    },
    image: {
        backgroundImage: `url(${SigninPIC})`,
        backgroundRepeat: 'no-repeat',
        backgroundColor: theme.palette.type === 'light' ? theme.palette.grey[50] : theme.palette.grey[900],
        backgroundSize: 'cover',
        backgroundPosition: 'left',
    },
    paper: {
        margin: theme.spacing(8, 4),
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center'
    },
    avatar: {
        margin: theme.spacing(1),
        backgroundColor: theme.palette.primary.dark,

    },
    form: {
        width: '100%',
        marginTop: theme.spacing(1)
    },
    submit: {
        margin: theme.spacing(3, 0, 2),
        borderColor: theme.palette.primary.dark,

    },
    input: {},

});

export class Signup extends Component {
    constructor(props) {
        super(props)
        this.state = {
            password: '',
            email: '',
            firstName: '',
            lastName: ''
        }
    }

    handleSubmit = () => {
        axios.post('http://localhost:8080/user', {
            firstName: this.state.firstName,
            lastName: this.state.lastName,
            password: this.state.password,
            email: this.state.email,
        }).then(response => {
            if (response.status === 200 || response.status === 201) toast.success('Your account is successfully created!', {position: toast.POSITION.TOP_RIGHT})
        }).catch(err => {
            toast.error(err.response.data.errors.toString(), {position: toast.POSITION.TOP_RIGHT})
        })
    }

    handleChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    render() {
        const {classes} = this.props;

        return (
            <Grid container component="main" className={classes.root}>
                <CssBaseline/>
                <Grid item xs={false} sm={4} md={7} className={classes.image}/>
                <Grid item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
                    <div className={classes.paper}>
                        <Avatar className={classes.avatar}>
                            <LockOutlinedIcon/>
                        </Avatar>
                        <Typography component="h1" variant="h5">
                            Sign up
                        </Typography>
                        <form className={classes.form}>
                            <TextField
                                variant="standard"
                                margin='normal'
                                required
                                fullWidth
                                id="firstName"
                                label="First name"
                                name="firstName"
                                autoFocus
                                value={this.state.firstName}
                                onChange={e => this.handleChange(e)}
                                className={classes.input}
                                InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                            <AccountBoxIcon/>
                                        </InputAdornment>
                                    ),
                                }}
                            />
                            <TextField
                                variant="standard"
                                margin='normal'
                                required
                                fullWidth
                                value={this.state.lastName}
                                id="lastName"
                                label="Last name"
                                name="lastName"
                                autoFocus
                                className={classes.input}
                                onChange={e => this.handleChange(e)}
                                InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                            <AccountBoxIcon/>
                                        </InputAdornment>
                                    ),
                                }}
                            />
                            <TextField
                                variant="standard"
                                margin='normal'
                                required
                                fullWidth
                                value={this.state.email}
                                id="email"
                                label="Email"
                                name="email"
                                onChange={e => this.handleChange(e)}
                                className={classes.input}
                                InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                            <EmailIcon/>
                                        </InputAdornment>
                                    ),
                                }}
                            />
                            <TextField
                                variant="standard"
                                margin="normal"
                                required
                                fullWidth
                                value={this.state.password}
                                name="password"
                                label="Password"
                                type="password"
                                id="password"
                                onChange={e => this.handleChange(e)}
                                InputProps={{
                                    startAdornment: (
                                        <InputAdornment position="start">
                                            <PasswordIcon/>
                                        </InputAdornment>
                                    ),
                                }}
                            />
                            <Button

                                fullWidth
                                variant="outlined"
                                color="primary"
                                className={classes.submit}
                                onClick={this.handleSubmit}
                            >
                                Sign Up
                            </Button>
                            <Grid container>
                                <Grid item>
                                    <Link href="/sign-in" variant="body2">
                                        {"Already have an account? Sign In"}
                                    </Link>
                                </Grid>
                            </Grid>
                        </form>
                    </div>
                </Grid>
            </Grid>
        );
    }
}

export default withStyles(useStyles)(Signup);