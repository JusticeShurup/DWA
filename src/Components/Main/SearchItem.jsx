import React from 'react';
import styles from "../../Pages/Main/main.module.scss";

const SearchItem = ({active,item}) => {
    return (
        <li className={`${styles.search_item} ${active?styles.active:""}` }>{item} </li>
    );
};

export default SearchItem;