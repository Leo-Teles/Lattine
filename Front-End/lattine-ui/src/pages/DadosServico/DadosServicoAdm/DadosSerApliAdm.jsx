import { useState, useEffect } from "react";
import axios from "axios";
import '../../../assets/css/style.css'
import { useParams } from "react-router-dom";
import Sidebar from "../../../components/Sidebar/SiderbarAdm/SidebarAdmServicos";


export default function DadosServico() {
    const [listaDadosServico, setListaDadosServico] = useState([]);
    const { id } = useParams();

    function buscarMeusDados() {
        axios('http://localhost:5000/api/ServicoAplicacionals/um/' + id, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaDadosServico(resposta.data)
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
                    listaDadosServico.map((servico) => (
                        <div className="container-conteudo-servico">
                            <h1>Dados do Serviço</h1>

                            <h2>Detalhes do Serviço</h2>

                            <h3>Tipo de Serviço</h3>
                            <p>Serviço Aplicacional</p>
                            <h3>Data de Cadastro</h3>
                            <p>{Intl.DateTimeFormat({
                                year: "numeric", month: "numeric", day: "numeric"
                            }).format(new Date(servico.dataCadastro))}</p>

                            <h2>Detalhes da Instância</h2>

                            <h3>Nome do Serviço Aplicacional</h3>
                            <p>{servico.nomeServicoAplicacional}</p>
                            <h3>Pilha de Runtime</h3>
                            <p>{servico.pilhaRuntime}</p>
                            <h3>SKU  e Tamanho</h3>
                            <p>{servico.skueTamanho}</p>
                        </div>
                    )
                    )
                }
            </div>
        </div>
    )
}