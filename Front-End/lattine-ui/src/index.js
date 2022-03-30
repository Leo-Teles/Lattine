import React from 'react';
import ReactDOM from 'react-dom';

import './index.css';

import Home from './Pages/Home/Home';
import Login from './Pages/Login/Login';
import Cadastro from './Pages/Cadastro/Cadastro';
import NotFound from './Pages/NotFound/NotFound';
import reportWebVitals from './reportWebVitals';

import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Routes,
} from 'react-router-dom';


const routing = (

    <Router>
      <div>
        <Routes>
          
          <Route exact path="/" element={<Login />} /> 
          <Route path="/Cadastro" element={<Cadastro />} />
          <Route path="*" element={<NotFound/>} />
          
        </Routes>
      </div>
    </Router>
  
)

ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
