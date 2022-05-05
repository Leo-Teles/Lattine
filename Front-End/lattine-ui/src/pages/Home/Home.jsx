import { Component } from 'react';
import { Link } from "react-router-dom";
import React, {useState} from "react";

import '../../assets/css/style.css';
import Card from './Card';

import LogoLattine from '../../assets/img/Lattine.png'
import imgHome from '../../assets/img/imgHome.png'

export default class Home extends Component {

    
    



    render() {
        return (
            <div className="ConteudoTodo">
                <header className="headerHome">
                    <img className="imgLattine" src={LogoLattine} alt="Logo da Lattine Group" />
                    <Link className="BotaoLogin" to="/login"> Login </Link>
                </header>

                <div className="Conteudo">

                    <div className="primeiroConteudo">

                        <div className="seguraConteudo">
                            <h1 className="FraseImpacto"> Pense diferente e experimente o poder de conectar pessoas!</h1>
                            <p className="textoBaixo"> Transformamos a maneira como empresas trabalham e produzem a partir da tecnologia e qualidade. Soluções inovadoras para organizações que buscam resultados extraordinários.</p>
                            <Link className="cadastreHome" to="/cadastro">Cadastre-se</Link>
                        </div>

                        <img className="imgHome" src={imgHome} alt="Fundo da Página Home" />

                    </div>

                    <div className="seguendoConteudo">

                        <h2 className="servicosOfertados">Nossos serviços </h2>

                        <nav>
                            <button>Maquinas Virtual </button>
                            <button>Serviços Operacionais</button>
                            <button> Redes Virtuais</button>
                        </nav>

                        <div>
                            <Card title="1" />
                            <Card title="2" />
                            <Card title="3" />
                        </div>





                    </div>

                </div>




            </div>
        )
    }
}