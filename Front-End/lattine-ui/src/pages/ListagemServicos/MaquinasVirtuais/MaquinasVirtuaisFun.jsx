import { useState, useEffect } from "react";
import axios from "axios";

import Sidebar from "../../../components/Sidebar/SiderbarFun/SidebarFunServicos";


export default function MaquinasVirtuais() {
    const [listaMaquinas, setListaMaquinas] = useState([]);
    const [dataCadastro, setDataCadastro] = useState("");

    function buscarMaquinas() {
        axios('http://localhost:5000/api/MaquinaVirtuals', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaMaquinas(resposta.data)
                };
            })
            .catch(erro => console.log(erro));
    };
    useEffect(buscarMaquinas, []);

    return (
        <div>
            <Sidebar />
            <div className="conteudo">
                <div className="container-conteudo-users">
                    <div className="container-titulo">
                        <h1>Máquinas Virtuais</h1>
                    </div>
                    <div className="container-input">
                        <input type="text" placeholder="Buscar" />
                    </div>
                    <div className="listagem">
                        {
                            listaMaquinas.map((maquina) => (
                                <div key={maquina.IdMaquinaVirtual} className="retangulo-usuario">
                                    <h1>{maquina.nomeMaquinaVirtual}</h1>
                                    <h2>Data de Cadastro:</h2>
                                    <p>{Intl.DateTimeFormat({
                                        year: "numeric", month: "numeric", day: "numeric"
                                    }).format(new Date(maquina.dataCadastro))}</p>
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