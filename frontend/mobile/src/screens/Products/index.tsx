import React from "react";
import { FlatList } from "react-native";

import ProductCard from "components/ProductCard";

import { Product } from "definitions/product";
import { ScreenBaseProps } from "utils/index";

import * as S from "./styles";
import ProductsHeader from "./header";

const Products: React.FC<ScreenBaseProps<"Products">> = () => {
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
      <ProductsHeader />
      <FlatList
        data={products}
        renderItem={(item) => <ProductCard product={item.item} />}
        style={{ paddingHorizontal: 24, paddingVertical: 16 }}
      />
    </S.Container>
  );
};

export default Products;
