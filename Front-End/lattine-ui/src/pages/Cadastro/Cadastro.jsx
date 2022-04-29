import { Component } from "react";

import '../../assets/css/style.css'

import imgCadastro from '../../assets/img/pessoaCadastro.png';
import imgUsuario from '../../assets/img/pessoa.png';
import imgCadeado from '../../assets/img/cadeado.png';
import imgCarta from '../../assets/img/carta.png';
import { Link } from "react-router-dom";
import React from 'react';

export default class Cadastro extends Component {


    render() {
        return (

            <div className="blocoTodo">

                <div className="primeiroBloco">

                    <div className="teste-div">
                        <h1 className="cadastro">Cadastre-se</h1>
                        <p className="rapidofacil">É rápido e fácil.</p>
                    </div>

                    <img className="imgCadastro" src={imgCadastro} alt="Imagem Cadastro"/>
                </div>

                <div className="testeCadastro">
                    <div className="blocoSegundo">


                        <div>

                            <img className="imgUsuario" src={imgUsuario} alt="Imagem Usuário"/>
                            <input placeholder="Nome" className="input" />
                        </div>

                        <div>
                            <img className="imgUsuario" src={imgUsuario} alt="Imagem Usuário"/>

                            <input placeholder="Sobrenome" className="input" />
                        </div>

                        <div>
                            <img className="imgUsuario" src={imgCarta} alt="Imagem Carta"/>

                            <input placeholder="E-mail" className="input" />
                        </div>

                        <div>
                            <img className="imgUsuario" src={imgCadeado} alt="Imagem Cadeado"/>

                            <input placeholder="Senha" className="input" />
                        </div>

                        <div>
                            <img className="imgUsuario" src={imgCadeado} alt="Imagem Cadeado"/>

                            <input placeholder="Confirme a senha" className="input" />
                        </div>

                        <Link to="/" className="cadastrar"> Cadastrar </Link>

                    </div>

                </div>


            </div>
        )
    }

}