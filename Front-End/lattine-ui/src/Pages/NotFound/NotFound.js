import './NotFound.css'

import imgNotFound from '../Assets/NotFound.png';



function NotFound() {
    return (
      <div  className="error" >

         <img src={imgNotFound} alt="img do notfound"/>
        
          <h1 className="fraseNaoEncontrada" > Página não encontrada </h1>
      
      </div>
    );
  }
  
  export default NotFound;