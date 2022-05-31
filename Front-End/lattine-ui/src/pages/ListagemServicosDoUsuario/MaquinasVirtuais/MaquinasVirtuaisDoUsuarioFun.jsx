import { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import axios from "axios";
import { useParams } from "react-router-dom";
import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SiderbarFun/SidebarFunServicos";


export default function DadosServicos() {
    const [listaMaquinas, setListaMaquinas] = useState([]);
    const [listaRedes, setListaRedes] = useState([]);
    const [listaServicos, setListaServicos] = useState([]);
    const [listaDadosUsuario, setListaDadosUsuario] = useState([]);
    const refreshPage = () => {
        window.location.reload();
    }
    const { id } = useParams();

    function buscarMaquinasUsuario() {
        axios('http://localhost:5000/api/MaquinaVirtuals/user/'+id, {
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
    useEffect(buscarMaquinasUsuario, []);

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

    function buscarServicosUsuario() {
        axios('http://localhost:5000/api/Servicoaplicacionals/user/'+id, {
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
    useEffect(buscarServicosUsuario, []);

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
                        listaDadosUsuario.map((user) => (
                            <div key={user.idUsuario} className="container-titulo">
                                <h1>Serviços de {user.nome}</h1>
                            </div>
                        )
                        )
                    }
                    <h2 className="titulo-outro">Máquinas Virtuais</h2>
                    <div className="listagem">
                        {
                            listaMaquinas.map((maquina) => (
                                <div key={maquina.idMaquinaVirtual} className="retangulo-usuario">
                                    <a href={"/dadosmaqvirFun/"+maquina.idMaquinaVirtual}>
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
                    <h2 className="titulo-outro">Redes Virtuais</h2>
                    <div className="listagem">
                        {
                            listaRedes.map((maquina) => (
                                <div key={maquina.idRedeVirtual} className="retangulo-usuario">
                                    <a href={"/dadosredevirtualFun/"+maquina.idRedeVirtual}>
                                        <h1>{maquina.nomeRedeVirtual}</h1>
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
                    <h2 className="titulo-outro">Serviços Aplicacionais</h2>
                    <div className="listagem">
                        {
                            listaServicos.map((maquina) => (
                                <div key={maquina.idServicoAplicacional} className="retangulo-usuario">
                                    <a href={"/dadosserapliFun/"+maquina.idServicoAplicacional}>
                                        <h1>{maquina.nomeServicoAplicacional}</h1>
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
                </div>
            </div>
        </div>
    )
}