import React, {Component} from 'react';
import './Dashboard.css'
import {makeStyles} from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import {withStyles} from '@material-ui/core';
import AddBoxIcon from '@material-ui/icons/AddBox';
import FastfoodIcon from '@material-ui/icons/Fastfood';
import FavoriteIcon from '@material-ui/icons/Favorite';
import Typography from '@material-ui/core/Typography';
import Link from '@material-ui/core/Link';
import ExitToAppIcon from '@material-ui/icons/ExitToApp';
import {BrowserRouter as Router} from 'react-router-dom';
import {hashHistory} from 'react-router';
import {withRouter} from 'react-router-dom';
import CreateRecipe from './pages/CreateRecipe';
import ReactDOM from 'react-dom';

function Copyright() {
    return (
        <Typography variant="body2" color="white" align="center">
            {'Copyright © '}
            <Link color="inherit" href="/">
                Recipaholic
            </Link>
            {' '}
            {new Date().getFullYear()}
            {'.'}
        </Typography>
    );
}

const useStyles = (theme) => ({
    root: {
        background: 'transparent',
        borderRadius: 3,
        border: 0,
        color: 'white',
        height: 100,
        padding: '0 30px',
        width: 252,
        '&:hover': {
            backgroundColor: '#2e2b2b',
            borderColor: '#d9001d',
            boxShadow: 'none',
        },
        '&:active': {
            boxShadow: 'none',
            backgroundColor: '##9001d',
            borderColor: '#005cbf',
        }
    },
    label: {
        textTransform: 'capitalize',
        fontSize: 16,
    },

});

export class Dashboard extends Component {
    constructor(props) {
        super(props)
        this.state = {
            firstName: '',
            lastName: ''
        }
    }

    logout = () => {
        ReactDOM.render(<CreateRecipe/>, document.getElementById("proba"));
    }

    render() {
        const {classes} = this.props;
        return (
            <div className="dashboard-container">
                <div className="dashboard-side-menu">
                    <div className="dashboard-user-info">
                        <text>{this.props.info}</text>
                    </div>
                    <div className="dashboard-buttons-section">
                        <a>
                            <Button
                                classes={{
                                    root: classes.root,
                                    label: classes.label,

                                }}
                                onClick={this.logout}
                                size="inherit"
                                endIcon={<AddBoxIcon/>}
                            >
                                Create new recipe
                            </Button>
                        </a>
                        <Button
                            classes={{
                                root: classes.root,
                                label: classes.label,

                            }}
                            size="inherit"
                            endIcon={<FastfoodIcon/>}
                        >
                            My recipes
                        </Button>
                        <Button
                            classes={{
                                root: classes.root,
                                label: classes.label,

                            }}
                            size="inherit"
                            endIcon={<FavoriteIcon/>}
                        >
                            Favourite recipes
                        </Button>
                    </div>
                    <div className="dashboard-logout-section">
                        <a href="/">
                            <Button
                                classes={{
                                    root: classes.root,
                                    label: classes.label,
                                }}
                                onClick={this.logout.bind(this)}
                                size="inherit"
                                endIcon={<ExitToAppIcon/>}
                            >
                                Logout
                            </Button>
                        </a>
                        <Copyright/>
                    </div>
                </div>
                <div className="dashboard-right-part" id="proba">

                </div>
            </div>
        );
    }
}


export default withStyles(useStyles)(Dashboard);