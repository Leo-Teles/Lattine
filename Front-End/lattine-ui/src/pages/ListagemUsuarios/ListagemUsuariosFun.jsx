import { useState, useEffect } from "react";
import axios from "axios";
import '../../assets/css/style.css'

import Sidebar from "../../components/Sidebar/SiderbarFun/SidebarFunUsuarios";


export default function Usuarios() {
    const [listaUsuarios, setListaUsuarios] = useState([]);

    function buscarUsuarios() {
        axios('http://localhost:5000/api/usuarios', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    setListaUsuarios(resposta.data)
                };
            })
            .catch(erro => console.log(erro));
    };
    useEffect(buscarUsuarios, []);

    return (
        <div>
            <Sidebar />
            <div className="conteudo">
                <div className="container-conteudo-users">
                    <div className="container-input">
                        <input type="text" placeholder="Buscar" />
                    </div>
                    <div className="listagem">
                        {
                            listaUsuarios.map((user) => (
                                <div key={user.IdUsuario} className="retangulo-usuario">
                                    <h1>{user.nome} {user.sobrenome}</h1>
                                    <h2>Data de Cadastro:</h2>
                                    <p>{Intl.DateTimeFormat({
                                        year: "numeric", month: "numeric", day: "numeric"
                                    }).format(new Date(user.dataCadastro))}</p>
                                </div>
                            )
                            )
                        }
                    </div>
                </div>
            </div>
        </div>
    )
}