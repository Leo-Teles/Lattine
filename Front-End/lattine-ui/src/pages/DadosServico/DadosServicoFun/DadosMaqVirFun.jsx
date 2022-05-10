import { Component } from "react";
import { Link } from "react-router-dom/cjs/react-router-dom.min";

import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SiderbarFun/SidebarFunServicos";


export default class DadosMaqVir extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaMaqVir: [],
            IdInfraestrutura: 0,
            NomeMaquinaVirtual: '',
            OpcoesDisponibilidade: '',
            SistemaOperacional: '',
            Tamanho: '',
            NomeAdmin: '',
            OrigemChavePublicaSsh: '',
            titulo: '',
            idMaqVirAlterada: 0,
            titulosecao: 'Lista DadosMaqVir',
        };
    }

    BuscarMaquinas = () => {
        console.log('Agora vamos fazer a chamada para a api.');
        fetch('http://localhost:5000/api/maquinavirtuals', {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login'),
            },
        })

            .then((resposta) => resposta.json())
            .then((dados) => this.setState({ listaMaqVir: dados }))
            .catch((erro) => console.log(erro));
    };

    componentDidMount() {
        this.BuscarMaquinas();
    }

    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <div className="container-conteudo-servico">
                        <h1>Dados do Serviço</h1>

                        {this.state.listaMaqVir.map((maqvir) => {
                            return (
                                <div key={maqvir.idMaquinaVirtual}>
                                    <h2>Detalhes do Serviço</h2>
                                    <h3>Tipo de Serviço</h3>
                                    <p>Máquina Virtual</p>
                                    <h3>Data de Cadastro</h3>
                                    <p>28/04/2022</p>
                                    <h3>Grupo de Recursos</h3>
                                    <p>Grupo 1</p>

                                    <h2>Detalhes da Instância</h2>

                                    <h3>Nome da Máquina Virtual</h3>
                                    <p>{maqvir.nomeMaquinaVirtual}</p>
                                    <h3>Disponibilidade</h3>
                                    <p>{maqvir.opcoesDisponibilidade}</p>
                                    <h3>Sistema Operacional</h3>
                                    <p>{maqvir.sistemaOperacional}</p>
                                    <h3>Tamanho</h3>
                                    <p>{maqvir.tamanho}</p>

                                    <h2>Conta do Administrador</h2>

                                    <h3>Nome do Administrador</h3>
                                    <p>{maqvir.nomeAdmin}</p>
                                    <h3>Origem Chave Pública SSH</h3>
                                    <p>{maqvir.origemChavePublicaSsh}</p>
                                </div>
                            );
                        })}

                        <Link to="edicaomaqvirfun">Editar informações</Link>
                    </div>
                </div>
            </div>
        )
    }
}