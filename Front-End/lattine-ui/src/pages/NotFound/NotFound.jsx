import '../../assets/css/style.css'

import imgNotFound from '../../assets/img/NotFound.png';



function NotFound() {
    return (
      <div  className="error" >

         <img src={imgNotFound} alt="img do notfound"/>
        
          <h1 className="fraseNaoEncontrada" > Página não encontrada </h1>
      
      </div>
    );
  }
  
  export default NotFound;