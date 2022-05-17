import { useState, useEffect } from "react";
import axios from "axios";

import Sidebar from "../../../components/Sidebar/SiderbarAdm/SidebarAdmServicos";


export default function RedesVirtuais() {
    const [listaMaquinas, setListaMaquinas] = useState([]);
    const [dataCadastro, setDataCadastro] = useState("");
    const [listaDadosUsuario, setListaDadosUsuario] = useState([]);
    const refreshPage = () => {
        window.location.reload();
    }

    function buscarMaquinas() {
        axios('http://localhost:5000/api/Redevirtuals', {
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
                        <h1>Redes Virtuais</h1>
                    </div>
                    <div className="container-input">
                        <input type="text" placeholder="Buscar" />
                    </div>
                    <div className="listagem">
                        <div className="retangulo-usuario">
                            <h1>Nome da Rede Virtual</h1>
                            <h2>Data de Cadastro:</h2>
                            <p>14/04/2022</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}