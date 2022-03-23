import { Component } from "react";

import './Login.css'



export default class Login extends Component {
    

    render(){
        return(
            <div>

                <div class="primeiroBloco">

                 <h1 class="bemVindo">Bem-Vindo</h1>
                 <p class="semConta">Não possui uma conta?</p>

                 <button>Cadastre-se</button>

                

                </div>


            </div>
        )
    }
}