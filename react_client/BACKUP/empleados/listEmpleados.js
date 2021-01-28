import React from 'react';
class EmpleadosList extends React.Component{
	constructor(props){
		super(props);

		this.state={
			items: [],
			isFetched: false,
			error: null
		};
	}
	componentDidMount () {
		fetch("http://localhost:5001/api/empleados/")
		.then(res=> res.json())
		.then(
			(result)=>{
				this.setState({
					items: result,
					isFetched: true,
					error: null
				}
				);
			},
			(error)=>{
				this.setState({
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
				return (<div><p>{error.message}</p></div>);
				}else if(!isFetched){
					return(<div><p>Loading....</p></div>);
			}else{
			return(
			<table className="table">
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
				);
		}
	}
	}
export default EmpleadosList;