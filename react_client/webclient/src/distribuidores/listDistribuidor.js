import React from 'react';
import {Router} from 'react-router-dom';
import "./listDistribuidor.css"
class DistribuidorList extends React.Component{
	constructor(props){
		super(props);
		this.state={
		items: [],
		isFetched: false,
		error: null
		};
	}
	

	componentDidMount(){
		fetch("http://localhost:5001/api/distribuidor/")
		.then(res=>res.json())
		.then(
			(result)=>{
				console.log(result);
				this.setState(
				{
				items: result,
				isFetched: true,
				error: null
			}
			);
			},
			(error)=>{
				console.log(error);
				this.setState(
					{
					items: [],
					isFetched: true,
					error: error
				}
			);
			}
		)
	}


	render(){
		
			const {items, isFetched, error} = this.state;
			if(error){
				return (<div><p>{error}</p></div>);
				}else if(!isFetched){
					return(<div><p>Loading....</p></div>);
			}else{
			return(
				<div className="table-users">
				<div className="header">Distribuidores</div>
			<table>
				<thead>
					<tr>
						<th>ID</th>
						<th>Nombre</th>
						<th>RFC</th>
						<th>Telefono</th>
						
					</tr>
				</thead>
				<tbody>
					{
						items.map(i=>
						<tr>
							<td>{i.id}</td>
							<td>{i.nombre}</td>
							<td>{i.descripcion}</td>
							<td>{i.rfc}</td>
							<td>{i.telefono}</td>

						</tr>
					)
					}
				</tbody>
			</table>
			</div>
				);
		}
	}
	}
export default DistribuidorList;