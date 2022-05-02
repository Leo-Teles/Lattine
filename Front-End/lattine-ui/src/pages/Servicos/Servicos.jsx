import { Component } from "react";
import { Link } from "react-router-dom";

import '../../assets/css/style.css'

import imgLattine from "../../assets/img/Lattine.png"
import imgHome from "../../assets/img/Home.png"
import imgServicos from "../../assets/img/Ferramentas.png"
import imgConfiguracao from "../../assets/img/configuracao.png"
import imgSuporte from "../../assets/img/suporte.png"
import imgSair from "../../assets/img/sair.png"
import imgMaquinas from "../../assets/img/maquinaVirtual.png"
import imgAplicacionais from "../../assets/img/redesvirtuais.png"
import imgVirtuais from "../../assets/img/servicosaplicacionais.png"


export default class Servicos extends Component {
    render() {
        return (
            <div className="conteudotodo">

                <div className="conteudoEsquerda">

                    <img className="testeimg" src={imgLattine} alt="imagem do logo da lattine" />
                    <hr className="linha"></hr>

                    <nav className="blocoHome">
                        <Link to="/" className="botaoEscondido"> <img src={imgHome} alt="botão para redirecionar para home"/>  </Link>
                        <Link to="/" className="botaoEscondido"> Home</Link>

                    </nav>


                    <nav className="blocoServicos">
                        <Link to="/Servicos" className="botaoEscondido"> <img src={imgServicos} alt="botao para redirecionar para os serviços" /> </Link>
                        <Link to="/Servicos" className="botaoEscondido"> Serviços</Link>
                    </nav>

                    <nav className="blocoConfiguraçao">
                        <Link to=" Tela a ser feita" className="botaoEscondido"> <img src={imgConfiguracao} alt="botao para ir para configuração" /> </Link>
                        <Link to="Tela a ser feita" className="botaoEscondido"> Configuração</Link>
                    </nav>

                    <hr className="linha"></hr>

                    <nav className="blocoSuporte">
                        <Link to="Tela a ser criada" className="botaoEscondido"> <img src={imgSuporte} alt="botão para ir pro suporte" /> </Link>
                        <Link to="Tela a ser feita" className="botaoEscondido"> Suporte</Link>
                    </nav>

                    <nav className="blocoSair">
                        <Link to="/" className="botaoEscondido"> <img src={imgSair} alt="botão de sair da conta" /> </Link>
                        <Link to="Tela a ser feita" className="botaoEscondido"> Sair</Link>
                    </nav>
                </div>

                <div className="ConteudoDireita">

                    <nav className="maquinasVirtuais" >

                        <h1 className="tituloBloco">Maquina Virtual</h1>
                        <img src={imgMaquinas} className="imgBlocos" alt="Imagem representando máquinas virtuais"/>
                        <Link to="tela a ser criada" className="botaoBlocos" >
                         Selecionar
                        </Link>
                    </nav>

                    <nav className="servicosAplicacionais" >

                        <h1 className="tituloBloco">Serviços aplicacionais</h1>
                        <img src={imgAplicacionais} className="imgBlocos" alt="Imagem representando serviços aplicacionais"/>
                        <Link to="tela a ser criada" className="botaoBlocos" >
                         Selecionar
                        </Link>
                        
                    </nav>

                    <nav className="servicosAplicacionais" >

                        <h1 className="tituloBloco">Redes virtuais </h1>
                        <img src={imgVirtuais} className="imgBlocos" alt="Imagem representando redes virtuais"/>
                        <Link to="tela a ser criada" className="botaoBlocos" >
                         Selecionar
                        </Link>
                        
                    </nav>


                </div>

            </div>
        )
    }
}


