
import styles from './app.module.scss';
import {
    Switch,
    Route,
    Link,
} from 'react-router-dom';
import LoadingScreen from "./Pages/LodadingScreen/LoadingScreen";
import Main from "./Pages/Main/Main";
import Item from "./Pages/Item/Item";
import Sidebar from "./Components/Sidebar";
import Welcome from "./Pages/Welcome/Welcome";
import Creator from "./Pages/Creator/Creator";
import Cart from "./Pages/Cart/Cart";
import Support from "./Pages/Support/Support";
import {characterContext} from "./character";
import {useState} from "react";
function App() {
    const [character,setCharacter ]= useState({
        top:"tshirt",
        topColor:"#000",
        bottom:"jeans",
        bottomColor:"#000"
    })
  return (
      <>
          <characterContext.Provider value={{
              character,setCharacter
          }}>
              <Switch>

                  <Route path={"/loading"}>
                      <LoadingScreen/>
                  </Route>

                  <Route path={"/welcome"}>
                      <Welcome/>
                  </Route>

                  <Route path={"/create"}>
                      <Creator/>
                  </Route>

                  <Route path={"/item/:id"}>
                      <Sidebar/>
                      <Item/>
                  </Route>

                  <Route path={"/cart"}>
                      <Sidebar/>
                      <Cart/>
                  </Route>
                  <Route path={"/support"}>
                      <Support/>
                  </Route>

                  <Route path={"/"}>
                      <Sidebar/>
                      <Main/>
                  </Route>


              </Switch>

          </characterContext.Provider>
      </>

  );
}

export default App;
