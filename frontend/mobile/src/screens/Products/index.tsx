import React from "react";
import { FlatList } from "react-native";

import ProductCard from "components/ProductCard";

import { Product } from "definitions/product";
import { ScreenBaseProps } from "utils/index";

import ProductsHeader from "./header";
import * as S from "./styles";

const Products: React.FC<ScreenBaseProps<"Products">> = ({ navigation }) => {
  const products: Product[] = [
    {
      Id: "1",
      Description: "Pizza Frango c/ Catupiry",
      Category: "Pizza",
      Price: 39.99,
    },
  ];

  return (
    <>
      <ProductsHeader
        onGoBack={navigation.goBack}
        onAdd={() => navigation.navigate("ProductForm")}
      />
      <S.Container>
        <FlatList
          data={products}
          renderItem={({ item }) => (
            <ProductCard
              product={item}
              onPress={() =>
                navigation.navigate("ProductForm", { id: item.Id })
              }
            />
          )}
          style={{ paddingHorizontal: 24, paddingVertical: 16 }}
        />
      </S.Container>
    </>
  );
};

export default Products;
