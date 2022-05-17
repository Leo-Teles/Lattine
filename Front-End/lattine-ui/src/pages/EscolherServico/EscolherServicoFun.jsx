import { Component } from "react";

import MaquinasVirtuais from '../../assets/img/maquinasvirtuais.png'
import RedesVirtuais from '../../assets/img/redesvirtuais.png'
import ServicosAplicacionais from '../../assets/img/servicosaplicacionais.png'
import { Link } from "react-router-dom";
import '../../assets/css/style.css'

import Sidebar from "../../components/Sidebar/SiderbarFun/SidebarFunServicos";


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
                                <div><Link to="maquinasvirtuaisfun" className="selecionar-servico">Selecionar</Link></div>
                            </div>
                            <div className="escolha-servico">
                                <h2>Redes Virtuais</h2>
                                <div>
                                    <img src={RedesVirtuais} alt="Máquinas Virtuais" />
                                </div>
                                <div><Link to="redesvirtuaisfun" className="selecionar-servico">Selecionar</Link></div>                            </div>
                            <div className="escolha-servico">
                                <h2>Serviços Aplicacionais</h2>
                                <div>
                                    <img src={ServicosAplicacionais} alt="Máquinas Virtuais" />
                                </div>
                                <div><Link to="seraplifun" className="selecionar-servico">Selecionar</Link></div>                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}