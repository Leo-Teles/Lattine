import { Component } from "react";
import axios from "axios";
import { parseJWT } from '../../../services/auth';

import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SiderbarFun/SidebarFunServicos";


export default class CadastroSubRedeFun extends Component {
    constructor(props) {
        super(props);
        this.state = {
            idUsuario: 0,
            nomeSubRede: "",
            intervalosEndereco: "",
            listaSubRedes: [],

            isLoading: false,
        };
    }

    buscarSubRedes = () => {
        axios('http://localhost:5000/api/subredes')
            .then((resposta) => {
                if (resposta.status === 200) {
                    this.setState({ listaSubRedes: resposta.data });
                    console.log(this.state.listaSubRedes);
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
        this.buscarSubRedes();
    }

    cadastrarSubRede = (event) => {
        event.preventDefault();
        this.setState({ isLoading: true });

        let subrede = {
            idUsuario: parseJWT().jti,
            nomeSubRede: this.state.nomeSubRede,
            intervalosEndereco: this.state.intervalosEndereco,
        };

        axios
            .post('http://localhost:5000/api/subredes', subrede, {
                headers: {
                    Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
                },
            })
            .then((resposta) => {
                if (resposta.status === 201) {
                    console.log('Sub-Rede Cadastrada.');
                    this.setState({ isLoading: false });
                }
            })
            .catch((erro) => {
                console.log(erro);
                this.setState({ isLoading: false });
            })
            .then(this.buscarSubRedes);

            window.location.href = "criacaoredesvirtuaisFun";
    };

    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <form onSubmit={this.cadastrarSubRede} className="container-conteudo-edicao-servico">
                        <h1>Dados da Sub-Rede</h1>

                        <h2>Detalhes da Sub-Rede</h2>
                        <label htmlFor="NomeSubRede">Nome da Sub-Rede</label>
                        <input
                            required
                            type="text"
                            name="nomeSubRede"
                            value={this.state.nomeSubRede}
                            onChange={this.atualizaStateCampo}
                            className="input-text-edicao"
                            id="NomeSubRede" />

                        <label htmlFor="iendereco">Intervalo do Endereço</label>
                        <input
                            required
                            type="text"
                            name="intervalosEndereco"
                            value={this.state.intervalosEndereco}
                            onChange={this.atualizaStateCampo}
                            className="input-text-edicao"
                            id="iendereco" />

                        <div>
                            <button className="botao-editar">Criar</button>
                        </div>
                    </form>
                </div>
            </div>
        );
    }
}