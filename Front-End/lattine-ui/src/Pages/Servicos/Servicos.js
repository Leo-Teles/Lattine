import { Component } from "react";
import { Link } from "react-router-dom";

import './Servicos.css';

import imgLattine from "../Assets/Lattine.png"
import imgHome from "../Assets/Home.png"
import imgServicos from "../Assets/Ferramentas.png" 
import imgConfiguracao from "../Assets/configuracao.png"
import imgSuporte from "../Assets/suporte.png"
import imgSair from "../Assets/sair.png"


export default class Servicos extends Component {
    render(){
        return(
            <div className="conteudotodo">

                <div className="conteudoEsquerda">

                    <img className="testeimg" src={imgLattine} alt="imagem do logo da lattine"  />
                    <hr className="linha"></hr>

                     <nav className="blocoHome">
                         <Link to="/" className="botaoEscondido"> <img src={imgHome} alt=""botão para redirecionar para home/>  </Link>
                         <Link to="/" className="botaoEscondido"> Home</Link>
                          
                     </nav>
                    

                    <nav className="blocoServicos">
                        <Link to="/Servicos"  className="botaoEscondido"> <img src={imgServicos} alt="botao para redirecionar para os serviços"/> </Link>
                        <Link to="/Servicos" className="botaoEscondido"> Serviços</Link>
                    </nav>

                    <nav className="blocoConfiguraçao">
                        <Link to=" Tela a ser feita"  className="botaoEscondido"> <img src={imgConfiguracao} alt="botao para ir para configuração"/> </Link>
                        <Link to="Tela a ser feita" className="botaoEscondido"> Configuração</Link>
                    </nav>

                    <hr className="linha"></hr>

                    <nav className="blocoSuporte">
                        <Link to="Tela a ser criada"  className="botaoEscondido"> <img src={imgSuporte} alt="botão para ir pro suporte"/> </Link>
                        <Link to="Tela a ser feita" className="botaoEscondido"> Suporte</Link>
                    </nav>

                    <nav className="blocoSair">
                        <Link to="/"  className="botaoEscondido"> <img src={imgSair} alt="botão de sair da conta"/> </Link>
                        <Link to="Tela a ser feita" className="botaoEscondido"> Sair</Link>
                    </nav>
                </div>

                <div className="ConteudoDireita">

                    <nav className="maquinasVirtuais" > 
                        <Link to="tela a ser criada" className="maquinasVirtuais" >
                         
                         
                         </Link>
                    </nav>

                </div>

            </div>
        )
    }
}


