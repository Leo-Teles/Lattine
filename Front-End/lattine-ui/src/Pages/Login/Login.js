import { Component } from "react";

import './Login.css'

import imgEsquerda from '../Assets/imgLogin.png'
import imgUsuario from '../Assets/pessoa.png'
import imgCadeado from '../Assets/cadeado.png'




export default class Login extends Component {


    render() {
        return (
            <div className="blocoTodo">

                <div className="primeiroBloco">

                    <div className="teste-div">
                        <h1 className="bemVindo">Bem-Vindo</h1>
                        <p className="semConta">Não possui uma conta?</p>

                        <button className="cadastro">Cadastre-se</button>
                    </div>

                    <img className="imgLogin" src={imgEsquerda} />
                </div>

                <div className="segundoBloco">

                    <img className="imgUsuario" src={imgUsuario}/>

                    <input className="inputInicial"/> 

                    <img className="imgCadeado" src={imgCadeado} />

                    <input className="inputInicial"/>

                    <button className="entrar"> Entrar </button>



                </div>



            </div>
        )
    }
}