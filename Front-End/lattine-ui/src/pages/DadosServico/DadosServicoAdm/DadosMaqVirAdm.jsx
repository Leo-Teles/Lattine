import { useState, useEffect } from "react";
import axios from "axios";
import '../../../assets/css/style.css'
import { useParams } from "react-router-dom";
import Sidebar from "../../../components/Sidebar/SiderbarAdm/SidebarAdmServicos";

export default function DadosMaquina() {
    const [listaDadosMaquina, setListaDadosMaquina] = useState([]);
    const { id } = useParams();

    function buscarMeusDados() {
        axios('http://localhost:5000/api/MaquinaVirtuals/uma/'+id, {
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
    useEffect(buscarMeusDados, []);

    return (
        <div>
            <Sidebar />
            <div className="conteudo">
                {
                    listaDadosMaquina.map((maquina) => (
                        <div className="container-conteudo-servico">
                            <h1>Dados do Serviço</h1>

                            <h2>Detalhes do Serviço</h2>

                            <h3>Tipo de Serviço</h3>
                            <p>Máquina Virtual</p>
                            <h3>Data de Cadastro</h3>
                            <p>{Intl.DateTimeFormat({
                                        year: "numeric", month: "numeric", day: "numeric"
                                    }).format(new Date(maquina.dataCadastro))}</p>

                            <h2>Detalhes da Instância</h2>

                            <h3>Nome da Máquina Virtual</h3>
                            <p>{maquina.nomeMaquinaVirtual}</p>
                            <h3>Disponibilidade</h3>
                            <p>{maquina.opcoesDisponibilidade}</p>
                            <h3>Sistema Operacional</h3>
                            <p>{maquina.sistemaOperacional}</p>
                            <h3>Tamanho</h3>
                            <p>{maquina.tamanho}</p>

                            <h2>Conta do Administrador</h2>

                            <h3>Nome do Administrador</h3>
                            <p>{maquina.nomeAdmin}</p>
                            <h3>Origem Chave Pública SSH</h3>
                            <p>{maquina.origemChavePublicaSsh}</p>
                        </div>
                    )
                    )
                }
            </div>
        </div>
    )
}