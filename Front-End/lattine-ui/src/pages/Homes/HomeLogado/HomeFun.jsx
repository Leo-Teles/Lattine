
import { Link } from "react-router-dom";
import React, {useState} from "react";

import '../../../assets/css/style.css';
import Card from './Card';
import Data from './DataFun'


import LogoLattine from '../../../assets/img/Lattine.png'
import imgHome from '../../../assets/img/imgHome.png'

export default function Home() {

    const[ active, setActive] = useState("PrimeiroCard");


    
        return (
            <div className="ConteudoTodo">
                <header className="headerHome">
                    <img className="imgLattine" src={LogoLattine} alt="Logo da Lattine Group" />
                    <Link className="BotaoLogin" to="/login"> Deslogar </Link>
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

                        <nav className="menuButton">
                            <button onClick={() => setActive("PrimeiroCard")} className="botaoCard1"> Máquinas Virtuais </button>
                            <button onClick={() => setActive("SegundoCard")} className="botaoCard2"> Serviços Aplicacionais</button>
                            <button onClick={() => setActive("TerceiroCard")} className="botaoCard3"> Redes Virtuais</button>
                        </nav>

                        <div>
                            {active === "PrimeiroCard"  && <Card data={Data} cardHome={0} className="primeiroCard"/>}
                            {active === "SegundoCard"  && <Card data={Data} cardHome={1} className="sugundoCard"/>}
                            {active === "TerceiroCard"  && <Card data={Data} cardHome={2} className="terceiroCard"/>}
                        </div>

                        <h3 className="ultimaFrase"> Juntos podemos ir mais longe!</h3>





                    </div>

                </div>




            </div>
        )
    
}