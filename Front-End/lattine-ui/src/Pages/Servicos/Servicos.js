import { Component } from "react";

import './Servicos.css';

import imgLattine from "../Assets/Lattine.png"
import imgFerrametas from "../Assets/Ferramentas.png"

export default class Servicos extends Component {
    render(){
        return(
            <div className="conteudotodo">

                <div className="conteudoEsquerda">

                    <img  src={imgLattine} alt="imagem do logo da lattine"  />
                    <hr className="linha"></hr>

                     <div className="blocoServicos">
                         <button className="botaoServicos"> <img src={imgFerrametas}/> </button>
                         <button className="botaoServicos">Home</button> 
                     </div>
                    

                   



                </div>

                <div>

                </div>

            </div>
        )
    }
}


