import { Component } from "react";

import './Cadastro.css'

import imgCadastro from '../Assets/pessoaCadastro.png';
import imgUsuario from '../Assets/pessoa.png';
import imgCadeado from '../Assets/cadeado.png';
import imgCarta from '../Assets/carta.png';

export default class Cadastro extends Component {


    render() {
        return (

            <div className="blocoTodo">

                <div className="primeiroBloco">

                    <div className="teste-div">
                        <h1 className="cadastro">Cadastre-se</h1>
                        <p className="rapidofacil">É rápido e fácil.</p>
                    </div>

                    <img className="imgCadastro" src={imgCadastro} />
                </div>

                <div className="blocoSegundo">

                    <div>

                        <img className="imgUsuario" src={imgUsuario} />

                        <input className="Input" />
                    </div>

                    <div>
                        <img className="imgUsuario" src={imgUsuario} />

                        <input className="Input" />
                    </div>

                    <div>
                        <img className="imgUsuario" src={imgCarta} />

                        <input className="Input" />
                    </div>

                    <div>
                        <img className="imgUsuario" src={imgCadeado} />

                        <input className="Input" />
                    </div>

                    <div>
                        <img className="imgUsuario" src={imgCadeado} />

                        <input className="Input" />
                    </div>

                    <button className="Cadastrar"> Cadastrar </button>

                </div>




            </div>
        )
    }

}