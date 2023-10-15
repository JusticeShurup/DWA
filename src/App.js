
import styles from './app.module.scss';
import {
    BrowserRouter as Router,
    Switch,
    Route,
    Link,
} from 'react-router-dom';
import LoadingScreen from "./Pages/LodadingScreen/LoadingScreen";
import Main from "./Pages/Main/Main";
import shopIcon from "./Img/shop.svg"
import userIcon from "./Img/user.svg"
import exitIcon from "./Img/exit.svg"
import logo from "./Img/logo.svg"
import Item from "./Pages/Item/Item";

function App() {
  return (
      <>
          <div className={styles.sidebar}>
              <ul className={styles.sidebar_menu}>
                  <Link to={"/"}>
                      <li className={styles.sidebar_logo}>
                          <img src={logo} alt="logo"/>
                      </li>
                  </Link>
                  <Link to={"/"}>
                      <li className={styles.sidebar_menu_item}>
                          <img src={userIcon} alt="userIcon"/>
                      </li>
                  </Link>
                  <Link to={"/"}>
                      <li className={styles.sidebar_menu_item}>
                          <img src={exitIcon} alt="exitIcon"/>
                      </li>
                  </Link>
                  <Link to={"/"}>
                      <li className={styles.sidebar_menu_item}>
                          <img src={shopIcon} alt="shopIcon"/>
                      </li>
                  </Link>

              </ul>
          </div>

              <Switch>

                  <Route path={"/loading"}>
                      <LoadingScreen/>
                  </Route>


                  <Route path={"/item"}>
                      <Item/>
                  </Route>


                  <Route path={"/"}>
                      <Main/>
                  </Route>

              </Switch>
      </>

  );
}

export default App;
