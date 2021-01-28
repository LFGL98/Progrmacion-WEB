import React from "react";
import axios from "axios";

 import Inicio from "./inicio.js"
import "./login.css";
import {
	BrowserRouter as Router,
	Link,
	Switch,
	Route,
	useHistory
} from 'react-router-dom'; 

class Login extends React.Component {
constructor (props) {
	super(props);

		this.state = {
			User: {},
			Id: '',
			Password: '',
			
			
		}
		
		this.doLogin = this.doLogin.bind(this);
	}

	doLogin () {
		
		axios.post('http://localhost:5001/api/login/',
		{
			"Id":  this.state.Id,
			"Nombre": "",
			"Apellido":"",
			"Telefono": "",
			"password": this.state.Password,
			"token": ""
		}).then (json => {
			if (json.data.status === "1") {
				<Route path='/Inicio' component={Inicio} /> 

				 
 			
				//this.props.history.push('/employeesList');
			} else {
				alert('Data not saved!');
				 
				//debugger;
				//this.props.history.push('employeesList');
			}
		})

	}

	handleChange = (e) => {
		console.log(e);
		this.setState (
			{
				[e.target.name]: e.target.value
			}
		);
	}


	render () {

		const {User}=this.state;
		return(
			<div>
			
			<form>
 			<div id="div2">
  			  <img src="logotipo-refaccionaria-circuito-removebg-preview.png" alt="Avatar" className="avatar"/>
  				</div>

 		 <div className="container" id="div">
 		 <h2>INICIAR SESION</h2>
    		<label for="uname"><b>Username</b></label>
   			 <input type="text" onChange={this.handleChange} value={this.state.Id} placeholder="Enter Username" name="Id" required/>

    	<label for="psw"><b>Password</b></label>
   	 <input type="password" onChange={this.handleChange} value={this.state.Password} placeholder="Enter Password" name="Password" required/>
        <div>
    <button type="submit" onClick={this.doLogin}>Login</button>
    </div>
    <label>
      <input type="checkbox"  name="remember"/> Remember me
    </label>
  </div>

  <div className="container" id="div">
  <div>
    <button type="button" className="cancelbtn">Cancel</button>
    </div>
    <span className="psw">Forgot <a href="#">password?</a></span>
  </div>
</form>
</div>
		);
	}
   
}

export default Login;