import { Component } from "react";

import './Login.css'

import imgEsquerda from '../Assets/imgLogin.png'
import imgUsuario from '../Assets/pessoa.png'
import imgCadeado from '../Assets/cadeado.png'




export default class Login extends Component {

    // constructor(props) {
    //     super(props)
    //     this.state = {
    //         email: '',
    //         senha: '',
    //         isLoading: false,
    //         MensagemErro: '',
    //     }
    // }



    render() {
        return (
            <div className="blocoTodo">


                <div className="primeiroBloco">

                    <div className="teste-div">
                        <h1 className="bemVindo">Bem-Vindo</h1>
                        <p className="semConta">Não possui uma conta?</p>

                        <form>
                            <button type='submit' className="cadastre">Cadastre-se</button>
                        </form>

                    </div>

                    <img className="imgLogin" src={imgEsquerda} alt="Moça em pé a esqueda" />
                </div>
                <div className="testeLogin">


                    <form className="segundoBloco">

                        <div>
                            <img className="imgUsuario" src={imgUsuario} alt="img do usuario pequeno"/>

                            <input name="email" type="text" placeholder="Usuário" className="primeiroInput" />
                        </div>

                        <div>
                            <img className="imgCadeado" src={imgCadeado} alt="cadeado pequeno da senha"/>

                            <input name="senha" type="password" placeholder="Senha" className="segundoInput" />
                        </div>

                        <button type='submit' className="entrar"> Entrar </button>

                    </form>

                </div>

            </div>
        )
    }
}