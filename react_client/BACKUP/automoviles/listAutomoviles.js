import React from 'react';
import {Router} from 'react-router-dom';
class AutomovilesList extends React.Component{
	constructor(props){
		super(props);
		this.state={
		items: [],
		isFetched: false,
		error: null
		};
	}
	

	componentDidMount(){
		fetch("http://localhost:5001/api/automoviles/")
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
			<table className="table">
				<thead>
					<tr>
						<th>ID</th>
						<th>Nombre</th>
						<th>Descripcion</th>
						<th>Precio</th>
						<th>Ubicacion</th>
						<th>Palabra Clave</th>
						<th>ID Distribuidor</th>
					</tr>
				</thead>
				<tbody>
					{
						items.map(i=>
						<tr>
							<td>{i.id}</td>
							<td>{i.nombre}</td>
							<td>{i.descripcion}</td>
							<td>{i.precio}</td>
							<td>{i.ubicacion}</td>
							<td>{i.PalabraClave}</td>
							<td>{i.IdDistribuidor}</td>

						</tr>
					)
					}
				</tbody>
			</table>
				);
		}
	}
	}
export default AutomovilesList;