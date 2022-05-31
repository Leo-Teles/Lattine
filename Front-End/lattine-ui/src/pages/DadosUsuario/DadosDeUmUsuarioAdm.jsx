import { useState, useEffect } from "react";
import axios from "axios";
import '../../assets/css/style.css'
import { useParams } from "react-router-dom";

import Sidebar from "../../components/Sidebar/SiderbarAdm/SidebarAdmUsuarios";


export default function DadosUsuario() {
    const [listaDadosUsuario, setListaDadosUsuario] = useState([]);
    const { id } = useParams();

    function buscarDadosUsuario() {
        axios('http://localhost:5000/api/usuarios/um/'+id, {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaDadosUsuario(resposta.data)
                };
            })
            .catch(erro => console.log(erro));
    };
    useEffect(buscarDadosUsuario, []);

    return (
        <div>
            <Sidebar />
            <div className="conteudo">
                <div className="container-conteudo">
                    {
                        listaDadosUsuario.map((usuario) => (
                            <div>
                                <h1>Dados do Usuário</h1>
                                <h2>Nome</h2>
                                <p>{usuario.nome}</p>
                                <h2>Sobrenome</h2>
                                <p>{usuario.sobrenome}</p>
                                <h2>E-mail</h2>
                                <p>{usuario.email}</p>
                                <h2>Senha</h2>
                                <p>{usuario.senha}</p>
                                <h2>Tipo de Usuário</h2>
                                <p>{usuario.idTipoUsuarioNavigation.titulo}</p>
                            </div>
                        )
                        )
                    }
                </div>
            </div>
        </div>
    )
}