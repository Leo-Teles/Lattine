import React from 'react'
import '../../../assets/css/style.css'

import imgLattine from "../../../assets/img/Lattine.png"
import imgHome from "../../../assets/img/Home.png"
import imgServicos from "../../../assets/img/Ferramentas.png"
import imgConfiguracao from "../../../assets/img/configuracao.png"
import imgSuporte from "../../../assets/img/suporte.png"
import imgSair from "../../../assets/img/sair.png"
import imgUsuario2 from "../../../assets/img/users2.png"

export default function Sidebar() {
    return (
        <section className='sidebar'>
            <div className='sidebar-container'>
                <div className='container-logo'>
                    <img src={imgLattine} alt='Logo da Lattine Group' />
                </div>
                <div className='linha-branca' />
                <div className='navegacao'>
                    <img src={imgHome} alt='Imagem Home' />
                    <p>Home</p>
                </div>
                <div className='navegacao'>
                    <img src={imgServicos} alt='Imagem Serviços' />
                    <p>Serviços</p>
                </div>
                <div className='navegacao'>
                    <img src={imgUsuario2} alt='Imagem Usuário' />
                    <p>Usuários</p>
                </div>
                <div className='separacao'/>
                <div className='navegacao'>
                    <img src={imgConfiguracao} alt='Imagem Configurações' />
                    <p>Configurações</p>
                </div>
                <div className='linha-branca' />
                <div className='navegacao'>
                    <img src={imgSuporte} alt='Imagem Suporte' />
                    <p>Suporte</p>
                </div>
                <div className='navegacao'>
                    <img src={imgSair} alt='Imagem Sair' />
                    <p>Sair</p>
                </div>
            </div>
        </section>
    )
}