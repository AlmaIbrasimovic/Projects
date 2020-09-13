import React, {Component} from 'react'
import axios from 'axios'
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Link from '@material-ui/core/Link';
import Paper from '@material-ui/core/Paper';
import {withStyles} from '@material-ui/core';
import Grid from '@material-ui/core/Grid';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import {makeStyles} from '@material-ui/core/styles';
import SigninPIC from '../../assets/img/signIN1.jpg';
import InputAdornment from '@material-ui/core/InputAdornment';
import EmailIcon from '@material-ui/icons/Email';
import PasswordIcon from '@material-ui/icons/VpnKey';
import {spacing} from '@material-ui/system';
import {toast} from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'
import Test from '../../components/pages/Test'


toast.configure()
const useStyles = (theme) => ({
    root: {
        height: '89.5vh'
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

    }
});

export class Signin extends Component {
    constructor(props) {
        super(props)
        this.state = {
            email: '',
            password: false,
        }
    }

    handleSubmit = () => {
        axios.post('http://localhost:8080/login', {
            email: this.state.email,
            password: this.state.password,

        }).then(response => {
            if (response.status === 200 || response.status === 201) toast.success(response.data.message.toString(), {position: toast.POSITION.TOP_RIGHT})
            axios.get(`http://localhost:8080/user/${this.state.email}/${this.state.password}`)
                .then(res => {
                    this.props.history.push({
                        pathname: '/user-profile',
                        state: {
                            id: res.data.id,
                            firstName: res.data.firstName,
                            lastName: res.data.lastName
                        }
                    })
                })
        }).catch(err => {
            toast.error(err.response.data.message, {position: toast.POSITION.TOP_RIGHT})
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
                            Sign in
                        </Typography>
                        <form className={classes.form}>
                            <TextField
                                variant="standard"
                                margin='normal'
                                required
                                fullWidth
                                id="email"
                                label="Email"
                                name="email"
                                value={this.state.email}
                                onChange={e => this.handleChange(e)}
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
                                name="password"
                                label="Password"
                                type="password"
                                id="password"
                                value={this.state.password}
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
                                Sign In
                            </Button>
                            <Grid container>
                                <Grid item>
                                    <Link href="/sign-up" variant="body2">
                                        {"Don't have an account? Sign Up"}
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

export default withStyles(useStyles)(Signin);