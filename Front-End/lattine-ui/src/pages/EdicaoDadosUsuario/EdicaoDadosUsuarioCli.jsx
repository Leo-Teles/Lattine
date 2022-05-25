import { Component } from "react";
import axios from "axios";
import { parseJWT } from '../../services/auth';
import '../../assets/css/style.css'
import Sidebar from "../../components/Sidebar/SidebarCli/SidebarCliConfig";

export default class EditarUsuario extends Component {
    constructor(props) {
        super(props);
        this.state = {
            nome: '',
            sobrenome: '',
            email: '',
            senha: '',

            listaMeusDados: [],
            listaUsuarios: [],
            isLoading: false,
        };
    }

    buscarMeusDados = () => {
        axios('http://localhost:5000/api/usuarios/meus')
            .then((resposta) => {
                if (resposta.status === 200) {
                    this.setState({ listaMeusDados: resposta.data });
                    console.log(this.state.listaMeusDados);
                }
            })
            .catch((erro) => console.log(erro));
    };

    buscarUsuarios = () => {
        axios('http://localhost:5000/api/usuarios')
            .then((resposta) => {
                if (resposta.status === 200) {
                    this.setState({ listaUsuarios: resposta.data });
                    console.log(this.state.listaUsuarios);
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
        this.buscarMeusDados();
        this.buscarUsuarios();
    }

    EditarUsuario = (event) => {
        event.preventDefault();
        this.setState({ isLoading: true });

        let idUsuario = parseJWT().jti;

        let usuario = {
            nome: this.state.nome,
            sobrenome: this.state.sobrenome,
            email: this.state.email,
            senha: this.state.senha,
        };

        axios
            .post('http://localhost:5000/api/usuarios/' + idUsuario, usuario, {
                headers: {
                    Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
                },
            })
            .then((resposta) => {
                if (resposta.status === 201) {
                    console.log('Usuário Atualizado.');
                    this.setState({ isLoading: false });
                }
            })
            .catch((erro) => {
                console.log(erro);
                this.setState({ isLoading: false });
            })
            .then(this.buscarMeusDados);

        window.location.href = "escolherservicocli";
    };

    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <form onSubmit={this.EditarUsuario} className="container-conteudo-edicao">
                        <h1>Dados do Usuário</h1>
                        <div>
                            <label for="nome">Nome</label>
                            <input
                                required
                                type="text"
                                name="nome"
                                value={this.state.nome}
                                onChange={this.atualizaStateCampo}
                                className="input-text-edicao"
                                id="nome"
                            />
                            <label for="sobrenome">Sobrenome</label>
                            <input
                                id="sobrenome"
                                required
                                type="text"
                                name="sobrenome"
                                value={this.state.sobrenome}
                                onChange={this.atualizaStateCampo}
                                className="input-text-edicao" />
                            <label for="email">E-mail</label>
                            <input
                                required
                                type="text"
                                name="email"
                                value={this.state.email}
                                onChange={this.atualizaStateCampo}
                                className="input-text-edicao" />
                            <label for="senha">Senha</label>
                            <input
                                required
                                type="text"
                                name="senha"
                                value={this.state.senha}
                                onChange={this.atualizaStateCampo}
                                className="input-text-edicao" />
                            <div>
                                <button type="submit" className="botao-editar">Editar</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        );
    }
}