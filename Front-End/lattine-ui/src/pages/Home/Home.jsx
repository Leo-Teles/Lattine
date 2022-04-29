import { Component } from 'react';
import { Link } from "react-router-dom";

<<<<<<< HEAD
import '../../assets/css/style.css';

import LogoLattine from '../../assets/img/Lattine.png'
=======
import '../../assets/css/Home.css';

import LogoLattine from '../../assets/img/LogoLattine.png'
>>>>>>> 04cd197115ba9bcbeaf11bcc095fc5f08279bba8
import imgHome from '../../assets/img/imgHome.png'

export default class Home extends Component {



    render() {
        return (
            <div className="ConteudoTodo">
                <header className="headerHome">
<<<<<<< HEAD
                    <img className="imgLattine" src={LogoLattine} alt="Logo da Lattine Group"/>
=======
                    <img className="imgLattine" src={LogoLattine} />
>>>>>>> 04cd197115ba9bcbeaf11bcc095fc5f08279bba8
                    <Link className="BotaoLogin" to="/login"> Login </Link>
                </header>

                <div className="Conteudo">

                    <div className="primeiroConteudo">

                        <div className="seguraConteudo">
                            <h1 className="FraseImpacto"> Pense diferente e experimente o poder de conectar pessoas!</h1>
                            <p className="textoBaixo"> Transformamos a maneira como empresas trabalham e produzem a partir da tecnologia e qualidade. Soluções inovadoras para organizações que buscam resultados extraordinários.</p>
                            <Link className="cadastre" to="/cadastro">Cadastre-se</Link>
                        </div>

<<<<<<< HEAD
                        <img className="imgHome" src={imgHome} alt="Fundo da Página Home"/>
=======
                        <img className="imgHome" src={imgHome} />
>>>>>>> 04cd197115ba9bcbeaf11bcc095fc5f08279bba8

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