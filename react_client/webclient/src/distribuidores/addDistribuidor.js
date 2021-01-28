import React from 'react';
import axios from 'axios';
import {Router} from 'react-router-dom';
import {Helmet} from "react-helmet";
import './style.css'
import {
	Container,
	Col,
	Form,
	FormGroup,
	Label,
	Input,
	Button
} from 'reactstrap';
class AddDistribuidor extends React.Component {
	constructor (props) {
		super(props);

		// mantiene el estado del formulario
		this.state = {
			ID: '',
			Nombre: '',
			RFC: '',
			Telefono: ''
		}
	}
	Add = () => {
		axios.post ('http://localhost:5001/api/distribuidor', 
		 {
			ID: this.state.ID,
			Nombre: this.state.Nombre,
			RFC: this.state.RFC,
			Telefono: this.state.Telefono
	
		}).then (json => {
			if (json.data.status === 'Success') {
				alert("Data saved!");
				//this.props.history.push('/employeesList');
			} else {
				alert('Data not saved!');
				//debugger;
				//this.props.history.push('employeesList');
			}
		})

	}
	cancelCourse = () => { 
  document.getElementById("create-course-form").reset();
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
          <h3>Distribuidor: AGREGAR DISTRIBUIDOR</h3>
          <form >
            <div>
              <label for="name">ID</label>
              <input type="text" onChange={this.handleChange} value={this.state.ID} name="ID" spellcheck="false" placeholder="1,2,3,4.."/>
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
              <input type="submit" value="Agregar" onClick={this.Add} className="button"/>
              
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

export default AddDistribuidor;