import axios from 'axios';
import React, { useState, useEffect } from "react";
import '../../assets/css/style.css'

import Sidebar from "../../components/Sidebar/SiderbarFun/SidebarFunConfig";


export default function DadosUsuario() {
    const [listaUsuarios, setListaUsuarios] = useState([]);
    const [idTipoUsuario, setIdTipoUsuario] = useState(0);
    const [nome, setNome] = useState("");
    const [sobrenome, setSobrenome] = useState("");
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [dataCadastro, setDataCadastro] = useState("");
    const refreshPage = () => {
        window.location.reload();
    }
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

    function BuscarUsuarios() {
        axios("http://localhost:5000/api/usuarios", {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaUsuarios(resposta.data);
                }
            }).catch(erro => console.log(erro));
    }
    useEffect(BuscarUsuarios, []);

    function AtualizarUsuario(usuario) {
        console.log(usuario.idUsuario);
        axios.put('http://localhost:5000/api/usuarios/' + usuario.idUsuario, {
            idTipoUsuario: idTipoUsuario,
            nome: nome,
            sobrenome: sobrenome,
            email: email,
            senha: senha,
            dataCadastro: dataCadastro,
        }, {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
        })
            .then(resposta => {
                if (resposta.status === 201) {
                    console.log("Usuário atualizado.");
                    setNome("");
                    setSobrenome("");
                    setEmail("");
                    setSenha("");
                }
            }).catch(erro => console.log(erro))
    }

    return (
        <div>
            <Sidebar />
            <div className="conteudo">
                <div className="container-conteudo-edicao">
                    <h1>Dados do Usuário</h1>
                    {
                        listaDadosUsuario.map((usuario) => (
                            <div key={usuario.idUsuario}>
                                <label for="nome">Nome</label>
                                <input id="nome" placeholder={usuario.nome}></input>
                                <label for="sobrenome">Sobrenome</label>
                                <input id="sobrenome" placeholder={usuario.sobrenome}></input>
                                <label for="email">E-mail</label>
                                <input id="email" placeholder={usuario.email}></input>
                                <label for="senha">Senha</label>
                                <input id="senha" placeholder={usuario.senha}></input>
                                <div className="ei">
                                    <button className="botao-editar">Editar</button>
                                </div>
                            </div>
                        )
                        )
                    }
                </div>
            </div>
        </div>
    )
}