import { Component } from "react";

import '../../assets/css/style.css'

import imgEsquerda from '../../assets/img/imgLogin.png'
import imgUsuario from '../../assets/img/pessoa.png'
import imgCadeado from '../../assets/img/cadeado.png'
import { Link } from "react-router-dom";
import { parseJWT, usuarioAutenticado } from '../../services/auth';
import axios from "axios";

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: '',
            erroMensagem: '',
            isLoading: false
        };
    };

    efetuaLogin = (event) => {
        event.preventDefault();

        this.setState({ erroMensagem: '', isLoading: true });
        axios.post('http://localhost:5000/api/login/login', {
            email: this.state.email,
            senha: this.state.senha
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    console.log('API')
                    localStorage.setItem("usuario-login", resposta.data.token);
                    this.setState({ isLoading: false });

                    let base64 = localStorage.getItem('usuario-login').split('.')[1];
                    console.log(base64);

                    let value = parseJWT().role;

                    switch (value) {
                        case "1":
                            this.props.history.push("/escolherservicoadm")
                            console.log("Estou logado: " + usuarioAutenticado())
                            break;

                        case "2":
                            this.props.history.push("/escolherservicocli")
                            console.log("Estou logado: " + usuarioAutenticado())
                            break;

                        case "3":
                            this.props.history.push("/escolherservicofun")
                            console.log("Estou logado: " + usuarioAutenticado())
                            break;

                        default:
                            this.props.history.push("/login")
                            break;
                    }
                }
            }).catch(() => {
                this.setState({ erroMensagem: 'E-mail e/ou senha inválidos.', isLoading: false })
            })
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    }

    render() {
        return (
            <div className="blocoTodo">


                <div className="primeiroBloco">

                    <div className="teste-div">
                        <h1 className="bemVindo">Bem-Vindo</h1>
                        <p className="semConta">Não possui uma conta?</p>

                        <Link to="/cadastro" type='submit' className="cadastre">Cadastre-se</Link>

                    </div>

                    <img className="imgLogin" src={imgEsquerda} alt="Moça em pé a esqueda" />
                </div>
                <div className="testeLogin">


                    <div className="segundoBloco">

                        <div>
                            <img className="imgUsuario" src={imgUsuario} alt="img do usuario pequeno" />

                            <input
                                type="text"
                                name="email"
                                value={this.state.email}
                                className="input"
                                placeholder="E-mail"
                                onChange={this.atualizaStateCampo}>
                            </input>
                        </div>

                        <div>
                            <img className="imgCadeado" src={imgCadeado} alt="cadeado pequeno da senha" />

                            <input
                                type="password"
                                name="senha"
                                value={this.state.senha}
                                className="input"
                                placeholder="Senha"
                                onChange={this.atualizaStateCampo}>
                            </input>
                        </div>

                        {
                            this.state.isLoading === true &&
                            <button type="submit" disabled className="entrar">Entrar</button>
                        }
                        {
                            this.state.isLoading === false &&
                            <button type="button" disabled={this.state.email === '' || this.state.senha === '' ? 'none' : ''}
                                className="entrar" onClick={this.efetuaLogin}>Entrar</button>
                        }
                        <p className="Erro">{this.state.erroMensagem}</p>
                    </div>
                    
                </div>
            </div>
        )
    }
}