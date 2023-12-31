import React from "react";

import * as S from "./styles";
import { Product } from "definitions/product";
import { View } from "react-native";
import Spacer from "components/Spacer";
import { Shadows } from "components/Shadows";
import Icon, { IconProps } from "components/Icon";
import { useTheme } from "styled-components/native";

type Props = {
  product: Product;
};

const ProductCard: React.FC<Props> = ({ product }) => {
  const theme = useTheme();
  const icon: IconProps =
    product.Category == "Pizzas"
      ? { name: "pizza-slice", type: "fontAwesome5", size: 0 }
      : product.Category == "Bebidas"
      ? { name: "drink", type: "entypo", size: 0 }
      : { name: "question", type: "fontAwesome", size: 0 };

  return (
    <Shadows height="100">
      <S.Container>
        <View
          style={{
            width: 90,
            height: "100%",
            alignItems: "center",
            justifyContent: "center",
            backgroundColor: theme.colors.primary,
          }}
        >
          <Icon
            name={icon.name}
            type={icon.type}
            size={50}
            right={false}
            color={theme.colors.card}
            disabled
          />
        </View>
        <S.Content>
          <S.Title>{product.Name}</S.Title>
          <Spacer height={14} />
          <S.Subtitle>Categoria: {product.Category}</S.Subtitle>
          <Spacer height={8} />
          <S.Subtitle>Preço: R${product.Price}</S.Subtitle>
          <Spacer height={8} />
        </S.Content>
      </S.Container>
    </Shadows>
  );
};

export default ProductCard;
