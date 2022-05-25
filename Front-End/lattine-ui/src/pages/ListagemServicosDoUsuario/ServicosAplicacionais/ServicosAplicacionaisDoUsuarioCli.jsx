import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import axios from "axios";

import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SidebarCli/SidebarCliServicos";


export default function DadosServicoAplicacional() {
    const [listaServicos, setListaServicos] = useState([]);
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

    function buscarMeusServicos() {
        axios('http://localhost:5000/api/ServicoAplicacionals/meus', {
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
    useEffect(buscarMeusServicos, []);

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
                                <h1>Serviços Aplicacionais de {usuario.nome}</h1>
                            </div>
                        )
                        )
                    }
                    <div className="container-input">
                        <input type="text" placeholder="Buscar" />
                    </div>
                    <div className="listagem">
                        {
                            listaServicos.map((servico) => (
                                <div key={servico.IdServicoAplicacional} className="retangulo-usuario">
                                    <a href={"dadosseraplicli/" + servico.idServicoAplicacional}>
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
                    <div className="proxima-pagina">
                        <Link to="criacaoseraplicli"><a>+ Criar Serviço Aplicacional</a></Link>
                    </div>
                </div>
            </div>
        </div>
    )
}