import React from 'react';

import EmpleadosList from '../empleados/listEmpleados.js'
import AddEmployes from '../empleados/addEmpleados.js'
import AddAgricultura from '../agricultura/addAgricultura.js'
import AddAutomoviles from '../automoviles/addAutomoviles.js'
import AddConstruccion from '../construccion/addConstruccion.js'
import AddDistribuidor from '../distribuidores/addDistribuidor.js'
import AgriculturaList from '../agricultura/listAgricultura.js'
import AutomovilesList from '../automoviles/listAutomoviles.js'
import ConstruccionList from '../construccion/listConstruccion.js'
import DeleteEmployees from '../empleados/deleteEmpleados.js'
import DeleteAgricultura from '../agricultura/deleteAgricultura.js'
import DeleteConstruccion from '../construccion/deleteConstruccion.js'
import DeleteDistribuidor from '../distribuidores/deleteDistribuidor.js'
import DeleteAutomoviles from '../automoviles/deleteAutomoviles.js'
import DistribuidorList from '../distribuidores/listDistribuidor.js'
import EditEmpleados from '../empleados/editEmpleados.js'
import EditDistribuidor from '../distribuidores/editDistribuidor.js'
import EditAgricultura from '../agricultura/editAgricultura.js'
import EditConstruccion from '../construccion/editConstruccion.js'
import EditAutomoviles from '../automoviles/editAutomoviles.js'
import IDEmpleados from '../empleados/idEmpleado.js'
import IDDistribuidor from '../distribuidores/idDistribuidor.js'
import IDAgricultura from '../agricultura/idAgricultura.js'
import IDAutomoviles from '../automoviles/idAutomoviles.js'
import IDConstruccion from '../construccion/idConstruccion.js'
import PalabraConstruccion from '../construccion/palabraConstruccion.js'
import PalabraAutomoviles from '../automoviles/palabraAutomoviles.js'
import PalabraAgricultura from '../agricultura/palabraAgricultura.js'


import {Helmet} from "react-helmet";
import $ from 'jquery';
import {
	BrowserRouter as Router,
	Link,
	Switch,
	Route
} from 'react-router-dom'; 

class Inicio extends React.Component{
	

render(){
	return(
		<Router>
		<div>
		 <div id="wrapper">

      
        <div id="main">
          <div className="inner">

            
            <header id="header">
              <div className="logo">
              
               <center><a href="http://localhost:3000"><img src="descarga.png" width="200" heigth="300" /></a></center>
                
              </div>
            </header>

            
            <section className="main-banner">
            
                
                        
                          
                          <Switch>
<Route path='/EmpleadosList' component={EmpleadosList} /> 
<Route path='/AddEmployes' component={AddEmployes} /> 
<Route path='/AddAgricultura' component = {AddAgricultura}/>
<Route path='/AddAutomoviles' component= {AddAutomoviles}/>
<Route path= '/AddConstruccion' component={AddConstruccion}/>
<Route path= '/AddDistribuidor' component={AddDistribuidor}/>
<Route path= '/AgriculturaList' component={AgriculturaList}/>
<Route path='/AutomovilesList' component={AutomovilesList}/>
<Route path='/ConstruccionList' component={ConstruccionList}/>
<Route path='/DeleteEmployees' component={DeleteEmployees}/>
<Route path='/DeleteAutomoviles' component={DeleteAutomoviles}/>
<Route path='/DeleteAgricultura' component={DeleteAgricultura}/>
<Route path='/DeleteConstruccion' component={DeleteConstruccion}/>
<Route path='/DeleteDistribuidor' component={DeleteDistribuidor}/>
<Route path='/DistribuidorList' component={DistribuidorList}/>
<Route path='/EditEmpleados' component={EditEmpleados}/>
<Route path='/EditAutomoviles' component={EditAutomoviles}/>

<Route path='/EditAgricultura' component={EditAgricultura}/>

<Route path='/EditConstruccion' component={EditConstruccion}/>

<Route path='/EditDistribuidor' component={EditDistribuidor}/>
<Route path='/IDEmpleados' component={IDEmpleados}/>
<Route path='/IDDistribuidor' component={IDDistribuidor}/>
<Route path='/IDAutomoviles' component={IDAutomoviles}/>
<Route path='/IDAgricultura' component={IDAgricultura}/>
<Route path='/IDConstruccion' component={IDConstruccion}/>
<Route path='/PalabraAgricultura' component={PalabraAgricultura}/>
<Route path='/PalabraAutomoviles' component={PalabraAutomoviles}/>
<Route path='/PalabraConstruccion' component={PalabraConstruccion}/>


</Switch>
                            
                        
                      
              
            </section>
          </div>
        </div>

        <div id="sidebar">

          <div className="inner">

           
           
              
            
            <nav id="menu">
              <ul>
                <li><a href="http://localhost:3000">Inicio</a></li>
               
        
                <li>
                  <span className="opener">Listado</span>
                  <ul>
                    <li><Link to={'/EmpleadosList'}>Empleados</Link></li>
                    <li><Link to={'/AgriculturaList'}>Agricultura</Link></li>
                    <li><Link to={'/AutomovilesList'}>Automoviles</Link></li>
                     <li><Link to={'/ConstruccionList'}>Construccion</Link></li>
                      <li><Link to={'/DistribuidorList'}>Distribuidores</Link></li>
                  </ul>
                </li>
                <li>
           
                  <span className="opener">Actualizar</span>
                  <ul>
                   <li><Link to={'/EditEmpleados'}>Empleados</Link></li>
                    <li><Link to={'/EditAgricultura'}>Agricultura</Link></li>
                     <li><Link to={'/EditAutomoviles'}>Automovil</Link></li>
                      <li><Link to={'/EditConstruccion'}>Construccion</Link></li>
                    <li><Link to={'/EditDistribuidor'}>Distribuidor</Link></li>
                  </ul>
                </li>
                <li>
           
                  <span className="opener">Palabra Clave</span>
                  <ul>
                
                    <li><Link to={'/PalabraAgricultura'}>Agricultura</Link></li>
                     <li><Link to={'/PalabraAutomoviles'}>Automovil</Link></li>
                      <li><Link to={'/PalabraConstruccion'}>Construccion</Link></li>
                    
                  </ul>
                </li>
                <li>
           
                  <span className="opener">ID</span>
                  <ul>
                   <li><Link to={'/IDEmpleados'}>Empleados</Link></li>
                    <li><Link to={'/IDAgricultura'}>Agricultura</Link></li>
                     <li><Link to={'/IDAutomoviles'}>Automovil</Link></li>
                      <li><Link to={'/IDConstruccion'}>Construccion</Link></li>
                    <li><Link to={'/IDDistribuidor'}>Distribuidor</Link></li>
                  </ul>
                </li>
                <li>
           
                  <span className="opener">Eliminar</span>
                  <ul>
                    <li><Link to={'/DeleteEmployees'}>Empleado</Link></li>
                    <li><Link to={'/DeleteAgricultura'}>Agricultura</Link></li>
                     <li><Link to={'/DeleteAutomoviles'}>Automovil</Link></li>
                    <li><Link to={'/DeleteConstruccion'}>Construccion</Link></li>
                     <li><Link to={'/DeleteDistribuidor'}>Distribuidor</Link></li>
                  </ul>
                </li>
                <li>
           
                  <span className="opener">Agregar</span>
                  <ul>
                    <li><Link to={'/AddEmployes'}>Empleados</Link></li>
                    <li><Link to={'/AddAgricultura'}>Agricultura</Link></li>
                    <li><Link to={'/AddAutomoviles'}>Automoviles</Link></li>
                    <li><Link to={'/AddConstruccion'}>Construccion</Link></li>
                     <li><Link to={'/AddDistribuidor'}>Distribuidor</Link></li>
                  </ul>
                </li>
                
              </ul>
            </nav>

        
            <div className="featured-posts">
              <div className="heading">
                <h2>Estamos contigo</h2>
              </div>
              <div className="owl-carousel owl-theme">
                <a href="#">
                  <div className="featured-item">
                    <img src="usuario-hombre-removebg-preview.png" />
                    <p>Comprometidos con el cliente</p>
                  </div>
                </a>
                <a href="#">
                  <div className="featured-item">
                    <img src="distribuidor-removebg-preview.png" alt="featured two"/>
                    <p>Los mejores distribuidores del estado</p>
                  </div>
                </a>
                <a href="#">
                  <div className="featured-item">
                    <img src="paquete-para-la-entrega-removebg-preview.png" alt="featured three"/>
                    <p>Productos de la mejor calidad</p>
                  </div>
                </a>
              </div>
            </div>

            <footer id="footer">
              <p className="copyright">Copyright &copy; 2021
              </p>
            </footer>

          </div>
        </div>

    </div>
    	<Helmet>
    	 <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <script src="assets/js/browser.min.js"></script>
    <script src="assets/js/breakpoints.min.js"></script>
    <script src="assets/js/transition.js"></script>
    <script src="assets/js/owl-carousel.js"></script>
    <script src="assets/js/custom.js"></script>
    	</Helmet>


		</div>
</Router>
		);
}
}
export default Inicio;