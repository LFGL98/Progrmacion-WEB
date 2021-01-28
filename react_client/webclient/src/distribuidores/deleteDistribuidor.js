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
class DeleteDistribuidor extends React.Component {
    constructor (props) {
        super(props);
        alert("AVISO! VERIFIQUE QUE EL DISTRIBUIDOR A ELIMINAR NO TENGA PRODUCTOS ASIGNADOS");
        // mantiene el estado del formulario
        this.state = {
            Id: ''
        }
    }
    delete=()=>{
    axios.delete("http://localhost:5001/api/distribuidor/"+this.state.Id)
    .then(response=>{
        
                        alert("Registro eliminado!");
                window.location.reload();
    }).catch(error=>{
    alert("Error al Eliminar");
        console.log(error.message);
    })
}

    // modifica el estado del formulario de acuerdo a los valores
    // de los campos
    handleChange = (e) => {
        console.log(e);
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
          <h3>Distribuidor: ELIMINAR DISTRIBUIDOR</h3>
          <form >
            <div>
              <label for="name">ID</label>
              <input type="text" onChange={this.handleChange} value={this.state.Id} name="Id" spellcheck="false" placeholder="1,2,3,4.."/>
            </div>
           
            <div>
              <label></label><br/>
              <input type="submit" value="Eliminar" onClick={this.delete} className="button"/>
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

export default DeleteDistribuidor;