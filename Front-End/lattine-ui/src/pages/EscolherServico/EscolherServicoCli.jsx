import { Component } from "react";
import { Link } from "react-router-dom/cjs/react-router-dom.min";

import MaquinasVirtuais from '../../assets/img/maquinasvirtuais.png'
import RedesVirtuais from '../../assets/img/redesvirtuais.png'
import ServicosAplicacionais from '../../assets/img/servicosaplicacionais.png'

import '../../assets/css/style.css'

import Sidebar from "../../components/Sidebar/SidebarCli/SidebarCliServicos";


export default class Servicos extends Component {
    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <div className="container-conteudo-escolher-cli">
                        <h1>Tipos de Serviços</h1>
                        <div className="tabela-escolha">
                            <div className="escolha-servico">
                                <h2>Máquinas Virtuais</h2>
                                <div>
                                    <img src={MaquinasVirtuais} alt="Máquinas Virtuais" />
                                </div>
                                <div><Link to="maqvirusuariocli" className="selecionar-servico">Selecionar</Link></div>
                            </div>
                            <div className="escolha-servico">
                                <h2>Redes Virtuais</h2>
                                <div>
                                    <img src={RedesVirtuais} alt="Máquinas Virtuais" />
                                </div>
                                <div><Link to="redesvirtuaisusuariocli" className="selecionar-servico">Selecionar</Link></div>
                            </div>
                            <div className="escolha-servico">
                                <h2>Serviços Aplicacionais</h2>
                                <div>
                                    <img src={ServicosAplicacionais} alt="Máquinas Virtuais" />
                                </div>
                                <div><Link to="serapliusuariocli" className="selecionar-servico">Selecionar</Link></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}