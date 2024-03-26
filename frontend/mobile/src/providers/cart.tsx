import React, { createContext, useContext, useState } from 'react';

import { Order } from 'definitions/order';
import { OrderItem } from 'definitions/order_items';

interface CartProps {
    children: JSX.Element;
}

interface CartData {
    order: Order | undefined
    items: OrderItem[];
    addToCart: (item: OrderItem) => void;
    removeFromCart: (item: OrderItem) => void;
    updateItemCart: (item: OrderItem) => void;
    updateCart: (products: OrderItem[]) => void;
    setOrder: (order: Order | undefined) => void;
    cleanCart: () => void;
}

const CartContext = createContext({} as CartData);

const CartProvider: React.FC<CartProps> = ({ children }) => {
    const [items, setItems] = useState<OrderItem[]>([]);

    const [order, setOrder] = useState<
        Order | undefined
    >();

    const addToCart = (item: OrderItem) => {
        setItems([...items, item]);
    };

    const updateItemCart = (item: OrderItem) => {
        const newItemsCart = items.filter(cartItem => cartItem.ProductId !== item.ProductId);
        setItems([...newItemsCart, item]);
    };

    const removeFromCart = (item: OrderItem) => {
        const newItemsCart = items.filter(cartItem => cartItem.ProductId !== item.ProductId);
        setItems(newItemsCart);
    };

    const updateCart = (cartItems: OrderItem[]) => {
        setItems(cartItems);
    };

    const cleanCart = () => {
        setItems([]);
        setOrder(undefined);
    };

    return (
        <CartContext.Provider
            value={{
                items,
                addToCart,
                removeFromCart,
                updateItemCart,
                updateCart,
                cleanCart,
                order,
                setOrder
            }}>
            {children}
        </CartContext.Provider>
    );
};

const useCart = (): CartData => {
    const context = useContext(CartContext);

    return context;
};

export { CartProvider, useCart };