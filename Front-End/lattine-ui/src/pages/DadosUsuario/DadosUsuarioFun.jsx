import { useState, useEffect } from "react";
import axios from "axios";
import '../../assets/css/style.css'

import Sidebar from "../../components/Sidebar/SiderbarFun/SidebarFunConfig";


export default function DadosUsuario() {
    const [listaDadosUsuario, setListaDadosUsuario] = useState([]);

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
                <div className="container-conteudo">
                    {
                        listaDadosUsuario.map((usuario) => (
                            <div>
                                <h1>Dados do Usuário</h1>
                                <h2>Nome</h2>
                                <p>{usuario.nome}</p>
                                <h2>Sobrenome</h2>
                                <p>{usuario.sobrenome}</p>
                                <h2>E-mail</h2>
                                <p>{usuario.email}</p>
                                <h2>Senha</h2>
                                <p>{usuario.senha}</p>
                                <h2>Tipo de Usuário</h2>
                                <p>Funcionário Lattine Group</p>
                                <a href="edicaodadosusuariofun">Editar informações</a>
                            </div>
                        )
                        )
                    }
                </div>
            </div>
        </div>
    )
}