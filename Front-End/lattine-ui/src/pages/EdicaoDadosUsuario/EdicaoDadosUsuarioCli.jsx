import { Component } from "react";
import axios from "axios";
import { parseJWT } from '../../services/auth';
import '../../assets/css/style.css'
import Sidebar from "../../components/Sidebar/SidebarCli/SidebarCliConfig";

export default class EditarUsuario extends Component {
    constructor(props) {
        super(props);
        this.state = {
            idTipoUsuario: 2,
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
        axios('http://localhost:5000/api/usuarios/meus', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            }
        })
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

    limparCampos = () => {
        this.setState({
            nome: '',
            sobrenome: '',
            email: '',
            senha: '',
        });
    };

    editar = (submit_formulario) => {
        submit_formulario.preventDefault();

        if (parseJWT().jti !== 0) {
            fetch(
                'http://localhost:5000/api/usuarios/' +
                parseJWT().jti,
                {
                    method: 'PUT',
                    body: JSON.stringify({
                        idTipoUsuario: 2,
                        nome: this.state.nome,
                        sobrenome: this.state.sobrenome,
                        email: this.state.email,
                        senha: this.state.senha,
                        dataCadastro: new Date()
                    }),
                    headers: {
                        'Content-Type': 'application/json',
                        Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
                    },
                },
            )
                .then((resposta) => {
                    if (resposta.status === 204) {
                        console.log(
                            'O Usuário ' +
                            parseJWT().jti +
                            ' foi atualizado.'
                        );
                    }
                })
                .catch((erro) => console.log(erro))
                .then(this.buscarMeusDados)

                .then(this.limparCampos);
                window.location.href = "/dadosusuariocli";

        } else {
            fetch('http://localhost:5000/api/usuarios', {
                method: 'POST',
                body: JSON.stringify({
                    idTipoUsuario: 2,
                    nome: this.state.nome,
                    sobrenome: this.state.sobrenome,
                    email: this.state.email,
                    senha: this.state.senha,
                    dataCadastro: new Date()
                }),

                headers: {
                    'Content-Type': 'application/json',
                    Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
                },
            })
                .catch((erro) => console.log(erro))

                .then(this.buscarMeusDados)

                .then(this.limparCampos);
        }
    };

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value });
    };

    componentDidMount() {
        console.log('inicia ciclo de vida');
        this.buscarUsuarios();
        this.buscarMeusDados();
    }

    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <form onSubmit={this.editar} className="container-conteudo-edicao">
                        <h1>Dados do Usuário</h1>
                        {this.state.listaMeusDados.map((usuario) => {
                            return (
                                <div key={usuario.idUsuario}>
                                    <label htmlFor="nome">Nome</label>
                                    <input
                                        required
                                        placeholder={usuario.nome}
                                        type="text"
                                        name="nome"
                                        value={this.state.nome}
                                        onChange={this.atualizaStateCampo}
                                        className="input-text-edicao"
                                        id="nome"
                                    />
                                    <label htmlFor="sobrenome">Sobrenome</label>
                                    <input
                                        id="sobrenome"
                                        required
                                        placeholder={usuario.sobrenome}
                                        type="text"
                                        name="sobrenome"
                                        value={this.state.sobrenome}
                                        onChange={this.atualizaStateCampo}
                                        className="input-text-edicao" />
                                    <label htmlFor="email">E-mail</label>
                                    <input
                                        required
                                        type="text"
                                        name="email"
                                        placeholder={usuario.email}
                                        value={this.state.email}
                                        onChange={this.atualizaStateCampo}
                                        className="input-text-edicao" />
                                    <label htmlFor="senha">Senha</label>
                                    <input
                                        required
                                        type="text"
                                        name="senha"
                                        placeholder={usuario.senha}
                                        value={this.state.senha}
                                        onChange={this.atualizaStateCampo}
                                        className="input-text-edicao" />
                                    <div>
                                        <button type="submit" className="botao-editar">Editar</button>
                                    </div>
                                </div>
                            );
                        })}
                    </form>
                </div>
            </div>
        );
    }
}