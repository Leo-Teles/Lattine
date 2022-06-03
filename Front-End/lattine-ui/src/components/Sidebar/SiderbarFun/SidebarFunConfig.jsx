import React from 'react'
import '../../../assets/css/style.css'

import imgLattine from "../../../assets/img/Lattine.png"
import imgHome from "../../../assets/img/Home.png"
import imgServicos from "../../../assets/img/Ferramentas.png"
import imgConfiguracao from "../../../assets/img/configuracao.png"
import imgSuporte from "../../../assets/img/suporte.png"
import imgSair from "../../../assets/img/sair.png"
import imgUsuario2 from "../../../assets/img/users2.png"
import { Link } from 'react-router-dom'

export default function Sidebar() {
    return (
        <section className='sidebar'>
            <div className='sidebar-container'>
                <div className='container-logo'>
                <Link className="a" to="/homefun"><img className='logo-sidebar' src={imgLattine} alt='Logo da Lattine Group' /></Link>                </div>
                <div className='linha-branca' />
                <Link to="/homefun" className='navegacao'>
                    <img src={imgHome} alt='Imagem Home' />
                    <p>Home</p>
                </Link>
                <Link to="/escolherservicofun" className='navegacao'>
                    <img src={imgServicos} alt='Imagem Serviços' />
                    <p>Serviços</p>
                </Link>
                <Link to="/listagemusuariosfun" className='navegacao'>
                    <img src={imgUsuario2} alt='Imagem Usuário' />
                    <p>Usuários</p>
                </Link>
                <div className='separacao' />
                <a href='/dadosusuariofun' className='navegacao-selecionado'>
                    <img src={imgConfiguracao} alt='Imagem Configurações' />
                    <p>Configurações</p>
                </a>
                <div className='linha-branca' />
                <Link to="/contatosfun" className='navegacao'>
                    <img src={imgSuporte} alt='Imagem Suporte' />
                    <p>Suporte</p>
                </Link>
                <Link to="/login" className='navegacao'>
                    <img src={imgSair} alt='Imagem Sair' />
                    <p>Sair</p>
                </Link>
            </div>
        </section>
    )
}