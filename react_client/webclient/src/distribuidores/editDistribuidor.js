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
class EditDistribuidor extends React.Component {
	constructor (props) {
		super(props);

		
		// mantiene el estado del formulario
		this.state = {
			Id: '',
			Nombre: '',
			RFC: '',
			Telefono: ''
			
		}
	}

	

	// función de envío de datos al backend
	AddDistri = () => {
		const data = {
			"Id":this.state.Id,
			"Nombre":this.state.Nombre,
		    "RFC":this.state.RFC,
			"Telefono": this.state.Telefono
			
		}

		axios.put ('http://localhost:5001/api/distribuidor/'+this.state.Id, JSON.stringify(data), {
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
          <h3>Distribuidor: EDITAR DISTRIBUIDOR</h3>
          <form >
            <div>
              <label for="name">ID</label>
              <input type="text" onChange={this.handleChange} value={this.state.Id} name="Id" spellcheck="false" placeholder="1,2,3,4.."/>
            </div>
            <div>
              <label for="email">Nombre</label>
              <input type="text" onChange={this.handleChange} value={this.state.Nombre} name="Nombre" spellcheck="false" />
            </div>
            <div>
              <label for="username">RFC</label>
              <input type="text" name="RFC" onChange={this.handleChange} value={this.state.RFC} spellcheck="false"  />
            </div>
            <div>
              <label for="password">Telefono</label>
              <input type="text" name="Telefono" value={this.state.Telefono} onChange={this.handleChange} />
            </div>
      
            <div>
              <label></label><br/>
              <input type="submit" value="Agregar" onClick={this.AddDistri} className="button"/>
              
              <input type="reset" value="Reset" className="button" />
            </div>
          </form>
         
         
        </div>
      </div>
      
     
    </div>
		 
 				</div>
				
			);
		}
}

export default EditDistribuidor;	