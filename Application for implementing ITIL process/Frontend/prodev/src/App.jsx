import React from "react";
import "./App.scss";
import { Login, Register } from "./Login/index";
import Admin from './Paneli/Admin'
import Knowledge from './Paneli/Knowledge'
import Suplier from './Paneli/Suplier'

import { BrowserRouter as Router, Route, Switch } from "react-router-dom"


function App() {
  return (
    <Router>
      <div className="App">
        <Route path="/" exact component={Login} />
        <Route path="/admin" component={Admin} />
        <Route path="/knowledge" component={Knowledge} />
        <Route path="/suplier" component={Suplier} />
      </div>
    </Router>
  );
}

// Odkomentirati za login
/*
class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isLogginActive: true
    };
  }

  componentDidMount() {
    this.rightSide.classList.add("right");
  }

  changeState() {
    const { isLogginActive } = this.state;

    if (isLogginActive) {
      this.rightSide.classList.remove("right");
      this.rightSide.classList.add("left");
    } else {
      this.rightSide.classList.remove("left");
      this.rightSide.classList.add("right");
    }
    this.setState(prevState => ({ isLogginActive: !prevState.isLogginActive }));
  }

  render() {
    const { isLogginActive } = this.state;
    const current = isLogginActive ? "Register" : "Login";
    const currentActive = isLogginActive ? "login" : "register";
    return (
      <div className="App">
        <div className="login">
          <div className="container" ref={ref => (this.container = ref)}>
            {isLogginActive && (
              <Login containerRef={ref => (this.current = ref)} />
            )}
            {!isLogginActive && (
              <Register containerRef={ref => (this.current = ref)} />
            )}
          </div>
          <RightSide
            current={current}
            currentActive={currentActive}
            containerRef={ref => (this.rightSide = ref)}
            onClick={this.changeState.bind(this)}
          />
        </div>
      </div>
    );
  }
}

const RightSide = props => {
  return (
    <div
      className="right-side"
      ref={props.containerRef}
      onClick={props.onClick}
    >
      <div className="inner-container">
        <div className="text">{props.current}</div>
      </div>
    </div>
  );
};

export default App;
*/

// Za listu korisnika
/*
function App() {
  return(
    <div className="App">
      <Korisnici/>
    </div>
  );
}
export default App;
*/

/*
// Za listu uloga
function App() {
  return(
    <div className="App">
      <Uloge/>
    </div>
  );
}
*/




/*
// Za listu tipova vjestina
function App() {
  return(
    <div className="App">
      <DodavanjeVjestine/>
    </div>
  );
}*/

/*
// Za listu tipova edukacija

function App() {
  return(
    <div className="App">
      <TipoviEdukacija/>
    </div>
  );
}
export default App;*/

/*
function App() {
  return(
    <div className="App">
      <Vjestine/>
    </div>
  );
}*/

export default App;
