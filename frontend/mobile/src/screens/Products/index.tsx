import React from "react";
import { FlatList } from "react-native";

import ProductCard from "components/Cards/ProductCard";

import { Product } from "definitions/product";
import { ScreenBaseProps } from "utils/index";

import ProductsHeader from "headers/ProductsHeader";
import * as S from "./styles";

const Products: React.FC<ScreenBaseProps<"Products">> = ({ navigation, route }) => {
  const products: Product[] = [
    {
      Id: 1,
      Uuid: 'ashddashdshaksdhajksh',
      Description: "Pizza Frango c/ Catupiry",
      Category: "Pizza",
      Price: 39.99,
    },
  ];

  const notToList = route.params?.notToList ?? false

  return (
    <>
      <ProductsHeader
        onGoBack={navigation.goBack}
        onAdd={() => navigation.navigate("ProductForm")}
        notToList={notToList}
      />
      <S.Container>
        <FlatList
          data={products}
          renderItem={({ item }) => (
            <ProductCard
              product={item}
              onPress={() =>
                navigation.navigate("ProductForm", { id: item.Id, notToList })
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
