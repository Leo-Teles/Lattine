import React, { useState, useEffect } from "react";
import axios from "axios";

import '../../assets/css/style.css'

import imgCadastro from '../../assets/img/pessoaCadastro.png';
import imgUsuario from '../../assets/img/pessoa.png';
import imgCadeado from '../../assets/img/cadeado.png';
import imgCarta from '../../assets/img/carta.png';

export default function Cadastro() {
    const [listaUsuarios, setListaUsuarios] = useState([]);
    const [idTipoUsuario, setIdTipoUsuario] = useState(0);
    const [nome, setNome] = useState("");
    const [sobrenome, setSobrenome] = useState("");
    const [email, setEmail] = useState("");
    const [senha, setSenha] = useState("");
    const [dataCadastro, setDataCadastro] = useState(new Date());

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

    function CadastrarUsuario(usuario) {
        axios.post("http://localhost:5000/api/usuarios", {
            idTipoUsuario: "2",
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
                    console.log("Novo usuário cadastrado.");
                    BuscarUsuarios();
                    setIdTipoUsuario(0);
                    setNome("");
                    setSobrenome("");
                    setEmail("");
                    setSenha("");
                    setDataCadastro(new Date());
                }
            }).catch(erro => console.log(erro))
        usuario.preventDefault();
        window.location.href = "login";
    }

    return (

        <div className="blocoTodo">

            <div className="primeiroBloco">

                <div className="teste-div">
                    <h1 className="cadastro">Cadastre-se</h1>
                    <p className="rapidofacil">É rápido e fácil.</p>
                </div>

                <img className="imgCadastro" src={imgCadastro} alt="Imagem Cadastro" />
            </div>

            <div className="testeCadastro">
                <form onSubmit={CadastrarUsuario} className="blocoSegundo">


                    <div>

                        <img className="imgUsuario" src={imgUsuario} alt="Imagem Usuário" />
                        <input value={nome} onChange={(campo) =>
                            setNome(campo.target.value)} placeholder="Nome" className="input" />
                    </div>

                    <div>
                        <img className="imgUsuario" src={imgUsuario} alt="Imagem Usuário" />

                        <input value={sobrenome} onChange={(campo) =>
                            setSobrenome(campo.target.value)} placeholder="Sobrenome" className="input" />
                    </div>

                    <div>
                        <img className="imgUsuario" src={imgCarta} alt="Imagem Carta" />

                        <input value={email} onChange={(campo) =>
                            setEmail(campo.target.value)} placeholder="E-mail" className="input" />
                    </div>

                    <div>
                        <img className="imgUsuario" src={imgCadeado} alt="Imagem Cadeado" />

                        <input type="password" value={senha} onChange={(campo) =>
                            setSenha(campo.target.value)} placeholder="Senha" className="input" />
                    </div>
                        <button type="submit" className="cadastrar"> Cadastrar </button>

                </form>

            </div>


        </div>
    )
}