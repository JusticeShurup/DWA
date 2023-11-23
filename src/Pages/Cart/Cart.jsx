import React from 'react';
import styles from "./cart.module.scss"
import CartItem from "../../Components/CartItem";
const Cart = () => {
    return (
        <div className={styles.cart}>
          <h1 className={styles.cart_title}>Корзина</h1>
            <div className={styles.item_wrapper}>
                <CartItem/>
                <CartItem/>
                <CartItem/>
                <CartItem/>
            </div>
            <p className={styles.price}> Итого: 9898 ₽</p>
            <button className={styles.button}>Оформить заказ</button>
        </div>
    );
};

export default Cart;