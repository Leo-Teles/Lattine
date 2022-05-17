import { Component } from "react";
import { Link } from "react-router-dom/cjs/react-router-dom.min";

import MaquinasVirtuais from '../../assets/img/maquinasvirtuais.png'
import RedesVirtuais from '../../assets/img/redesvirtuais.png'
import ServicosAplicacionais from '../../assets/img/servicosaplicacionais.png'

import '../../assets/css/style.css'

import Sidebar from "../../components/Sidebar/SiderbarAdm/SidebarAdmServicos";


export default class Servicos extends Component {
    render() {
        return (
            <div>
                <Sidebar/>
                <div className="conteudoEscolha">
                    <div className="suguraBloco">

                        <div className="container-conteudo-escolher">
                            <h1>Tipos de Serviços</h1>

                            <div className="tabelaEscolha">

                                <div className="escolha-servico">
                                    <h2>Máquinas Virtuais</h2>
                                    <div>
                                        <img src={MaquinasVirtuais} alt="Máquinas Virtuais" />
                                    </div>
                                    <div><button className="selecionar-servico">Selecionar</button></div>
                                </div>
                                <div><Link to="maquinasvirtuaisadm" className="selecionar-servico">Selecionar</Link></div>
                            </div>
                            <div className="escolha-servico">
                                <h2>Redes Virtuais</h2>
                                <div>
                                    <img src={RedesVirtuais} alt="Máquinas Virtuais" />
                                </div>
                                <div><Link to="redesvirtuaisusuarioadm" className="selecionar-servico">Selecionar</Link></div>
                            </div>
                            <div className="escolha-servico">
                                <h2>Serviços Aplicacionais</h2>
                                <div>
                                    <img src={ServicosAplicacionais} alt="Máquinas Virtuais" />
                                </div>
                                <div><Link to="serapliusuarioadm" className="selecionar-servico">Selecionar</Link></div>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
            
        )
    }
}