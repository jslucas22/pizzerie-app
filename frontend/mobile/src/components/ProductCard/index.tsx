import React from "react";

import * as S from "./styles";
import { Product } from "../../definitions/product";
import { Image } from "react-native";
import Spacer from "../Spacer";
import { Shadows } from "../Shadows";

type Props = {
  product: Product;
};

const ProductCard: React.FC<Props> = ({ product }) => {
  return (
    <Shadows height="100">
      <S.Container>
        <Image
          source={{ uri: product.PhotoUrl }}
          resizeMode="cover"
          style={{ width: 90, height: "100%" }}
        />
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
