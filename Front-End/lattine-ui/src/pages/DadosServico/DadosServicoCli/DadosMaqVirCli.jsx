import { useState, useEffect } from "react";
import axios from "axios";
import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SidebarCli/SidebarCliServicos";


export default function DadosMaquina() {
    const [listaDadosMaquina, setListaDadosMaquina] = useState([]);

    let id = this.props.match.params.id;

    function buscarDadosMaquina() {
        axios('http://localhost:5000/api/maquinavirtuals/' + id, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaDadosMaquina(resposta.data)
                };
            })
            .catch(erro => console.log(erro));
    };
    useEffect(buscarDadosMaquina, []);

    return (
        <div>
            <Sidebar />
            <div className="conteudo">
                {
                    listaDadosMaquina.map((maquina) => (
                        <div className="container-conteudo-servico">
                            <h1>Dados do Serviço número {this.props.match.params.id}</h1>

                            <h2>Detalhes do Serviço</h2>

                            <h3>Tipo de Serviço</h3>
                            <p>Máquina Virtual</p>
                            <h3>Data de Cadastro</h3>
                            <p>{maquina.dataCadastro}</p>
                            <h3>Grupo de Recursos</h3>
                            <p>Grupo 1</p>

                            <h2>Detalhes da Instância</h2>

                            <h3>Nome da Máquina Virtual</h3>
                            <p>Minha Máquina Virtual</p>
                            <h3>Disponibilidade</h3>
                            <p>Zona de Disponibilidade</p>
                            <h3>Sistema Operacional</h3>
                            <p>Windows Server 2019</p>
                            <h3>Tamanho</h3>
                            <p>Standard_D2s_v3 - 2vCPU,8Gib de memória</p>

                            <h2>Conta do Administrador</h2>

                            <h3>Nome do Administrador</h3>
                            <p>Luca</p>
                            <h3>Origem Chave Pública SSH</h3>
                            <p>Gerar novo par de chaves</p>
                        </div>
                    )
                    )
                }
            </div>
        </div>
    )
}