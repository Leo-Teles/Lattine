import '../../assets/css/style.css';
import React from 'react';
import { Link } from "react-router-dom";

import MaquinaHome from "../../assets/img/MaquinaHome.png"
import img2 from "../../assets/img/cadeado.png"
import img3 from "../../assets/img/cadeado.png"

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
                        <img className="teteftHome" src={MaquinaHome} alt="" />
                    }

                    {item.id == 2 &&
                        <img src={img2} alt="" />
                    }

                    {item.id == 3 &&
                        <img src={img3} alt="" />
                    }

                </div>
                
                
                
            ))}

    

        </div>
    )
}

export default Card;