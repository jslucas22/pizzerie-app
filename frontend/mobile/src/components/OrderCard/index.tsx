import React from "react";
import { View } from "react-native";

import Icon from "components/Icon";
import { Shadows } from "components/Shadows";

import { Order } from "definitions/order";
import { useTheme } from "styled-components/native";

import * as S from "./styles";

type Props = {
  order: Order;
  onPress?: () => void;
};

const OrderCard: React.FC<Props> = ({ order, onPress }) => {
  const theme = useTheme();

  return (
    <Shadows>
      <S.Container onPress={onPress}>
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
            name="book"
            type="fontAwesome5"
            size={50}
            right={false}
            color={theme.colors.card}
            disabled
          />
        </View>
        <S.Content>
          <S.Title numberOfLines={1} ellipsizeMode="tail">
            Pedido #{order.Id}
          </S.Title>
          <S.Subtitle bold>
            Responsável: <S.Subtitle>{order.EmployeeId}</S.Subtitle>
          </S.Subtitle>
          <S.Subtitle bold>
            Cliente: <S.Subtitle>{order.CustomerName}</S.Subtitle>
          </S.Subtitle>
          <S.Subtitle bold>
            Data Início:{" "}
            <S.Subtitle>
              {order.CreatedAt.toLocaleString("pt-BR", {
                day: "numeric",
                month: "numeric",
                year: "numeric",
                hour: "2-digit",
                minute: "2-digit",
              })}
            </S.Subtitle>
          </S.Subtitle>
          <S.Subtitle bold>
            Últ. Alteração:{" "}
            <S.Subtitle>
              {order.UpdatedAt.toLocaleString("pt-BR", {
                day: "numeric",
                month: "numeric",
                year: "numeric",
                hour: "2-digit",
                minute: "2-digit",
              })}
            </S.Subtitle>
          </S.Subtitle>
        </S.Content>
      </S.Container>
    </Shadows>
  );
};

export default OrderCard;
