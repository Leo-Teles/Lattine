import { Component } from "react";
import axios from "axios";
import { parseJWT } from '../../../services/auth';

import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SiderbarFun/SidebarFunServicos";


export default class CadastroIpfun extends Component {
    constructor(props) {
        super(props);
        this.state = {
            idUsuario: 0,
            endereco: "",
            listaIps: [],

            isLoading: false,
        };
    }

    buscarIps = () => {
        axios('http://localhost:5000/api/enderecoIps')
            .then((resposta) => {
                if (resposta.status === 200) {
                    this.setState({ listaIps: resposta.data });
                    console.log(this.state.listaIps);
                }
            })
            .catch((erro) => console.log(erro));
    };

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value });
    };

    componentDidMount() {
        console.log(parseJWT().jti);
        console.log('inicia ciclo de vida');
        this.buscarIps();
    }

    cadastrarIp = (event) => {
        event.preventDefault();
        this.setState({ isLoading: true });

        let ip = {
            idUsuario: parseJWT().jti,
            endereco: this.state.endereco,
        };

        axios
            .post('http://localhost:5000/api/enderecoips', ip, {
                headers: {
                    Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
                },
            })
            .then((resposta) => {
                if (resposta.status === 201) {
                    console.log('Ip Cadastrado.');
                    this.setState({ isLoading: false });
                }
            })
            .catch((erro) => {
                console.log(erro);
                this.setState({ isLoading: false });
            })
            .then(this.buscarIps);

            window.location.href = "criacaoredesvirtuaisfun";
    };

    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <form onSubmit={this.cadastrarIp} className="container-conteudo-edicao-servico">
                        <h1>Dados do Endereço IP</h1>

                        <h2>Detalhes do Endereço IP</h2>
                        <label htmlFor="ip">Espaço de Endereço IPv4</label>
                        <input
                            required
                            type="text"
                            name="endereco"
                            value={this.state.endereco}
                            onChange={this.atualizaStateCampo}
                            className="input-text-edicao"
                            id="ip" />

                        <div>
                            <button className="botao-editar">Criar</button>
                        </div>
                    </form>
                </div>
            </div>
        );
    }
}