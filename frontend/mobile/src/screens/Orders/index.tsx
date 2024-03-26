import React from "react";
import { FlatList } from "react-native";

import OrderCard from "components/Cards/OrderCard";

import { Order } from "definitions/order";
import { ScreenBaseProps } from "utils/index";

import * as S from "./styles";
import { useCart } from "providers/cart";

const Orders: React.FC<ScreenBaseProps<"Orders">> = ({ navigation }) => {
  const { setOrder } = useCart()

  const employees: Order[] = [
    {
      Id: 1,
      Uuid: 'ashdkjasdhajksh',
      CustomerName: "John",
      CreatedAt: new Date(),
      EmployeeId: 1,
      UpdatedAt: new Date(),
      Status: 'Aberto',
      PaymentMethod: '',
      TableNumber: 13,
      TotalValue: 1888.9,
      Note: 'Sem cebola'
    },
  ];

  const onClick = (order: Order) => {
    setOrder(order)
    navigation.navigate("Order")
  }

  return (
    <S.Container>
      <FlatList
        data={employees}
        renderItem={({ item }) => (
          <OrderCard
            order={item}
            onPress={onClick}
          />
        )}
        style={{ paddingHorizontal: 24, paddingVertical: 16 }}
      />
    </S.Container>
  );
};

export default Orders;
