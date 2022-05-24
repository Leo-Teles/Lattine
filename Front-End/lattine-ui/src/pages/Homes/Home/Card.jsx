import '../../../assets/css/style.css';
import React from 'react';
import { Link } from "react-router-dom";

import MaquinaHome from "../../../assets/img/MaquinaHome.png"
import redeHome from "../../../assets/img/redeHome.png"
import servicosHome from "../../../assets/img/servicosHome.png"

const Card = ({ data, cardHome }) => {

    return (
        <div>

            {data[cardHome].map(item => (

                <div className="card">


                    <div className="blocoEsquerdaCard"> 

                        <p>{item.title}</p>
                        <span>{item.name}</span>

                        <Link className="botaoDentro" to="/login"> Criar </Link>

                    
                    </div>

                    

                    {item.id == 1 &&
                        <img className="ftHomeMaquina" src={MaquinaHome} alt="" />
                    }

                    {item.id == 2 &&
                        <img className="ftHomeServicos" src={servicosHome} alt="" />
                    }

                    {item.id == 3 &&
                        <img className="ftHomeRede" src={redeHome} alt="" />
                    }

                </div>
                
                
                
            ))}

    

        </div>
    )
}

export default Card;