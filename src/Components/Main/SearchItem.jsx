import React from 'react';
import styles from "../../Pages/Main/main.module.scss";

const SearchItem = (props) => {
    return (
        <li className={styles.search_item}>{props.item}   </li>
    );
};

export default SearchItem;