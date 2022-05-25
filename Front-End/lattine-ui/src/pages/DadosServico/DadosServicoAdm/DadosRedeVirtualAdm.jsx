import { useState, useEffect } from "react";
import axios from "axios";
import '../../../assets/css/style.css'
import { useParams } from "react-router-dom";
import Sidebar from "../../../components/Sidebar/SiderbarAdm/SidebarAdmServicos";

export default function DadosRede() {
    const [listaDadosRede, setListaDadosRede] = useState([]);
    const { id } = useParams();

    function buscarMeusDados() {
        axios('http://localhost:5000/api/RedeVirtuals/uma/' + id, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaDadosRede(resposta.data)
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
                    listaDadosRede.map((rede) => (
                        <div className="container-conteudo-servico">
                            <h1>Dados do Serviço</h1>

                            <h2>Detalhes do Serviço</h2>

                            <h3>Tipo de Serviço</h3>
                            <p>Rede Virtual</p>
                            <h3>Data de Cadastro</h3>
                            <p>{Intl.DateTimeFormat({
                                year: "numeric", month: "numeric", day: "numeric"
                            }).format(new Date(rede.dataCadastro))}</p>

                            <h2>Detalhes da Instância</h2>

                            <h3>Nome da Rede Virtual</h3>
                            <p>{rede.nomeRedeVirtual}</p>

                            <h2>Endereço de IP</h2>

                            <h3>Espaço de Endereço IPv4</h3>
                            <p>{rede.idEnderecoIpNavigation.endereco}</p>

                            <h2>Sub-rede</h2>

                            <h3>Nome de Sub-rede</h3>
                            <p>{rede.idEnderecoIpNavigation.nomeSubRede}</p>
                            <h3>Intervalos de Endereço de Sub-Rede</h3>
                            <p>{rede.idEnderecoIpNavigation.intervalosEndereco}</p>

                            <h2>Segurança</h2>

                            <h3>BastionHost</h3>
                            <p>{rede.bastionHost}</p>
                            <h3>Padrão de Proteção DDoS</h3>
                            <p>{rede.protecaoDdoS}</p>
                            <h3>Firewall</h3>
                            <p>{rede.fireWall}</p>
                        </div>
                    )
                    )
                }
            </div>
        </div>
    )
}