import React from "react";

import * as S from "./styles";
import ProductCard from "components/ProductCard";
import { FlatList } from "react-native";
import { Product } from "definitions/product";
import { ScreenBaseProps } from "utils/index";

const Menu: React.FC<ScreenBaseProps<"Menu">> = () => {
  const products: Product[] = [
    {
      Id: "1",
      Name: "Pizza de Frango c/ Catupiry",
      Category: "Pizzas",
      Description: "Pizza de frango desfiado com catupiry. Deliciosa!",
      Price: 39.99,
    },
  ];

  return (
    <S.Container>
      <FlatList
        data={products}
        renderItem={(item) => <ProductCard product={item.item} />}
        style={{ paddingHorizontal: 24, paddingVertical: 16 }}
      />
    </S.Container>
  );
};

export default Menu;
