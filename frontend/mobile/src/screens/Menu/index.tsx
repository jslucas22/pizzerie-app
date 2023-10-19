import React from "react";

import * as S from "./styles";
import ProductCard from "../../components/ProductCard";
import { FlatList } from "react-native";

const Menu: React.FC = () => {
  const products = [
    {
      Id: "1",
      Name: "Pizza de Frango c/ Catupiry",
      Category: "Frango",
      Description: "Pizza de frango desfiado com catupiry. Deliciosa!",
      Price: 39.99,
      PhotoUrl:
        "https://www.bonissima.com.br/web/image/product.product/23855/image_1024/Pizza%20de%20Frango%20com%20Catupiry%20%28Pequena-4%20Fatias%29?unique=841ad30",
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
