import { useState, useEffect } from "react";
import axios from "axios";

import Sidebar from "../../../components/Sidebar/SiderbarAdm/SidebarAdmServicos";


export default function ServicosAplicacionais() {
    const [listaServicos, setListaServicos] = useState([]);
    const [dataCadastro, setDataCadastro] = useState("");

    function buscarServicos() {
        axios('http://localhost:5000/api/ServicoAplicacionals', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaServicos(resposta.data)
                };
            })
            .catch(erro => console.log(erro));
    };
    useEffect(buscarServicos, []);

    return (
        <div>
            <Sidebar />
            <div className="conteudo">
                <div className="container-conteudo-users">
                    <div className="container-titulo">
                        <h1>Serviços Aplicacionais</h1>
                    </div>
                    <div className="container-input">
                        <input type="text" placeholder="Buscar" />
                    </div>
                    <div className="listagem">
                        {
                            listaServicos.map((servico) => (
                                <div key={servico.IdServicoAplicacional} className="retangulo-usuario">
                                    <a href={"dadosserapliadm/"+servico.idServicoAplicacional}>
                                    <h1>{servico.nomeServicoAplicacional}</h1>
                                    <h2>Data de Cadastro:</h2>
                                    <p>{Intl.DateTimeFormat({
                                        year: "numeric", month: "numeric", day: "numeric"
                                    }).format(new Date(servico.dataCadastro))}</p>
                                    </a>
                                </div>
                            )
                            )
                        }
                    </div>
                </div>
            </div>
        </div>
    )
}