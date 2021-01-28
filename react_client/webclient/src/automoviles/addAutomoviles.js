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
class AddAutomoviles extends React.Component {
	constructor (props) {
		super(props);

		// mantiene el estado del formulario
		this.state = {
			ID: '',
			Nombre: '',
			Descripcion: '',
			Precio: '',
			Ubicacion: '',
			PalabraClave: '',
			IdDistribuidor: ''
		}
	}
	Add = () => {
		axios.post ('http://localhost:5001/api/automoviles', 
		 {
			ID: this.state.ID,
			Nombre: this.state.Nombre,
			Descripcion: this.state.Descripcion,
			Precio: parseFloat(this.state.Precio),
			Ubicacion: this.state.Ubicacion,
			PalabraClave: this.state.PalabraClave,
			IdDistribuidor: this.state.IdDistribuidor
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
          <h3>Automovil: AGREGAR PRODUCTO</h3>
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
              <label for="username">Descripcion</label>
              <input type="text" name="Descripcion" onChange={this.handleChange} value={this.state.Descripcion} spellcheck="false"  />
            </div>
            <div>
              <label for="password">Precio</label>
              <input type="text" name="Precio" value={this.state.Precio} onChange={this.handleChange} />
            </div>
            <div>
              <label for="password-again">Ubicacion</label>
              <input type="text" name="Ubicacion" onChange={this.handleChange} value={this.state.Ubicacion} />
            </div>
            <div>
              <label for="password-again">Palabra Clave</label>
              <input type="text" name="PalabraClave" onChange={this.handleChange} value={this.state.PalabraClave} />
            </div>
            <div>
              <label for="password-again">ID Distribuidor</label>
              <input type="text" name="IdDistribuidor" onChange={this.handleChange} value={this.state.IdDistribuidor} />
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

export default AddAutomoviles;