import React from 'react';
import axios from 'axios';
import {Router} from 'react-router-dom';
import {Helmet} from "react-helmet";
import { If, Then, ElseIf, Else } from 'react-if-elseif-else-render';
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
class IDEmpleados extends React.Component {

constructor(props){
		super(props);
		this.state={
		items: [],
		Id:"",
		isFetched: false,
		error: null,
		bandera: false
		};
	}


	getEmpleado=()=>{
	axios.get("http://localhost:5001/api/empleados/"+this.state.Id)
	.then(res=> res.json())
		.then(
			(result)=>{
				console.log(result);
				this.setState({
					items: result,
					isFetched: true,
					error: null,
					bandera: true
				}
				);
			},
			(error)=>{
				console.log(error);
				this.setState({
					items: [],
					isFetched: true,
					error: error,
					bandera: false
				}
				);
			}
			)
	}
handleChange = (e) => {
		console.log(e);
		this.setState ({
			[e.target.name]:e.target.value
		});
	}

	render(){
		const {items, isFetched, error,bandera} = this.state;
		if(bandera==true){
				return (<div className="table-users">
				<div className="header">Empleados</div>
			<table>
				<thead>
					<tr>
						<th>ID</th>
						<th>Nombre</th>
						<th>Apellido</th>
						<th>Telefono</th>
					</tr>
				</thead>
				<tbody>
					{
						items.map(i=>
						<tr>
							<td>{i.id}</td>
							<td>{i.nombre}</td>
							<td>{i.apellidos}</td>
							<td>{i.telefono}</td>
						</tr>
					)
					}
				</tbody>
			</table>
			</div>);
				
			}else{
		return(
	<div>
<div className="main">
      <div className="one">
        <div className="register">
          <h3>Buscar: ID Empleado</h3>
          <form >
            <div>
              <label for="name">ID</label>
              <input type="text" onChange={this.handleChange} value={this.state.Id} name="Id" spellcheck="false" placeholder="1,2,3,4.."/>
            </div>
           
            <div>
              <label></label><br/>
              <input type="submit" value="Eliminar" onClick={this.getEmpleado} className="button"/>
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
}	
export default IDEmpleados;	
