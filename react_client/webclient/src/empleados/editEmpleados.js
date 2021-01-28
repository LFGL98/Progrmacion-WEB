// import libraries
import React from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';

import './style.css'
import $ from 'jquery';
import {
	Container,
	Col,
	Form,
	FormGroup,
	Label,
	Input,
	Button
} from 'reactstrap';

// clase modelo para los datos del formulario
class EditEmpleados extends React.Component {
	constructor (props) {
		super(props);

		
		// mantiene el estado del formulario
		this.state = {
			Id: '',
			Nombre: '',
			Apellidos: '',
			Telefono: '',
			Password: ''
			
		}
	}

	

	// función de envío de datos al backend
	Add = () => {
		const data = {
			"Id":this.state.Id,
			"Nombre":this.state.Nombre,
		    "Apellidos":this.state.Apellidos,
			"Telefono":this.state.Telefono,
			"Password": this.state.Password
			
		}

		axios.put ('http://localhost:5001/api/empleados/'+this.state.Id, JSON.stringify(data), {
			headers: {
				'Accept': 'application/json',
				'Content-type': 'application/json'
				

			}
		}).then (json => {
			console.log(json.data.status);
			if (json.data.status === 'Success') {
				alert("Data saved!");
				
				//this.props.history.push('/employeesList');
			} else {
				alert('Data not saved!');
				
				//debugger;

				//this.props.history.push('/employeesList');
			}
		})
	}

	// modifica el estado del formulario de acuerdo a los valores
	// de los campos
	handleChange = (e) => {
		this.setState ({
			[e.target.name]:e.target.value
		});
	}

	// dibuja al componente
	render () {
	
			return (
			<div>
<div className="main">
      <div className="one">
        <div className="register">
          <h3>Empleados: EDITAR EMPLEADOS</h3>
          <form >
            <div>
              <label for="name">ID</label>
              <input type="text" onChange={this.handleChange} value={this.state.Id} name="Id" spellcheck="false" placeholder="1,2,3,4.."/>
            </div>
            <div>
              <label for="email">NOMBRE</label>
              <input type="text" onChange={this.handleChange} value={this.state.Nombre} name="Nombre" spellcheck="false" />
            </div>
            <div>
              <label for="username">APELLIDOS</label>
              <input type="text" name="Apellidos" onChange={this.handleChange} value={this.state.Apellidos} spellcheck="false"  />
            </div>
            <div>
              <label for="password">TELEFONO</label>
              <input type="text" name="Telefono" value={this.state.Telefono} onChange={this.handleChange} />
            </div>
            <div>
              <label for="password-again">Password</label>
              <input type="password" name="Password" onChange={this.handleChange} value={this.state.Password} />
            </div>
            <div>
              <label></label><br/>
              <input type="submit" value="Agregar" onClick={this.Add} className="button"/>
              <br/>
              <input type="reset" value="Limpiar" className="button"/>
            </div>
          </form>
         
         
        </div>
      </div>
      
     
    </div>
		 
 				</div>
				
			);
		}
}

export default EditEmpleados;	