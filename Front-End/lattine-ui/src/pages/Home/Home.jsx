import { Component } from 'react';
import { Link } from "react-router-dom";

import '../../assets/css/style.css';

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
                            <Link className="cadastre" to="/cadastro">Cadastre-se</Link>
                        </div>

                        <img className="imgHome" src={imgHome} alt="Fundo da Página Home" />

                    </div>

                    <div className="seguendoConteudo">

                        <h2 className="servicosOfertados">Nossos serviços </h2>

                        <nav>
                            <button> Máquinas virtuais </button>

                            <button> Redes virtuais</button>

                            <button> Serviços aplicacionais</button>
                        </nav>





                    </div>

                </div>




            </div>
        )
    }
}