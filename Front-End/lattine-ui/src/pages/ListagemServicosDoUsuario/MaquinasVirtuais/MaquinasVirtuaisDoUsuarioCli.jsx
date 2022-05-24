import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import axios from "axios";

import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SidebarCli/SidebarCliServicos";


export default function DadosMaquinaVirtual() {
    const [listaMaquinas, setListaMaquinas] = useState([]);
    const [listaUsuarios, setListaUsuarios] = useState([]);
    const [idTipoUsuario, setIdTipoUsuario] = useState(0);
    const [nome, setNome] = useState("");
    const [sobrenome, setSobrenome] = useState("");
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [dataCadastro, setDataCadastro] = useState("");
    const [listaDadosUsuario, setListaDadosUsuario] = useState([]);
    const refreshPage = () => {
        window.location.reload();
    }

    function buscarMinhasMaquinas() {
        axios('http://localhost:5000/api/MaquinaVirtuals/minhas', {
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
    useEffect(buscarMinhasMaquinas, []);

    function buscarMeusDados() {
        axios('http://localhost:5000/api/usuarios/meus', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaDadosUsuario(resposta.data)
                };
            })
            .catch(erro => console.log(erro));
    };
    useEffect(buscarMeusDados, []);

    return (
        <div>
            <Sidebar />
            <div className="conteudo">
                <div className="container-conteudo-users">
                    {
                        listaDadosUsuario.map((usuario) => (
                            <div key={usuario.idUsuario} className="container-titulo">
                                <h1>Máquinas Virtuais de {usuario.nome}</h1>
                            </div>
                        )
                        )
                    }
                    <div className="container-input">
                        <input type="text" placeholder="Buscar" />
                    </div>
                    <div className="listagem">
                        {
                            listaMaquinas.map((maquina) => (
                                <div key={maquina.idMaquinaVirtual} className="retangulo-usuario">
                                    <a href={"dadosmaqvircli/"+maquina.idMaquinaVirtual}>
                                        <h1>{maquina.nomeMaquinaVirtual}</h1>
                                        <h2>Data de Cadastro:</h2>
                                        <p>{Intl.DateTimeFormat({
                                            year: "numeric", month: "numeric", day: "numeric"
                                        }).format(new Date(maquina.dataCadastro))}</p>
                                        </a>
                                </div>
                            )
                            )
                        }
                    </div>
                    <div className="proxima-pagina">
                        <Link to="criacaomaqvircli"><a>+ Criar Máquina Virtual</a></Link>
                    </div>
                </div>
            </div>
        </div>
    )
}