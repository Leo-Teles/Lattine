import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import axios from "axios";
import { useParams } from "react-router-dom";

import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SiderbarFun/SidebarFunServicos";

export default function DadosRedeVirtual() {
    const [listaRedes, setListaRedes] = useState([]);
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
    const { id } = useParams();

    function buscarRedesUsuario() {
        axios('http://localhost:5000/api/RedeVirtuals/user/'+id, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaRedes(resposta.data)
                };
            })
            .catch(erro => console.log(erro));
    };
    useEffect(buscarRedesUsuario, []);

    function buscarDadosUsuario() {
        axios('http://localhost:5000/api/usuarios/um/'+id, {
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
    useEffect(buscarDadosUsuario, []);

    return (
        <div>
            <Sidebar />
            <div className="conteudo">
                <div className="container-conteudo-users">
                    {
                        listaDadosUsuario.map((usuario) => (
                            <div key={usuario.idUsuario} className="container-titulo">
                                <h1>Redes Virtuais de {usuario.nome}</h1>
                            </div>
                        )
                        )
                    }
                    <div className="container-input">
                        <input type="text" placeholder="Buscar" />
                    </div>
                    <div className="listagem">
                        {
                            listaRedes.map((rede) => (
                                <div key={rede.IdRedeVirtual} className="retangulo-usuario">
                                    <a href={"dadosredevirtualcli/" + rede.idRedeVirtual}>
                                        <h1>{rede.nomeRedeVirtual}</h1>
                                        <h2>Data de Cadastro:</h2>
                                        <p>{Intl.DateTimeFormat({
                                            year: "numeric", month: "numeric", day: "numeric"
                                        }).format(new Date(rede.dataCadastro))}</p>
                                    </a>
                                </div>
                            )
                            )
                        }
                    </div>
                    <div className="proxima-pagina">
                        <Link to="criacaoredesvirtuaiscli"><a>+ Criar Rede Virtual</a></Link>
                    </div>
                </div>
            </div>
        </div>
    )
}