import React from 'react'
import '../../../assets/css/style.css'
import { Link } from 'react-router-dom/cjs/react-router-dom.min'

import imgLattine from "../../../assets/img/Lattine.png"
import imgHome from "../../../assets/img/Home.png"
import imgServicos from "../../../assets/img/Ferramentas.png"
import imgConfiguracao from "../../../assets/img/configuracao.png"
import imgSuporte from "../../../assets/img/suporte.png"
import imgSair from "../../../assets/img/sair.png"

export default function Sidebar() {
    return (
        <section className='sidebar'>
            <div className='sidebar-container'>
                <div className='container-logo'>
                    <Link to=""><img src={imgLattine} alt='Logo da Lattine Group' /></Link>
                </div>
                <div className='linha-branca' />
                <Link to="" className='navegacao'>
                    <img src={imgHome} alt='Imagem Home' />
                    <p>Home</p>
                </Link>
                <Link to="" className='navegacao'>
                    <img src={imgServicos} alt='Imagem Serviços' />
                    <p>Serviços</p>
                </Link>
                <div className='separacao-cli' />
                <Link to="" className='navegacao'>
                    <img src={imgConfiguracao} alt='Imagem Configurações' />
                    <p>Configurações</p>
                </Link>
                <div className='linha-branca' />
                <Link to="" className='navegacao-selecionado'>
                    <img src={imgSuporte} alt='Imagem Suporte' />
                    <p>Suporte</p>
                </Link>
                <Link to="" className='navegacao'>
                    <img src={imgSair} alt='Imagem Sair' />
                    <p>Sair</p>
                </Link>
            </div>
        </section>
    )
}