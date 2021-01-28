import ListEmpleados from './empleados/listEmpleados.js'
import AddEmpleados from './empleados/addEmpleados.js'
import Login from './login/login.js'
import Inicio from './login/inicio.js'
import { useState } from 'react';
import IdleTimer from 'react-idle-timer';
import { If, Then, ElseIf, Else } from 'react-if-elseif-else-render';
import './App.css';

import {
	BrowserRouter as Router,
	Link,
	Switch,
	Route
} from 'react-router-dom'; 

function App (){
	var ID = localStorage.getItem('ID');
 var Password = localStorage.getItem('Password');
 

 


  return(
    <Router>
				<div className="container">
				<If condition={ ID===null  && Password ===null }>
			<Then>
			<Inicio />
			</Then>
			<ElseIf condition={ ID!=0}>
         				<p>OK</p>			 
         </ElseIf>
         <ElseIf condition={ ID==1}>
         					<p>OK AD</p>	 
         </ElseIf>
         </If>
				<Switch>
					
				</Switch>
			</div>
		</Router>

    );
}
export default App;
