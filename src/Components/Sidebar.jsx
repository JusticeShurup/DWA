import React from 'react';
import styles from "../app.module.scss";
import {Link} from "react-router-dom";

const Sidebar = () => {
    return (
        <div className={styles.sidebar}>
            <ul className={styles.sidebar_menu}>
                <div>
                    <Link to={"/"}>
                        <li className={styles.sidebar_logo}>
                            <img src={"./menuIcons/logo.png"}  className={styles.sidebar_logo} alt="logo"/>
                        </li>
                    </Link>
                </div>
                <div>
                    <Link to={"/"}>
                        <li className={styles.sidebar_menu_item}>
                            <img src={"./menuIcons/exit.svg"} alt="userIcon"/>
                        </li>
                    </Link>
                    <Link to={"/"}>
                        <li className={styles.sidebar_menu_item}>
                            <img src={"./menuIcons/shopBag.png"} alt="exitIcon"/>
                        </li>
                    </Link>
                </div>
                <div>
                    <Link to={"/"}>
                        <li className={styles.sidebar_menu_item}>
                            <img src={"./menuIcons/call.png"} alt="shopIcon"/>
                        </li>
                    </Link>
                </div>
            </ul>
        </div>
    );
};

export default Sidebar;