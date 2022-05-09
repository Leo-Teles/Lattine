import { Component } from "react";

import '../../../assets/css/style.css'

import Sidebar from "../../../components/Sidebar/SiderbarFun/SidebarFunServicos";

export default class Servicos extends Component {
    render() {
        return (
            <div>
                <Sidebar />
                <div className="conteudo">
                    <div className="container-conteudo-edicao-servico">
                        <h1>Dados do Serviço</h1>
                        <h2>Detalhes do Serviço</h2>
                        <label for="gruporecursos">Grupo de Recursos</label>
                        <select id="gruporecursos">
                            <option value="1">Grupo 1</option>
                        </select>

                        <h2>Detalhes da Instância</h2>
                        <label for="nomeserapli">Nome do Serviço Aplicacional</label>
                        <input className="input-text-edicao" id="nomeserapli" placeholder="Meu Serviço Aplicacional"></input>

                        <label for="runtime">Pilha de Runtime</label>
                        <select id="runtime">
                            <option value="1">.NET 6 (LTS)</option>
                            <option value="2">.NET 5</option>
                            <option value="3">NODE 16 (LTS)</option>
                            <option value="4">NODE 15 (LTS)</option>
                        </select>

                        <label for="sku">SKU e Tamanho</label>
                        <select id="sku">
                            <option value="1">Básico B1- 100 ACU total, 1.75 GB de memória</option>
                            <option value="2">Básico B2 -200 ACU total, 3.5 GB de memória</option>
                            <option value="3">Gratuito F1 - 1 GB de memória</option>
                        </select>


                        <div>
                            <button className="botao-editar">Editar</button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}